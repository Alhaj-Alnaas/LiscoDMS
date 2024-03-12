using ACS.DataAccess;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using ACS.Core.Flags;
using System.Linq.Expressions;
using Syncfusion.Windows.Forms.PdfViewer;
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;

namespace ACS.Archives
{
    public partial class ArchiveForm : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;

        public BaseUser MainUser;
        public List<CollectingMessage> inboxMessages;
        public List<CollectingMessage> outboxMessages;

        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");
        public string myNetworkPath = string.Empty;
        public ArchiveForm(DataContext dataContext
            , OldSysDBContext OldDataContext)
        {
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;
            InitializeComponent();

            MessageList.MouseDoubleClick += new MouseEventHandler(MessageList_MouseDoubleClick);

            MessageList.MouseClick += new MouseEventHandler(MessageList_Click);
        }

        private void MessageList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (new ConnectToSharedFolder(networkPath, credentials)) ;

            ListViewItem SelectMessage = MessageList.SelectedItems[0];

            var MessageId = SelectMessage.SubItems[0].Text.Trim();
            var MessageYear = SelectMessage.SubItems[1].Text.Trim();
            var MessageNo = SelectMessage.SubItems[2].Text.Trim();

            if (rdNewSys.Checked == true)
            {
                GetMessageDocs(MessageId);

            }
            else if (rdOldSys.Checked == true)
            {
                string FilePaht = GetOldMessageDocs(MessageNo, MessageYear);
                pdfViewerControl1.Load(FilePaht);
                pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

            }

        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {
            groupBox1.Left = 5;
            groupBox1.Top = 5;
            groupBox1.Width = this.Width - 35;
            groupBox1.Height = 130;

            btnSearch.Left = 10;
            // btnSearch.Left = btnSearch.Left + txtSearch.Width;

            MessageList.Top = groupBox1.Top + groupBox1.Height + 5;
            MessageList.Left = groupBox1.Left;
            MessageList.Width = this.Width / 2;
            MessageList.Height = this.Height - groupBox1.Height - 70;

            pdfViewerControl1.Top = MessageList.Top;
            pdfViewerControl1.Left = MessageList.Left + MessageList.Width + 5;
            pdfViewerControl1.Width = this.Width - MessageList.Width - 40;
            pdfViewerControl1.Height = MessageList.Height;

            picBox.Top = MessageList.Top;
            picBox.Left = MessageList.Left + MessageList.Width + 5;
            picBox.Width = this.Width - MessageList.Width;
            picBox.Height = MessageList.Height;

            pdfViewerControl1.ToolbarSettings.OpenButton.IsVisible = false;
            txtYear.Text = DateTime.Now.Year.ToString();

            MessageList.BackColor = ArchiveSettings.Default.ListColor;

            pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

            if (StaticParametrs.CurrentUser.Discriminator == "SubApplicationUser")
            {
                MainUser = _dataContext.Users.Where(x => x is ApplicationUser && x.JobCatId == 1 && x.JobStatus == "AE" && (x.ResponsibilityCode == StaticParametrs.CurrentUser.ResponsibilityCode)).OrderBy(x => x.ResponsibilityCode).FirstOrDefault();
            }
            else
            {
                MainUser = _dataContext.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.Id == StaticParametrs.CurrentUser.Id).FirstOrDefault();
            }

            FillMessagesAsync(MainUser);
            ViewMessagesAsync();
        }

        public void FillMessagesAsync(BaseUser User)
        {
            if (inboxMessages != null)
            {
                inboxMessages.Clear();
            }
           

            inboxMessages = _dataContext.CollectingMessages.FromSqlRaw("sp_show_inbox {0}, {1}, {2}, {3}, {4},{5}", User.ResponsibilityCode, User.FileNumber, User.Id, User.JobCatId, User.DesignationId, txtYear.Text).ToList();

            if (outboxMessages != null)
            {
                outboxMessages.Clear();
            }
           
            outboxMessages = _dataContext.CollectingMessages.FromSqlRaw("sp_show_outbox {0}, {1}, {2}, {3}, {4},{5}", User.ResponsibilityCode, User.FileNumber, User.Id, User.JobCatId, User.DesignationId, txtYear.Text).ToList();

        }
        public void ViewMessagesAsync()
        {
            
            foreach (var message in inboxMessages)
            {
                string[] row = { message.Id.ToString(),message.SendingDateTime.Year.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("dd/MM/yyyy"), message.SenderDiscription, "وارد" };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }

            foreach (var message in outboxMessages)
            {
                string[] row = { message.Id.ToString(), message.SendingDateTime.Year.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("dd/MM/yyyy"), message.RecipintDiscription, "صادر" };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }

        }

        public void GetMessageDocs(string MessageId)
        {
            var message = _dataContext.Messages.Include("Documents").Include("Sender").Include("Packages")
               .FirstOrDefault(m => m.Id == Guid.Parse(MessageId) ||
               m.OriginMessageId == MessageId);

            string FilePaht = PDFMergeAndStamp(message.Documents.OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), StaticParametrs.CurrentUser.FileNumber);
            pdfViewerControl1.Load(FilePaht);
            pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;
           
        }

        public string GetOldMessageDocs(string LtrNo, string LtrYear)
        {
            List<object> dobj = new List<object>();
            var UserFileNumber = StaticParametrs.CurrentUser.FileNumber;

            List<Employees> MessageDocs = _OldDataContext.Employees.Where(x => x.SltrNo == LtrNo && x.LtrYear.ToString() == LtrYear).ToList();
            foreach (var doc in MessageDocs)
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                MemoryStream Stream = new MemoryStream(doc.Photo);
                PdfBitmap image = new PdfBitmap(Stream);
                graphics.DrawImage(image, new System.Drawing.PointF(0, 0), new System.Drawing.SizeF(page.Size.Width, page.Size.Height));
                MemoryStream Stream2 = new MemoryStream();
                document.Save(Stream2);
                Stream2.Position = 0;
                document.Close(true);
                PdfLoadedDocument PdfDoc = new PdfLoadedDocument(Stream2);

                dobj.Add(PdfDoc);

            }

            PdfDocument FinalDoc = new PdfDocument();
            PdfMergeOptions mergeOption = new PdfMergeOptions
            {
                OptimizeResources = true
            };
            PdfDocumentBase.Merge(FinalDoc, mergeOption, dobj.ToArray());

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            foreach (PdfPageBase lPage in FinalDoc.Pages)
            {
                PdfGraphics graphics = lPage.Graphics;
                PdfGraphicsState state = graphics.Save();
                graphics.SetTransparency(0.25f);
                graphics.RotateTransform(-40);
                graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, -150, 450);
                graphics.Restore(state);
            }

            MemoryStream stream = new MemoryStream();
            FinalDoc.Save(stream);
            stream.Position = 0;
            FinalDoc.Close(true);

            var TempName = $@"\[{UserFileNumber}][{ Guid.NewGuid()}]" + ".pdf";
            //ViewData["Path"] = PathsProvider.TempFilesPath + TempName;
            using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\TempFiles\" + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            return @"D:\ASC Project\ACS.Archives\TempFiles\" + TempName;

        }

        private string PDFMergeAndStamp(List<string> FilesNames, string UserFileNumber)
        {
            PdfDocument FinalDoc = new PdfDocument();

            using (new ConnectToSharedFolder(networkPath, credentials)) ;
            foreach (var fileName in FilesNames)
            {
                string FilePaht = Path.Combine(networkPath, fileName + ".PDF");
                FileStream file = new FileStream(FilePaht, FileMode.Open, FileAccess.Read);
                PdfLoadedDocument doc = new PdfLoadedDocument(file);
                FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);

            }

            //Stamping
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 180f);
            foreach (PdfPageBase lPage in FinalDoc.Pages)
            {
                PdfGraphics graphics = lPage.Graphics;
                PdfGraphicsState state = graphics.Save();
                graphics.SetTransparency(0.25f);
                graphics.RotateTransform(-40);
                graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, -50, 100);
                //graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, 110, 250);
                graphics.SetTransparency(0.15f);
                graphics.DrawString(UserFileNumber, font2, PdfBrushes.Blue, -250, 390);
                graphics.Restore(state);
            }

            //Saving
            MemoryStream stream = new MemoryStream();
            FinalDoc.Save(stream);
            stream.Position = 0;
            FinalDoc.Close(true);
            var TempName = $@"\[{UserFileNumber}][{ Guid.NewGuid() }]" + ".pdf";
            using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\TempFiles\" + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            return @"D:\ASC Project\ACS.Archives\TempFiles\" + TempName;
        }

        public void SearchInNewSystem()
        {
            if (txtYear.Text.Trim() == null || txtYear.Text.Trim() == "")
            {
                MessageBox.Show("أدخل سنة البحث", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
            }

            FillMessagesAsync(MainUser);

            if
                (ImportMessages.Checked == true && ExportMessages.Checked == false)
            { outboxMessages.Clear(); }





            else if (ImportMessages.Checked == false && ExportMessages.Checked == true)
            { inboxMessages.Clear(); }

            else if (ImportMessages.Checked == false && ExportMessages.Checked == false)
            {
                outboxMessages.Clear();
                inboxMessages.Clear();
            }


            if (txtMessageNo.Text.Trim() != null && txtMessageNo.Text.Trim() != "")
            {
                if (outboxMessages != null)
                {
                    outboxMessages = outboxMessages.Where(x => x.SerialNumber != null && x.SerialNumber.Contains(txtMessageNo.Text.Trim())).ToList();
                }

                if (inboxMessages != null)
                {
                    inboxMessages = inboxMessages.Where(x => x.SerialNumber != null && x.SerialNumber.Contains(txtMessageNo.Text.Trim())).ToList();
                }

            }

            if (txtMessageSubject.Text.Trim() != null && txtMessageSubject.Text.Trim() != "")
            {
                if (outboxMessages != null)
                {
                    outboxMessages = outboxMessages.Where(x => x.Title != null && x.Title.Contains(txtMessageSubject.Text.Trim())).ToList();
                }

                if (inboxMessages != null)
                {
                    inboxMessages = inboxMessages.Where(x => x.Title != null && x.Title.Contains(txtMessageSubject.Text.Trim())).ToList();
                }

            }

            if (txtOrg.Text.Trim() != null && txtOrg.Text.Trim() != "")
            {
                if (outboxMessages != null)
                {
                    outboxMessages = outboxMessages.Where(x => x.RecipintDiscription != null && x.RecipintDiscription.Contains(txtOrg.Text.Trim())).ToList();
                }

                if (inboxMessages != null)
                {
                    inboxMessages = inboxMessages.Where(x => x.SenderDiscription != null && x.SenderDiscription.Contains(txtOrg.Text.Trim())).ToList();
                }

            }

            MessageList.Items.Clear();
            ViewMessagesAsync();

        }

        public void SearchInOldsystem()
        {
            if (txtYear.Text.Trim() == null || txtYear.Text.Trim() == "")
            {
                MessageBox.Show("أدخل سنة البحث", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
            }

            var messages = _OldDataContext.PostSendr.Where(x => x.LtrYear == txtYear.Text.Trim() && (x.WplacRecno == StaticParametrs.CurrentUser.ResponsibilityCode || x.WplacExpno == StaticParametrs.CurrentUser.ResponsibilityCode)).ToList();


            if (txtMessageNo.Text.Trim() != null && txtMessageNo.Text.Trim() != "")
            {
                messages = messages.Where(x => x.LaterNo != null && x.LaterNo.ToString() == txtMessageNo.Text.Trim()).ToList();
            }

            if (txtMessageSubject.Text.Trim() != null && txtMessageSubject.Text.Trim() != "")
            {
                messages = messages.Where(x => x.LaterInfor != null && x.LaterInfor.Contains(txtMessageSubject.Text)).ToList();
            }

            if (txtOrg.Text.Trim() != null && txtOrg.Text.Trim() != "")
            {
                messages = messages.Where(x => x.WplacExpl.Contains(txtOrg.Text) || x.WplacRecl.Contains(txtOrg.Text) || x.PlaceoutRec.Contains(txtOrg.Text)).ToList();
            }


            if
                (ImportMessages.Checked == true && ExportMessages.Checked == false)
                messages = messages.Where(x => x.RecordNameno == 2).ToList();

            else if (ImportMessages.Checked == false && ExportMessages.Checked == true)
                messages = messages.Where(x => x.RecordNameno == 1).ToList();

            else if (ImportMessages.Checked == true && ExportMessages.Checked == true)
                messages = messages.Where(x => x.RecordNameno == 1 || x.RecordNameno == 2).ToList();

            else if (ImportMessages.Checked == false && ExportMessages.Checked == false)
                messages = messages.Where(x => x.RecordNameno != 1 && x.RecordNameno != 2).ToList();

            MessageList.Items.Clear();

            foreach (var message in messages)
            {
                string[] row = { message.LaterNo.ToString(), message.LtrYear.ToString(), message.LaterNo.ToString(), message.LaterInfor, message.RecordDate.ToString(), message.WplacRecl ?? message.PlaceoutRec, message.RecordNamel };
                //message.WplacExpl ?? message.PlaceoutRec
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdNewSys.Checked == true)
            {
                SearchInNewSystem();

            }
            else if (rdOldSys.Checked == true)
            {
                SearchInOldsystem();

            }
        }

        public void ClearForm()
        {
            //txtYear.Text = null;
            MessageList.Items.Clear();
            txtMessageNo.Text = null;
            txtMessageSubject.Text = null;
            txtOrg.Text = null;
            //pdfViewerControl1.Hide();
            //picBox.Image = null;
            //picBox.Show();

        }

        private void ImportMessages_CheckedChanged(object sender, EventArgs e)
        {
            //ClearForm();
        }

        private void ExportMessages_CheckedChanged(object sender, EventArgs e)
        {
            //ClearForm();
        }

        private void rdNewSys_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm();
            SearchInNewSystem();

        }

        private void rdOldSys_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm();
            SearchInOldsystem();
        }
        private void MessageList_Click(object sender, EventArgs e)
        {
            if (rdNewSys.Checked==true)
            {
                CancelArchivedMenu.Items[0].Visible = true;
            }
            else
            {
                CancelArchivedMenu.Items[0].Visible = false;
            }
        }

        private void CancelArchivedMenu_Click(object sender, EventArgs e)
        {
           

        }

        private void إلغاءالأرشفةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem SelectMessage = MessageList.SelectedItems[0];

            var MessageId = SelectMessage.SubItems[0].Text.Trim();
            var MessageType = SelectMessage.SubItems[6].Text.Trim();

            var message = _dataContext.Messages.Include("Packages")
              .FirstOrDefault(m => m.Id == Guid.Parse(MessageId.ToString()));

            DialogResult result;
            result = MessageBox.Show("هل تريد بالتأكيد إلغاء أرشفة المراسلة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (MessageType != null && MessageType == "وارد")
                {
                    var OrgnaizationsResponsibilityCodes = _dataContext.Organizations.Where(m => m.DelegateNo == MainUser.FileNumber && DateTime.Now <= m.EndDate && m.IsDeleted == false).Select(d => d.ResponsibilityCode).ToList();

                    var packages = message.Packages.Where(a => a.RecipintId == MainUser.Id || (a.ResponsibilityCode == MainUser.ResponsibilityCode && a.DesignationId == MainUser.DesignationId) || OrgnaizationsResponsibilityCodes.Contains(a.ResponsibilityCode)).ToList();
                    if (packages != null || packages.Count() > 0)
                    {
                        foreach (var package in packages)
                        {
                            package.LastUpdatedBy = StaticParametrs.CurrentUser;
                            package.LastUpdatedById = StaticParametrs.CurrentUser.Id;
                            package.LastUpdatedOn = DateTime.Now;
                            package.IsArchived = false;
                            _dataContext.Update(package);
                            _dataContext.SaveChangesAsync();
                        }


                    }

                }
                else
                {
                    message.LastUpdatedBy = StaticParametrs.CurrentUser;
                    message.LastUpdatedById = StaticParametrs.CurrentUser.Id;
                    message.LastUpdatedOn = DateTime.Now;
                    message.IsArchived = false;
                    _dataContext.Update(message);
                    _dataContext.SaveChangesAsync();

                }

                MessageBox.Show("تم إلغاء أرشفة المراسلة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
