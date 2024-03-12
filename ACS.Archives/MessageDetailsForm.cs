using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.DataAccess;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Forms.PdfViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using PdfDocument = Syncfusion.Pdf.PdfDocument;
//using NReco.PdfGenerator;

namespace ACS.Archives
{
    public partial class MessageDetailsForm : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;
        private readonly string _messageId;
        private readonly string _messageType;
        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");

        public BaseUser MainUser;
        public BaseUser Sender;

        public List<SystemUser> SystemUsersList;
        public List<SystemUser> ReciptesUsers;

        public string myNetworkPath = string.Empty;

        public static object WIA_DPS_DOCUMENT_HANDLING_SELECT { get; private set; }
        public static object WIA_PROPERTIES { get; private set; }
        public static object WIA_DPS_DOCUMENT_HANDLING_STATUS { get; private set; }
        public MessageDetailsForm(
            DataContext dataContext
            , OldSysDBContext OldDataContext
            , string MessageId
            , string MessageType)
        {
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;
            _messageId = MessageId;
            _messageType = MessageType;
            InitializeComponent();
            DocList.MouseClick += new MouseEventHandler(DocList_MouseClick);

        }

        private void DocList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                downloadFileMenu.Show();
            }
        }

        private void MessageDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {

                
            pdfViewerControl1.Hide();
            pdfViewerControl1.ToolbarSettings.OpenButton.IsVisible = false;

                picBox.Width = (this.Width / 2) - 60;
                picBox.Top = 5;
                picBox.Left = 5;
                picBox.Height = this.Height - 65;

                pdfViewerControl1.Width = picBox.Width;
                pdfViewerControl1.Top = picBox.Top;
                pdfViewerControl1.Left = picBox.Left;
                pdfViewerControl1.Height = picBox.Height;

              
                //----------------------------------------------------------------

                groupBox1.Top = 5;
                groupBox1.Left = picBox.Left+ picBox.Width+5;
                groupBox1.Width = this.Width - (picBox.Width + 35);
                groupBox1.Height = this.Height/3 + this.Height / 10;

                // reciptes list
                ReciptesList.Left = 10;
                ReciptesList.Top =  20;
                ReciptesList.Width = (groupBox1.Width / 3) + 50;
                ReciptesList.Height = groupBox1.Height / 2;

                // copyToList 
                CCList.Left = ReciptesList.Left;
                CCList.Top = ReciptesList.Top + ReciptesList.Height + 10;
                CCList.Width = ReciptesList.Width;
                CCList.Height = groupBox1.Height / 3;

                txtMessageNo.Left = ReciptesList.Left + ReciptesList.Width + 50;
                txtMessageNo.Width = ReciptesList.Width;
                txtMessageNo.Top = ReciptesList.Top;
                txtMessageNo.Height = 40;

                //labMesNo
                labMesNo.Top = txtMessageNo.Top;
                labMesNo.Height = txtMessageNo.Height;
                labMesNo.Left = txtMessageNo.Left + txtMessageNo.Width + 10;

                //txtMessageSubject
            txtMessageSubject.Width = txtMessageNo.Width;
            txtMessageSubject.Top = txtMessageNo.Top + txtMessageNo.Height + 10;
            txtMessageSubject.Left = txtMessageNo.Left;
            txtMessageSubject.Height = 75;

            // labMesgSub
            labMesgSub.Left = labMesNo.Left;
            labMesgSub.Width = labMesNo.Width;
            labMesgSub.Top = txtMessageSubject.Top;
            labMesgSub.Height = txtMessageSubject.Height;

            //SENDER
            MessageSender.Left = txtMessageNo.Left;
            MessageSender.Width = txtMessageNo.Width;
            MessageSender.Top = txtMessageSubject.Top + txtMessageSubject.Height + 10;
            MessageSender.Height = 40;

            //lab sender
            labSender.Left = labMesNo.Left;
            labSender.Top = MessageSender.Top;
            labSender.Height = labMesNo.Height;

                //sending date
                txtSendingDate.Left = txtMessageNo.Left;
                txtSendingDate.Width = txtMessageNo.Width;
                txtSendingDate.Top = MessageSender.Top + MessageSender.Height + 10;
                txtSendingDate.Height = 40;

                //lab sending date
                labSendingDate.Left = labMesNo.Left;
                labSendingDate.Top = txtSendingDate.Top;
                labSendingDate.Height = labMesNo.Height;

                //-----------------------------------------------------------------------

                DocList.Top = groupBox1.Top + groupBox1.Height + 5;
                DocList.Left = groupBox1.Left;
                DocList.Width = groupBox1.Width;
                DocList.Height = this.Height /3 + this.Height / 24;
                
                // group box4------------------------------------------------
                groupBox4.Top = DocList.Top + DocList.Height + 5;
                groupBox4.Left = DocList.Left;
                groupBox4.Width = DocList.Width;
                groupBox4.Height = (this.Height / 9) ;

                //DeleteMessage.Top = 30;
                DeleteMessage.Left = (groupBox4.Width / 4) - groupBox4.Width / 10;
                DeleteMessage.Height = (groupBox4.Height / 3)*2;
                DeleteMessage.Width = groupBox4.Width / 4 + groupBox4.Width / 10;

                sendMessage.Top = DeleteMessage.Top;
                sendMessage.Left = DeleteMessage.Left + DeleteMessage.Width + (DeleteMessage.Width/3);
                sendMessage.Height = DeleteMessage.Height;
                sendMessage.Width = DeleteMessage.Width;

                DocList.BackColor = ArchiveSettings.Default.ListColor;

                //============================================================
                this.Show();
                DocList.View = View.Details;

                List<SystemUser> SenderTypes;

                if (StaticParametrs.CurrentUser.Discriminator == "SubApplicationUser")
                {
                    MainUser = _dataContext.Users.Where(x => x is ApplicationUser && x.JobCatId == 1 && x.JobStatus == "AE" && (x.ResponsibilityCode == StaticParametrs.CurrentUser.ResponsibilityCode)).OrderBy(x => x.ResponsibilityCode).FirstOrDefault();
                }
                else
                {
                    MainUser = _dataContext.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.Id == StaticParametrs.CurrentUser.Id).FirstOrDefault();
                }
               
                SystemUsersList = _dataContext.SystemUsers.FromSqlRaw("sp_show_system_users {0}"
          , MainUser.Id).ToList();

                SenderTypes = SystemUsersList.Where(x => x.FileNumber == MainUser.FileNumber).OrderBy(x => x.ResponsibilityCode).ToList();

            ReciptesUsers = SystemUsersList.Where(x => x.Id.ToString() != MainUser.Id).OrderBy(x => x.ResponsibilityCode).ToList();

                foreach (var user in ReciptesUsers)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
              //  UsersList.Items.Add(listViewItem);
            }

                foreach (var user in ReciptesUsers)
                {
                    string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                    var listViewItem = new ListViewItem(row);
                 //   CopyList.Items.Add(listViewItem);
                }


                txtMessageId.Text = _messageId;
                var message = _dataContext.Messages.Include("Documents").Include("Sender").Include("Packages")
                   .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()));

                if (message.OriginMessageId != null)
            {
                txtMessageId.Text = message.OriginMessageId.ToString();
            }

           
            txtMessageNo.Text = message.SerialNumber ;
            txtMessageSubject.Text = message.Title;
            MessageSender.Text = message.SenderDiscription;
            txtSendingDate.Text = message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy");
               
                // fill message recipts
            foreach (var package in message.Packages)
            {
                string[] row = { "", package.RecipintDiscription };
                var listViewItem = new ListViewItem(row);
                    if (package.IsCC==false)
                    {
                        ReciptesList.Items.Add(listViewItem);

                    }
                    else
                    {
                            CCList.Items.Add(listViewItem);
                    }
               
            }
               
            // GetMessageDocs
                GetMessageDocs(txtMessageId.Text.Trim());

                // FillAttaDos
                FillAttaDos(txtMessageId.Text.Trim());


            // make message as readed
                if (_messageType == "Inbox" )
            {
                    var OrgnaizationsResponsibilityCodes = _dataContext.Organizations.Where(m => m.DelegateNo == MainUser.FileNumber && DateTime.Now <= m.EndDate && m.IsDeleted == false).Select(d => d.ResponsibilityCode).ToList();

                    List<Package> packages = new List<Package>();
                 packages = _dataContext.Packages.Where(p => p.MessageId == Guid.Parse(_messageId) 
                 && (
                      p.RecipintId == MainUser.Id.ToString()
                     || 
                     ((p.ResponsibilityCode == MainUser.ResponsibilityCode && p.DesignationId == MainUser.DesignationId) || OrgnaizationsResponsibilityCodes.Contains(p.ResponsibilityCode))
                     )
                 ).ToList();

                    foreach (var package in packages)
                    {
                        if (package.IsReaded==false)
                        {
                            package.LastUpdatedBy = StaticParametrs.CurrentUser;
                            package.LastUpdatedById = StaticParametrs.CurrentUser.Id;
                            package.LastUpdatedOn = DateTime.Now;
                            package.IsReaded = true;

                        }
                        _dataContext.Packages.Update(package);
                    }
                    _dataContext.SaveChanges();

                }

          
            ReciptesList.View = View.Details;
            CCList.View = View.Details;

                pdfViewerControl1.Show();
            }

           
            catch (Exception)
            {
               // throw ;
                MessageBox.Show("لم يتم العثور على أي مستندات تخص هده المراسلة ... لمزيد من العلومات يمكنك مراجعة مسؤول النظام", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }
        public void GetMessageDocs(string MessageId)
        {
            try
            {
                var messages = _dataContext.Messages.Where(m => (m.Id == Guid.Parse(MessageId) || m.OriginMessageId == MessageId) && m.IsDeleted == false).Include("Documents");

                List<Doc> docs = new List<Doc>();

                foreach (var message in messages)
                {
                    var MessageDocs = message.Documents.Where(d=> d.IsTemp==false).ToList();
                    foreach (var doc in MessageDocs)
                    {
                        docs.Add(doc);

                    }
                }
                docs.OrderBy(d => d.CreatedOn);

                List<string> docIds = new List<string>();

                foreach (var doc in docs)
                {
                    var docId = doc.Id.ToString();
                    docIds.Add(docId);

                }

                string FilePaht = CustomPDFMergeAndStamp(docIds, StaticParametrs.CurrentUser.FileNumber, MessageId);
                picBox.Hide();
                pdfViewerControl1.Show();
                pdfViewerControl1.Load(FilePaht);
                pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

                string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";

                // delete temp files

                DirectoryInfo dir = new DirectoryInfo(FilePath);
                IEnumerable<FileInfo> Files = dir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (var item in Files)
                {
                    item.Delete();
                }

            }
            catch (Exception)
            {

            }

        }

        private string CustomPDFMergeAndStamp(List<string> FilesNames, string UserFileNumber,string MessageId)
        {
            //Syncfusion.Pdf.PdfDocument FinalDoc = new Syncfusion.Pdf.PdfDocument();
            PdfDocument FinalDoc = new PdfDocument();
            var message = _dataContext.Messages.FirstOrDefault(x => x.Id == Guid.Parse(MessageId));

            // convert message body to pdf file & add  it to FinalDoc
            if (message.Body != null && message.Body != "")
            {
                byte[] bytes;

                using (var memoryStream = new MemoryStream())
                { 
                    StringBuilder sb = new StringBuilder();

                    sb.Append(message.Body);
                    iText.Html2pdf.HtmlConverter.ConvertToPdf(sb.ToString(), memoryStream);
                    bytes = memoryStream.ToArray();
                }

                var FileTempName = $@"\[MessageBody][{ Guid.NewGuid() }]" + ".pdf";
                MemoryStream stream1 = new MemoryStream(0);
                stream1.Write(bytes, 0, bytes.Length);

                using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\TempFiles\" + FileTempName, FileMode.Create, FileAccess.Write))
                {
                    stream1.Position = 0;
                    stream1.CopyTo(fileStream);
                }

                var MessageBodyFilePath = @"D:\ASC Project\ACS.Archives\TempFiles\" + FileTempName;

                FileStream fileMessageBody = new FileStream(MessageBodyFilePath, FileMode.Open, FileAccess.Read);
                PdfLoadedDocument MessageBodyDoc = new PdfLoadedDocument(fileMessageBody);
                FinalDoc.ImportPageRange(MessageBodyDoc, 0, MessageBodyDoc.Pages.Count - 1);

                stream1.Dispose();

            }

            //  add  message docs to FinalDoc

            using (new ConnectToSharedFolder(networkPath, credentials)) ;
            foreach (var fileName in FilesNames)
            {
                string FilePaht = Path.Combine(networkPath, fileName + ".PDF");
                FileStream file = new FileStream(FilePaht, FileMode.Open, FileAccess.Read);
                PdfLoadedDocument doc = new PdfLoadedDocument(file);
                FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);

            }

            //  add  message comments to FinalDoc
            var comments = _dataContext.Messages.Where(m => m.OriginMessageId == txtMessageId.Text && m.IsOrigin == false && m.Body != null && m.Body != "").Include("Packages").Include("Sender").OrderBy(o => o.CreatedOn);
            if (comments.Count() != 0)
            {
                string procecingCardFilePaht = ExportPDF(message.SerialNumber);
                FileStream fileCard = new FileStream(procecingCardFilePaht, FileMode.Open, FileAccess.Read);
                PdfLoadedDocument Carddoc = new PdfLoadedDocument(fileCard);
                FinalDoc.ImportPageRange(Carddoc, 0, Carddoc.Pages.Count - 1);

            }
          

            //Stamping
            Syncfusion.Pdf.Graphics.PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            Syncfusion.Pdf.Graphics.PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 180f);
            foreach (PdfPageBase lPage in FinalDoc.Pages)
            {
                PdfGraphics graphics = lPage.Graphics;
                PdfGraphicsState state = graphics.Save();
                graphics.SetTransparency(0.25f);
                graphics.RotateTransform(-40);
                graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, -50, 100);
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
            stream.Dispose();
            return @"D:\ASC Project\ACS.Archives\TempFiles\" + TempName;
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                var _messageId = txtMessageId.Text;
                AddComments CommentForm = new AddComments(_dataContext, _OldDataContext, _messageId, _messageType,this);

                CommentForm.Width = this.Width ;
                CommentForm.Height = this.Height  ;
                CommentForm.StartPosition = FormStartPosition.CenterParent;

                CommentForm.ShowDialog(this);

            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("لايمكن العثور على ملف  المراسلة،نأمل مراجعة مسؤل النظام", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void DeleteMessage_Click(object sender, EventArgs e)
        {
           
            var message = _dataContext.Messages.Include("Packages")
              .FirstOrDefault(m => m.Id == Guid.Parse(_messageId.ToString()));
            if (_messageType == "Inbox")
            {
               
                DialogResult result;
                result = MessageBox.Show("هل تريد بالتأكيد حدف هده المراسلة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var OrgnaizationsResponsibilityCodes = _dataContext.Organizations.Where(m => m.DelegateNo == MainUser.FileNumber && DateTime.Now <= m.EndDate && m.IsDeleted == false).Select(d => d.ResponsibilityCode).ToList();

                    var packages = message.Packages.Where(a => a.RecipintId == MainUser.Id || (a.ResponsibilityCode == MainUser.ResponsibilityCode && a.DesignationId == MainUser.DesignationId) || OrgnaizationsResponsibilityCodes.Contains(a.ResponsibilityCode)).ToList(); 
                 
                    if (packages != null || packages.Count() > 0)
                    {
                        foreach (var package in packages)
                        {
                            package.DeletedBy = StaticParametrs.CurrentUser;
                            package.DeletedById = StaticParametrs.CurrentUser.Id;
                            package.DeletedOn = DateTime.Now;
                            package.IsDeleted = true;
                            _dataContext.Update(package);
                            _dataContext.SaveChangesAsync();
                        }

                        //call clear form 
                        ClearForm();
                        MessageBox.Show("تم حدف المراسلة بنجاح", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("لا يمكنك حدف هده المراسلة من صندوق الوارد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }

            }
           
            else
            {
                var count = _dataContext.Messages.Count(m => m.OriginMessageId == message.Id.ToString() && message.OriginMessageId != message.Id.ToString());
                if (count == 0 )

                {
                    DialogResult result;
                    result = MessageBox.Show("هل تريد بالتأكيد حدف هدة المراسلة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _dataContext.Messages.Remove(message);
                        _dataContext.SaveChangesAsync();

                        //call clear form
                        ClearForm();
                        MessageBox.Show("تم حدف المراسلة بنجاح", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
               
                else
                {
                    MessageBox.Show("لا يمكنك حدف هده المراسلة لإرتباطها بمراسلات أخرى", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }

        }

        public string  ExportPDF( string SerialNumber)
        {

            // creating data table and adding dummy data  
            DataTable dt = new DataTable();
            dt.Columns.Add("نص التأشيرة");
            dt.Columns.Add("التاريخ");
            dt.Columns.Add("التوقيــع");

          //---------------------------------------------------------------

            var comments = _dataContext.Messages.Where(m => m.OriginMessageId == txtMessageId.Text && m.IsOrigin==false && m.Body != null && m.Body!="").Include("Packages").Include("Sender").OrderBy(o=> o.CreatedOn);

            foreach (var comment in comments)
            {
                var recipints = "السيــد: ";
                foreach (var package in comment.Packages)
                {
                    if (package.IsCC==false)
                    {
                     recipints = recipints + package.RecipintDiscription + "،" + " ";

                    }
                   
                }
                recipints = recipints + "...";
                var sender = _dataContext.Users.Where(x => x.Id == comment.Sender.Id).FirstOrDefault();

                //if (sender.FullName != comment.SenderDiscription)
                //{
                comment.SenderDiscription = sender.FullName + "-" + sender.JobtypeName; //comment.SenderDiscription;
                //}
                dt.Rows.Add(new object[] { recipints +" " + comment.Body, comment.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), comment.SenderDiscription
            });
               
            }


            byte[] filecontent = exportpdf(dt, SerialNumber);

            Syncfusion.Pdf.PdfDocument FinalDoc = new Syncfusion.Pdf.PdfDocument();

            var TempName = $@"\[followPuCord][{ Guid.NewGuid() }]" + ".pdf";
            MemoryStream stream = new MemoryStream(0);
            stream.Write(filecontent, 0, filecontent.Length);

            using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\CommentTempFiles\" + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.Position = 0;
                stream.CopyTo(fileStream);
            }

            //pdfViewerControl1.Load(@"D:\ASC Project\ACS.Archives\TempFiles\" + TempName);
            var FilePath = @"D:\ASC Project\ACS.Archives\CommentTempFiles\" + TempName;
            return FilePath;

        }

        private byte[] exportpdf(DataTable dtCommets, string MessageSerialNumber)
        {
            // creating document object  
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A4);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
            Document doc = new Document(rec);
            doc.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            writer.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

            doc.Open();

            //Creating font ===============================================================
            string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";
            BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);

            var el = new Chunk();
            iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, el.Font.Size, el.Font.Style, el.Font.Color);
            el.Font = f2;
            //========================================================
            
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(basefont, 16, 1, iTextSharp.text.BaseColor.BLUE);

            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Phrase("Sn : " + MessageSerialNumber, fntHead));
            writer.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            doc.Add(prgHeading);
            

            //Adding paragraph for report generated by  
            Paragraph prgGeneratedBY = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.BLUE);
            prgGeneratedBY.Alignment = Element.ALIGN_LEFT; 
            prgGeneratedBY.Add(new Chunk("Generated Date : " + DateTime.Now.ToShortDateString(), fntAuthor));  
            doc.Add(prgGeneratedBY);


            //Adding a line  
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(p);

            //Adding line break  

            doc.Add(new Chunk("\n", fntHead));

            //Adding  PdfPTable  
            PdfPTable table = new PdfPTable(dtCommets.Columns.Count);

            table.HorizontalAlignment = 0;
            table.TotalWidth = 520f;
            table.LockedWidth = true;
            float[] widths = new float[] { 200f, 110f, 210f };
            table.SetWidths(widths);

            // new 
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

            for (int i = 0; i < dtCommets.Columns.Count; i++)
            {
                string cellText = dtCommets.Columns[i].ColumnName;
                
                PdfPCell cell = new PdfPCell(new Phrase(10, cellText, el.Font));

                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 10;
                table.AddCell(cell);

            }

            //writing table Data  
            for (int i = 0; i < dtCommets.Rows.Count; i++)
            {
                for (int j = 0; j < dtCommets.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(10, dtCommets.Rows[i][j].ToString(), el.Font));
                    table.AddCell(cell);
                }
            }

            doc.Add(table);
            doc.Close();

            byte[] result = ms.ToArray();
            return result;

        }

        public void DownloadFile (string fileName, string NewFileName)
        {
           
            try
            {
                 string networkTempPath = @"\\10.10.102.16\TempAttach";

                using (new ConnectToSharedFolder(networkTempPath, credentials))
                { 
                    var filePath = Path.Combine(networkTempPath, fileName);
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                              var copyToPath = Path.Combine(fbd.SelectedPath, NewFileName);

                            if (File.Exists(copyToPath))
                            {
                                File.Delete(copyToPath);
                            }
                            System.IO.File.Copy(filePath, copyToPath);
                            MessageBox.Show("تم تنزيل الملف بنجاح");
                        }
                }

               }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void FillAttaDos(string MessageId)
        {
            DocList.Items.Clear();

            var messages = _dataContext.Messages.Where(m => (m.Id == Guid.Parse(MessageId) || m.OriginMessageId == MessageId) && m.IsDeleted == false).Include("Documents");

            
            foreach (var item in messages)
            {
                var docs = _dataContext.Docements.Where(d => d.MessageId == item.Id && d.IsTemp == true);
                foreach (var doc in docs)
                {
                    string[] row = { doc.Id.ToString(), doc.Name, doc.Extention, doc.Size.ToString()};
                    var listViewItem = new ListViewItem(row);
                    DocList.Items.Add(listViewItem);

                }
                
            }
        }

        private void downloadFileMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = DocList.SelectedItems[0].Text.Trim().ToString() + "."
                        + DocList.SelectedItems[0].SubItems[2].Text.Trim().ToString();

                var NewfileName = DocList.SelectedItems[0].SubItems[1].Text.Trim().ToString() + "."
                                   + DocList.SelectedItems[0].SubItems[2].Text.Trim().ToString();

                DownloadFile(fileName, NewfileName);
                //MessageBox.Show("تم تنزيل الملف بنجاح");

            }
            catch (Exception)
            {

                throw;
            }
            
           

        }

        public void ClearForm()
        {
            txtMessageId.Text = null;
            txtMessageSubject.Text = null;
            txtMessageNo.Text = null;
            MessageSender.Text = null;
            ReciptesList.Items.Clear();
            CCList.Items.Clear();
            picBox.Image = null;
            DocList.Items.Clear();
            pdfViewerControl1.Hide();
            picBox.Image = null;
            picBox.Show();

        }
    }
}
