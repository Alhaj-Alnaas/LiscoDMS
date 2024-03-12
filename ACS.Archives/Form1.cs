
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

namespace ACS.Archives
{
    public partial class SearchForm : Form
    {
        //private readonly IMessagesServices<Core.Entities.Message> _messageServices;
        //protected readonly IUserProvider _userProvider;
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;

        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");
        public string myNetworkPath = string.Empty;

        public SearchForm(
             //IMessagesServices<Core.Entities.Message> messageServices
             //, IUserProvider userProvider
             DataContext dataContext
            , OldSysDBContext OldDataContext)
        {
            //_messageServices = messageServices;
            //_userProvider = userProvider;
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;
            InitializeComponent();

            MessageList.MouseDoubleClick += new MouseEventHandler(MessageList_MouseDoubleClick);

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


        private void SearchForm_Load(object sender, EventArgs e)
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
            MessageList.BackColor = ArchiveSettings.Default.ListColor;
            pdfViewerControl1.ToolbarSettings.OpenButton.IsVisible = false;
            txtYear.Text = DateTime.Now.Year.ToString();

            pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

            ViewMessagesAsync();
        }
        public void ViewMessagesAsync()
        {
            var messages = _dataContext.Messages.Where(x => x.IsDeleted == false && x.IsForeign == true && x.CreatedOn.Year == DateTime.Now.Year).Include("Packages");

            foreach (var message in messages)
            {
                string[] row = { message.Id.ToString(), message.CreatedOn.Year.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString(), message.SenderDiscription, message.Packages.Select(p => p.RecipintDiscription).FirstOrDefault(), message.Packages.Select(p => p.RecipintDiscription).LastOrDefault() };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }

        }

        public void SearchInNewSystem()
        {

            var messages = _dataContext.Messages.Include("Packages").Where(x => x.IsDeleted == false && x.IsForeign == true);

            if (txtYear.Text.Trim() != null && txtYear.Text.Trim() != "")
            {
                messages = messages.Where(x => x.CreatedOn.Year.ToString() == txtYear.Text.Trim());
            }

            if (txtMessageNo.Text.Trim() != null && txtMessageNo.Text.Trim() != "")
            {
                messages = messages.Where(x => x.SerialNumber != null && x.SerialNumber.Contains(txtMessageNo.Text.Trim()) );
            }

            if (txtMessageSubject.Text.Trim() != null && txtMessageSubject.Text.Trim() != "")
            {
                messages = messages.Where(x => x.Title != null && x.Title.Contains(txtMessageSubject.Text));
            }

            if (txtOrg.Text.Trim() != null && txtOrg.Text.Trim() != "")
            {
                messages = messages.Where(x => (x.SenderDiscription != null && x.SenderDiscription.Contains(txtOrg.Text)) ||
                 (x.Packages.Select(p=>p.RecipintDiscription != null && p.RecipintDiscription.Contains(txtOrg.Text))).FirstOrDefault()
                );
            }

            if
               (ImportMessages.Checked == true && ExportMessages.Checked == false)
                messages = messages.Where(x => x.MessageType == MessageType.Inport);

            else if (ImportMessages.Checked == false && ExportMessages.Checked == true)
                messages = messages.Where(x => x.MessageType == MessageType.Export);

            else if (ImportMessages.Checked == true && ExportMessages.Checked == true)
                messages = messages.Where(x => x.MessageType == MessageType.Export || x.MessageType == MessageType.Inport);

            else if (ImportMessages.Checked == false && ExportMessages.Checked == false)
                messages = messages.Where(x => x.MessageType != MessageType.Export && x.MessageType != MessageType.Inport);


            MessageList.Items.Clear();

            foreach (var message in messages)
            {
                var qry = _dataContext.Messages.Where(m => m.Id == message.Id || m.Id.ToString() == message.OriginMessageId).Select(j => j.Id).ToList();

                var package = _dataContext.Packages.Where(p => qry.Contains(p.MessageId)).OrderByDescending(x => x.CreatedOn).FirstOrDefault();

                string[] row = { message.Id.ToString(),
                                 message.CreatedOn.Year.ToString(),
                                 message.SerialNumber,
                                 message.Title,
                                 message.SendingDateTime.ToString(),
                                 message.SenderDiscription,
                                 message.Packages.Select(p => p.RecipintDiscription).FirstOrDefault(),                 package.RecipintDiscription };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }
        }

        public void SearchInOldsystem()
        {
            if (txtYear.Text.Trim() == null || txtYear.Text.Trim() == "")
            {
                MessageBox.Show("أدخل سنة البحث", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
            }

                var messages = _OldDataContext.PostSendr.Where(x => (x.PostTypeno == 0 || x.PostTypeno == 1) && x.LtrYear == txtYear.Text.Trim());

           
            if (txtMessageNo.Text.Trim() != null && txtMessageNo.Text.Trim() != "")
            {
                messages = messages.Where(x => x.LaterNo != null && x.LaterNo.ToString() == txtMessageNo.Text.Trim());
            }

            if (txtMessageSubject.Text.Trim() != null && txtMessageSubject.Text.Trim() != "")
            {
                messages = messages.Where(x => x.LaterInfor != null && x.LaterInfor.Contains(txtMessageSubject.Text));
            }

            if (txtOrg.Text.Trim() != null && txtOrg.Text.Trim() != "")
            {
                messages = messages.Where(x =>  x.WplacExpl.Contains(txtOrg.Text) || x.WplacRecl.Contains(txtOrg.Text) || x.PlaceoutRec.Contains(txtOrg.Text));
            }


            if
                (ImportMessages.Checked == true && ExportMessages.Checked == false)
                messages = messages.Where(x => x.RecordNameno == 2);

            else if (ImportMessages.Checked == false && ExportMessages.Checked == true)
                messages = messages.Where(x => x.RecordNameno == 1);

            else if (ImportMessages.Checked == true && ExportMessages.Checked == true)
                messages = messages.Where(x => x.RecordNameno == 1 || x.RecordNameno == 2);

            else if (ImportMessages.Checked == false && ExportMessages.Checked == false)
                messages = messages.Where(x => x.RecordNameno != 1 && x.RecordNameno != 2);

            MessageList.Items.Clear();

            foreach (var message in messages)
            {
                string[] row = { message.LaterNo.ToString(), message.LtrYear.ToString(), message.LaterNo.ToString(), message.LaterInfor, message.RecordDate.ToString(), message.WplacRecl ?? message.PlaceoutRec, message.WplacExpl ?? message.PlaceoutRec };
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
            //pdfViewerControl1.ZoomTo(50);



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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtYear_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
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
        }

        private void txtMessageNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
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
        }

        private void txtMessageSubject_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
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
        }

        private void txtOrg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
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
        }

        public void ClearForm()
        {
            txtYear.Text = null;
            txtMessageNo.Text = null;
            txtMessageSubject.Text = null;
            txtOrg.Text = null;
            txtOrg.Text = null;
            MessageList.Items.Clear();
            pdfViewerControl1.Hide();
            picBox.Image = null;
            picBox.Show();

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
    }
}
