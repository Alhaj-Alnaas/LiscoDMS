using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Flags;
using ACS.Core.Interfaces.Services;
using ACS.DataAccess;
using ACS.Web.Providers;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Forms.PdfViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Message = ACS.Core.Entities.Message;

namespace ACS.Archives

{
    public partial class mainScreen : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;
        private readonly IMessagesServices<Message> _messageServices;

        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");

        public string myNetworkPath = string.Empty;
        public List<SystemUser> users;

        public static object WIA_DPS_DOCUMENT_HANDLING_SELECT { get; private set; }
        public static object WIA_PROPERTIES { get; private set; }
        public static object WIA_DPS_DOCUMENT_HANDLING_STATUS { get; private set; }

        public mainScreen(
             DataContext dataContext
            , OldSysDBContext OldDataContext
            , IMessagesServices<Message> messageServices

            )
        {
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;
            _messageServices = messageServices;

            InitializeComponent();

            copyToList.MouseClick += new MouseEventHandler(copyToList_MouseClick);
            CopyList.MouseDoubleClick += new MouseEventHandler(CopyList_MouseDoubleClick);

            MessageList.MouseClick += new MouseEventHandler(MessageList_MouseClick);
            MessageList.MouseDoubleClick += new MouseEventHandler(MessageList_MouseDoubleClick);

            DocList.MouseClick += new MouseEventHandler(DocList_MouseClick);
            DocList.MouseDoubleClick += new MouseEventHandler(DocList_MouseDoubleClick);
        }
        private void copyToList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                deleteCopyMenu.Show();
            }
        }

        private void CopyList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var UseId = CopyList.SelectedItems[0].Text.Trim().ToString();
            var UserJob = CopyList.SelectedItems[0].SubItems[2].Text.Trim().ToString();

            string[] row = { UseId, UserJob };
            var listViewItem = new ListViewItem(row);

            copyToList.Items.Add(listViewItem);
        }

        private void DocList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeleteDocMenu.Show();
            }
        }

        private void MessageList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeleteMessageMenu.Show(Cursor.Position);
            }
        }

        private async void DocList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var DocId = DocList.SelectedItems[0].Text.Trim().ToString();
            var DocName = DocList.SelectedItems[0].SubItems[1].Text.Trim().ToString();

            if (txtMessageId.Text.Trim() != "")

            {
                var message = await _dataContext.Messages.Include("Documents").Include("Sender").Include("Packages").Include("MessagesCategories").FirstOrDefaultAsync(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()));

                picBox.Image = null;

                using (new ConnectToSharedFolder(networkPath, credentials))
                    foreach (var item in message.Documents)
                    {
                        if (item.Id.ToString() == DocId)
                        {

                            string FilePaht = Path.Combine(networkPath, item.Id + ".PDF");

                            pdfViewerControl1.Load(FilePaht);
                            //pdfViewerControl1.ZoomTo(50);
                            pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;
                            pdfViewerControl1.Show();

                        }

                    }
            }

            else if (txtMessageId.Text.Trim() == "" && DocId != "")
            {
                string FilePaht = Path.Combine(@"D:\ASC Project\ACS.Archives\TempFiles\", DocName + ".PDF");
                pdfViewerControl1.Load(FilePaht);
                //pdfViewerControl1.ZoomTo(50);
                pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;
                pdfViewerControl1.Show();
            }

        }

        private void MessageList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            copyToList.Items.Clear();
            ClearForm();

            btnUpdate.Show();
            btnSave.Hide();
            btnClear.Enabled = false;
            btnCancel.Enabled = true;

            ViewMessageDetails();
            if (Inbox.Checked == true)
            {
                btnCard.Enabled = true;
            }
            else
            {
                btnCard.Enabled = false;
            }

        }

        private void mainScreen_Load(object sender, EventArgs e)
        {
            //Clear Scan Temp Folders();
            // new code 29.05.2023 =======================
            string FilePath = @"D:\ASC Project\ACS.Archives\ScanFiles\";
            string[] ScanTemmFiles = Directory.GetFiles(FilePath);
            {
                foreach (var item in ScanTemmFiles)
                {
                    File.Delete(item);
                }
            }
            //==================================================

            btnCard.Enabled = false;
            pdfViewerControl1.Hide();
            pdfViewerControl1.ToolbarSettings.OpenButton.IsVisible = false;


            panel3.Top = this.Top + 10;
            panel3.Left = 0;
            panel3.Width = this.Width - 20;
            panel3.Height = this.Height / 15;


            btnCard.Left = (panel3.Width / 2); //   /14* 9
            btnCard.Top = panel3.Top + 10;
            btnCard.Width = panel3.Width / 10;
            btnCard.Height = panel3.Height - 20;

            btnCancel.Left = btnCard.Left + btnCard.Width + 50;
            btnCancel.Top = btnCard.Top;
            btnCancel.Width = btnCard.Width;
            btnCancel.Height = btnCard.Height;

            btnSave.Left = btnCancel.Left + btnCancel.Width + 30;
            btnSave.Top = btnCancel.Top;
            btnSave.Width = btnCancel.Width;
            btnSave.Height = btnCancel.Height;

            btnUpdate.Left = btnCancel.Left + btnCancel.Width + 30;
            btnUpdate.Top = btnCancel.Top;
            btnUpdate.Width = btnCancel.Width;
            btnUpdate.Height = btnCancel.Height;

            btnClear.Left = btnSave.Left + btnSave.Width + 30;
            btnClear.Top = btnCard.Top;
            btnClear.Width = btnCard.Width;
            btnClear.Height = btnCard.Height;


            groupBox2.Top = panel3.Height + 5;
            groupBox2.Left = 5;
            groupBox2.Width = (this.Width / 3) + (this.Width / 10);
            groupBox2.Height = (this.Height / 3) * 2;

            // btnSelectFile.Top = groupBox2.Top + 20;
            btnSelectFile.Left = groupBox2.Left + (groupBox2.Width / 2);
            btnSelectFile.Width = (groupBox2.Width / 5) + 20;
            btnSelectFile.Height = 40;

            btnScanFile.Top = btnSelectFile.Top;
            btnScanFile.Left = btnSelectFile.Left + btnSelectFile.Width + 20;
            btnScanFile.Width = btnSelectFile.Width;
            btnScanFile.Height = btnSelectFile.Height;

            picBox.Width = groupBox2.Width;
            picBox.Top = groupBox2.Top + 5;
            picBox.Left = groupBox2.Left;
            picBox.Height = groupBox2.Height;

            pdfViewerControl1.Width = groupBox2.Width;
            pdfViewerControl1.Top = groupBox2.Top + 5;
            pdfViewerControl1.Left = groupBox2.Left;
            pdfViewerControl1.Height = groupBox2.Height;

            DocList.Top = groupBox2.Top + groupBox2.Height + 5;
            DocList.Left = groupBox2.Left;
            DocList.Width = groupBox2.Width;
            DocList.Height = this.Height - (groupBox2.Height + groupBox3.Height + 50);
            //----------------------------------------------------------------


            groupBox3.Top = groupBox2.Top;
            groupBox3.Left = groupBox2.Left + groupBox2.Width + 5;
            groupBox3.Width = this.Width - (groupBox2.Width + 30);
            groupBox3.Height = (this.Height - panel3.Height) / 10;

            // Inbox.Top = groupBox3.Top + 10;
            Inbox.Left = groupBox3.Width / 4;
            Inbox.Width = (groupBox3.Width / 3);

            outbox.Left = Inbox.Left + Inbox.Width + 30;
            outbox.Width = (groupBox3.Width / 3);

            groupBox1.Top = groupBox3.Top + groupBox3.Height + 5;
            groupBox1.Left = groupBox3.Left;
            groupBox1.Width = groupBox3.Width;
            groupBox1.Height = groupBox3.Height * 3 + 50;

            MessageSender.Left = groupBox1.Width / 90;
            MessageSender.Width = (groupBox1.Width / 3) + 20;
            labComeFrom.Left = MessageSender.Left + MessageSender.Width + 10;
            labComeFrom.Width = MessageSender.Width / 3;

            txtOrg.Left = MessageSender.Left;
            txtOrg.Width = MessageSender.Width;
            label4.Left = labComeFrom.Left;
            label4.Width = labComeFrom.Width;

            SendDate.Left = MessageSender.Left;
            SendDate.Width = MessageSender.Width;
            label5.Left = labComeFrom.Left;
            label5.Width = labComeFrom.Width;

            MessageSerialNumber.Left = groupBox1.Width / 2;
            MessageSerialNumber.Width = (groupBox1.Width / 3);
            label1.Left = MessageSerialNumber.Left + MessageSerialNumber.Width;
            label1.Width = labComeFrom.Width;

            MessageSubject.Left = MessageSerialNumber.Left;
            MessageSubject.Width = MessageSerialNumber.Width;
            label2.Left = label1.Left;
            label2.Width = label1.Width;
            //-------------------------------------------------------------------------------
            // copyToList
            copyToList.Left = MessageSubject.Left;
            copyToList.Width = MessageSubject.Width;
            copyToList.Top = MessageSubject.Top + MessageSubject.Height + 10;
            copyToList.Height = 80;

            // btnCopyTo
            btnCopyTo.Left = copyToList.Left + copyToList.Width;
            btnCopyTo.Height = copyToList.Height;
            btnCopyTo.Width = label2.Width;
            btnCopyTo.Top = copyToList.Top;

            // btnCloseCopyList
            btnCloseCopyList.Left = copyToList.Left;
            btnCloseCopyList.Height = 40;
            btnCloseCopyList.Width = 40;
            btnCloseCopyList.Top = copyToList.Top + copyToList.Height + 5;

            //txtFindCopy
            txtFindCopy.Width = (copyToList.Width + btnCopyTo.Width) - btnCloseCopyList.Width;
            txtFindCopy.Top = btnCloseCopyList.Top;
            txtFindCopy.Left = btnCloseCopyList.Left + btnCloseCopyList.Width;
            txtFindCopy.Height = btnCloseCopyList.Height + 3;

            //CopyList
            CopyList.Width = (btnCloseCopyList.Width + txtFindCopy.Width);
            CopyList.Top = txtFindCopy.Top + txtFindCopy.Height;
            CopyList.Left = btnCloseCopyList.Left;
            CopyList.Height = 100;

            btnCloseCopyList.Hide();
            txtFindCopy.Hide();
            CopyList.Hide();
            //------------------------------------------------------------

            MessageList.Top = groupBox3.Top + groupBox3.Height + groupBox1.Height + 10;
            MessageList.Left = groupBox3.Left;
            MessageList.Width = groupBox3.Width;
            MessageList.Height = this.Height - (groupBox1.Height + groupBox3.Height + 130);
            MessageList.BackColor = ArchiveSettings.Default.ListColor;

            //-------------------------------------------------------
            btnClear.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Show();
            btnSave.Enabled = false;
            btnUpdate.Hide();

            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            WindowState = FormWindowState.Maximized;

            this.Show();
            ViewMessagesAsync(StaticParametrs.OrgnaizationUser);
            //List<BaseUser> users;

            users = _dataContext.SystemUsers.FromSqlRaw("sp_show_system_users {0}"
             , StaticParametrs.OrgnaizationUser.Id).ToList();

            users = users.OrderBy(x => x.ResponsibilityCode).ToList();

            MessageSender.DataSource = users;
            MessageSender.DisplayMember = "JobtypeName";
            MessageSender.ValueMember = "Id";

            foreach (var user in users)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                CopyList.Items.Add(listViewItem);
            }

            DocList.View = View.Details;
            MessageList.View = View.Details;
            CopyList.View = View.Details;
            copyToList.View = View.Details;

            //MessageSerialNumber.Text = GetLastSerialNumber();
            MessageSerialNumber.ReadOnly = true;
            pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";
            var ReciptDescription = "";
            var SenderDescription = "";
            var vali = CheckValidation();
            if (vali)
            {

                SystemUser SinderUser = new SystemUser();
                SystemUser ReciptUser = new SystemUser();

                if (outbox.Checked == true) // message type =0 ... form lisco to outside صادر

                {
                    SinderUser = users.FirstOrDefault(c => c.Id.ToString() == MessageSender.SelectedValue.ToString());

                    ReciptUser = users.FirstOrDefault(c => c.FileNumber == StaticParametrs.OrgnaizationUser.FileNumber);

                    ReciptDescription = txtOrg.Text;
                    SenderDescription = SinderUser.JobtypeName;

                }
                else if (Inbox.Checked == true) //message type =1  form outside to lisco  وارد
                {

                    ReciptUser = users.FirstOrDefault(c => c.Id.ToString() == MessageSender.SelectedValue.ToString());

                    SinderUser = users.FirstOrDefault(c => c.FileNumber == StaticParametrs.OrgnaizationUser.FileNumber);

                    SenderDescription = txtOrg.Text;
                    ReciptDescription = ReciptUser.JobtypeName;
                }

                Message Message = new Core.Entities.Message();
                Message.Id = Guid.NewGuid();
                Message.SerialNumber = MessageSerialNumber.Text.Trim();
                Message.Title = MessageSubject.Text.Trim();
                Message.Body = MessageSubject.Text.Trim();
                Message.SenderDiscription = SenderDescription;
                Message.ResponsibilityCode = SinderUser.ResponsibilityCode;
                Message.CreatedBy = StaticParametrs.CurrentUser;
                Message.CreatedById = StaticParametrs.CurrentUser.Id;
                Message.LastUpdatedBy = StaticParametrs.CurrentUser;
                Message.LastUpdatedById = StaticParametrs.CurrentUser.Id;
                //Message.SenderId = SinderUser.Id.ToString();
                Message.Sender = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.FileNumber == SinderUser.FileNumber);
                Message.IsArchived = true;
                Message.IsDeleted = false;
                Message.Sent = true;
                Message.IsOrigin = true;
                Message.SendingDateTime = SendDate.Value;
                if (outbox.Checked == true)
                {
                    Message.MessageType = MessageType.Export;
                }
                else if (Inbox.Checked == true)
                {
                    Message.MessageType = MessageType.Inport;
                }
                Message.IsForeign = true;

                // }

                List<Package> packages = new List<Package>();
                Package package = new Package
                {
                    Recipint = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.FileNumber == ReciptUser.FileNumber),
                    ResponsibilityCode = ReciptUser.ResponsibilityCode,
                    RecipintId = ReciptUser.Id.ToString(),
                    RecipintDiscription = ReciptDescription,
                    DesignationId = ReciptUser.DesignationId,
                    CreatedBy = StaticParametrs.CurrentUser,
                    CreatedById = StaticParametrs.CurrentUser.Id,
                    Message = Message,
                };
                packages.Add(package);

                if (copyToList.Items.Count > 0) //&& txtMessageId.Text==""
                {
                    foreach (ListViewItem itemRow in copyToList.Items)
                    {

                        SystemUser Recipt = new SystemUser();
                        Recipt = users.FirstOrDefault(c => c.Id.ToString() == itemRow.SubItems[0].Text);

                        if (Recipt != null)
                        {
                            Package CopyPackage = new Package
                            {
                                ResponsibilityCode = Recipt.ResponsibilityCode,
                                RecipintId = Recipt.Id.ToString(),
                                RecipintDiscription = Recipt.FullName + " - " + Recipt.JobtypeName,
                                DesignationId = Recipt.DesignationId,
                                CreatedBy = StaticParametrs.CurrentUser,
                                CreatedOn = DateTime.Now,
                                CreatedById = StaticParametrs.CurrentUser.Id,
                                IsCC = true
                            };
                            packages.Add(CopyPackage);

                        }


                    }

                }

                List<Doc> docs = new List<Doc>();
                foreach (ListViewItem itemRow in this.DocList.Items)
                {
                    Doc doc = new Doc
                    {
                        Name = itemRow.SubItems[1].Text,
                        //  Path = itemRow.SubItems[4].Text,
                        Extention = itemRow.SubItems[2].Text,
                        Size = Convert.ToInt32(itemRow.SubItems[3].Text),
                        LastUpdatedBy = StaticParametrs.CurrentUser,
                        LastUpdatedById = StaticParametrs.CurrentUser.Id,
                        LastUpdatedOn = DateTime.Now,
                        CreatedBy = StaticParametrs.CurrentUser,
                        CreatedById = StaticParametrs.CurrentUser.Id,
                        ResponsibilityCode = SinderUser.ResponsibilityCode,
                        Id = Guid.Parse(itemRow.SubItems[0].Text),
                        Message = Message
                    };
                    docs.Add(doc);


                }

                // save files on the server 

                try
                {
                    string[] txtFiles = Directory.GetFiles(FilePath);
                    using (new ConnectToSharedFolder(networkPath, credentials))
                    {
                        foreach (var item in txtFiles)
                        {
                            File.Move(item, Path.Combine(networkPath, Path.GetFileName(item)));
                            File.Delete(item);

                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }

                Message.Packages = packages;
                Message.Documents = docs;

                RemoveTempMessage();

                _dataContext.Messages.Add(Message);
                _dataContext.SaveChanges();

              

                if (Inbox.Checked == true)
                {

                    DialogResult dialogResult = MessageBox.Show("تم تخزين البيانات بنجاح ... هل تريد طباعة بطاقة إجراءات", "معلومة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        PrintFollowCard();
                    }
                }

                else
                {
                    MessageBox.Show("تم تخزين البيانات بنجاح ", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MessageList.Items.Clear();
                ClearForm();
                ViewMessagesAsync(StaticParametrs.OrgnaizationUser);
            }

            btnClear.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Hide();

        }

        void AddTempMessage()
        {
            if (outbox.Checked == true)
            {
                labComeFrom.Text = "صادر من";
                MessageSerialNumber.Text = GetLastSerialNumber();

                MessageSerialNumber.ReadOnly = true;

            }

            else if (Inbox.Checked == true)
            {
                labComeFrom.Text = "وارد إلى";
                MessageSerialNumber.Text = GetLastSerialNumberInport();

                MessageSerialNumber.ReadOnly = true;

            }

            var message = new Core.Entities.Message();
            {
                txtMessageId.Text = Guid.NewGuid().ToString();
                message.Id = Guid.Parse(txtMessageId.Text.Trim().ToString());

                message.SerialNumber = MessageSerialNumber.Text.Trim();
                message.CreatedBy = StaticParametrs.CurrentUser;
                message.Sender = StaticParametrs.CurrentUser;
                message.IsArchived = false;
                message.Sent = false;
                message.IsDeleted = true;
                message.IsOrigin = true;
                message.SendingDateTime = SendDate.Value;
                if (outbox.Checked == true)
                {
                    message.MessageType = MessageType.Export;
                }
                else if (Inbox.Checked == true)
                {
                    message.MessageType = MessageType.Inport;
                }
                message.IsForeign = true;
            }

            message.Packages = null;
            message.Documents = null;

            _dataContext.Messages.Add(message);
            _dataContext.SaveChanges();

        }

        void RemoveTempMessage()
        {
            //Message TempMessage = new Core.Entities.Message();
            var TempMessage = _dataContext.Messages
              .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()) && m.IsDeleted==true);
            if (TempMessage != null)
            {
                _dataContext.Messages.Remove(TempMessage);
            }
            
        }
        public void SelectFile()
        {

            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bnp; *.pdf) | *.jpg; *.jpeg; *.gif; *.bnp; *.pdf";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    var uniqeFilename = Guid.NewGuid().ToString();
                    var FileExt = Path.GetExtension(open.FileName);
                    var FileSize = (int)new FileInfo(open.FileName).Length;
                    var paht = open.FileName.ToString();
                    var name = (string)new FileInfo(open.FileName).Name;

                    string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";

                    if (FileExt == ".pdf")
                    {
                        string FileName = Path.Combine(FilePath, uniqeFilename + ".PDF");
                        pdfViewerControl1.Show();
                        pdfViewerControl1.Load(open.FileName);
                        pdfViewerControl1.LoadedDocument.Save(FilePath + uniqeFilename + ".Pdf");

                    }
                    else
                    {
                        pdfViewerControl1.Hide();
                        picBox.Image = new Bitmap(open.FileName);
                        picBox.Image.Save(FilePath + uniqeFilename + ".JPEG", ImageFormat.Jpeg);
                        {
                            var PdfFileName = FilePath + uniqeFilename + ".Pdf";
                            var ImageFileName = FilePath + uniqeFilename + ".JPEG";
                            PdfHelper.Instance.SaveImageAsPdf(ImageFileName, PdfFileName, 1000, true);
                        }
                    }

                    // add file details to DocList
                    string[] row = { uniqeFilename, name, "PDF", FileSize.ToString(), paht };
                    var listViewItem = new ListViewItem(row);
                    DocList.Items.Add(listViewItem);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("عفواً... النظام لا يدعم هذا النوع من الملفات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                throw;
            }

        }

        private void MessageSerialNumber_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {

                MessageSubject.Focus();
            }
        }

        private void MessageSubject_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                MessageSender.Focus();
            }
        }

        private void MessageSender_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                txtOrg.Focus();
            }
        }

        private void txtOrg_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                SendDate.Focus();
            }
        }

        private void SendDate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSelectFile.Focus();
            }
        }

        private void btnSelectFile_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // openFileDialog1.ShowDialog();
            }
        }

        private void btnScanFile_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                //btnScanFile_Click().;
            }
        }


        public void ViewMessagesAsync(BaseUser OrgUser)
        {
            var messages = _dataContext.Messages.Where(x => x.IsDeleted == false && x.IsForeign == true && x.CreatedOn.AddDays(7) >= DateTime.Now && x.CreatedById == StaticParametrs.CurrentUser.Id).Include("Packages");
            messages = messages.OrderByDescending(x => x.CreatedOn);

            MessageList.Items.Clear();

            foreach (var message in messages)
            {
                string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.Packages.Select(p => p.RecipintDiscription).FirstOrDefault() };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }

        }

        public void ViewMessageDetails()
        {
            txtMessageId.Text = MessageList.SelectedItems[0].Text.Trim().ToString();

            var message = _dataContext.Messages.Include("Documents").Include("Sender").Include("Packages")
                .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()));

            var Recipt = message.Packages.Where(p => p.IsCC == false).FirstOrDefault();
            var ReciptDescription = message.Packages.Select(p => p.RecipintDiscription).FirstOrDefault();

            if (message.MessageType == MessageType.Export)
            {
                MessageSender.SelectedValue = message.Sender.Id;
                txtOrg.Text = ReciptDescription;
                outbox.Checked = true;
            }
            else
            {
                MessageSender.SelectedValue = Recipt.RecipintId;
                //MessageSender.SelectedItem = Recipt.Id;
                txtOrg.Text = message.SenderDiscription;
                Inbox.Checked = true;
            }

            // fill message cc recipts
            var CCRecipt = message.Packages.Where(p => p.IsCC == true);
            foreach (var package in CCRecipt)
            {
                string[] row = { package.RecipintId.ToString(), package.RecipintDiscription };
                var listViewItem = new ListViewItem(row);
                copyToList.Items.Add(listViewItem);
            }

            MessageSerialNumber.Text = message.SerialNumber;
            MessageSubject.Text = message.Title;
            SendDate.Value = message.SendingDateTime;

            DocList.Items.Clear();
            picBox.Image = null;
            foreach (var item in message.Documents)
            {
                //picBox.Image = new Bitmap(@item.Path);
                string[] row = { item.Id.ToString(), item.Name, item.Extention, item.Size.ToString(), item.Path };
                var listViewItem = new ListViewItem(row);
                DocList.Items.Add(listViewItem);

            }

        }

        public void DeletMessage()
        {
            var MessageId = MessageList.FocusedItem.Text;
            if (MessageId != null)
            {
                var message = _dataContext.Messages.FirstOrDefault(x => x.Id == Guid.Parse(MessageId.Trim().ToString()));
                _dataContext.Remove(message);
                _dataContext.SaveChanges();
                //_messageServices.DeleteMessageFromDrafts(message);

                MessageBox.Show("تم حذف البيانات بنجاح", "معلومة", MessageBoxButtons.OK);

                // _dataContext.Messages.Remove(message);
            }

        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            DeletMessage();
            MessageList.Items.Clear();
            DocList.Items.Clear();
            ClearForm();
            ViewMessagesAsync(StaticParametrs.OrgnaizationUser);

        }

        private void DeleteDocMenu_MouseClick(object sender, MouseEventArgs e)
        {
            DocList.FocusedItem.Remove();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearForm()
        {
            //btnClear.Enabled = true;
            txtMessageId.Text = null;
            MessageSerialNumber.Text = null;
            MessageSubject.Text = null;
            MessageSender.Text = null;
            txtOrg.Text = null;
            SendDate.Value = DateTime.Now;
            outbox.Checked = true;

            //MessageSerialNumber.Text = GetLastSerialNumber();

            picBox.Image = null;
            DocList.Items.Clear();
            pdfViewerControl1.Hide();
            picBox.Image = null;
            picBox.Show();
            copyToList.Items.Clear();
            btnCloseCopyList.Hide();
            txtFindCopy.Hide();
            CopyList.Hide();

            MessageSender.DataSource = users;
            MessageSender.DisplayMember = "JobtypeName";
            MessageSender.ValueMember = "Id";

        }

        public bool CheckValidation()
        {
            if (MessageSerialNumber.Text.Trim() == "")
            {
                MessageBox.Show("أدخل الرقم الإشاري للرسالة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageSerialNumber.Focus();
                return false;

            }

            else if (MessageSubject.Text.Trim() == "")
            {
                MessageBox.Show("أدخل موضوع الرسالة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageSubject.Focus();
                return false;
            }

            else if (txtOrg.Text.Trim() == "")
            {
                MessageBox.Show("أدخل الجهة  المرسل إليها أو المستلم منها الرسالة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrg.Focus();
                return false;
            }

            else if (MessageSender.Text.Trim() == "")
            {
                MessageBox.Show("اختر التقسيم الإداري المرسل إليه أو المستلم منه الرسالة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageSender.Focus();
                return false;
            }

            else if (DocList.Items.Count == 0)
            {
                MessageBox.Show("اختر الرسالة المرفقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else { return true; };

        }

        public string GetLastSerialNumber()
        {
            var ResponsibilityCode = StaticParametrs.CurrentUser.ResponsibilityCode;

            var SerailNumbers = _dataContext.Messages.Where(m => m.CreatedOn.Year == DateTime.Now.Year && m.SerialNumber.Substring(5, 5) == ResponsibilityCode && m.SerialNumber != null && m.IsForeign == true && m.MessageType == MessageType.Export && m.SerialNumber.Length == 16).OrderByDescending(x => x.CreatedOn).Select(x => x.SerialNumber.Substring(11, 5)).ToList();

            int temp;
            int SN = 0;
            if (SerailNumbers.Count > 0)
            {
                SN = SerailNumbers.Select(n => int.TryParse(n, out temp) ? temp : 0).Max();

            }
            SN = SN + 1;
            var SerailNumber = (DateTime.Now.ToString("yy") + "/" + "1" + "-" + ResponsibilityCode + "-" + SN.ToString("00000"));

            return SerailNumber;
        }

        public string GetLastSerialNumberInport()
        {
            var ResponsibilityCode = StaticParametrs.CurrentUser.ResponsibilityCode;

            var SerailNumbers = _dataContext.Messages.Where(m => m.CreatedOn.Year == DateTime.Now.Year && m.SerialNumber.Substring(5, 5) == ResponsibilityCode && m.SerialNumber != null && m.IsForeign == true && m.MessageType == MessageType.Inport && m.SerialNumber.Length == 16).OrderByDescending(x => x.CreatedOn).Select(x => x.SerialNumber.Substring(11, 5)).ToList();

            int temp;
            int SN = 0;
            if (SerailNumbers.Count > 0)
            {
                SN = SerailNumbers.Select(n => int.TryParse(n, out temp) ? temp : 0).Max();

            }
            SN = SN + 1;
            var SerailNumber = (DateTime.Now.ToString("yy") + "/" + "2" + "-" + ResponsibilityCode + "-" + SN.ToString("00000"));

            return SerailNumber;

            //var sn = (DateTime.Now.ToString("yy") + "/" + "2" + "-" +
            //       StaticParametrs.CurrentUser.ResponsibilityCode + "-" +
            //       (_dataContext.Messages.Where(m => m.CreatedOn.Year == DateTime.Now.Year && m.IsForeign == true && m.MessageType == MessageType.Inport && m.IsDeleted == false && m.SerialNumber.Substring(5, 5) == StaticParametrs.CurrentUser.ResponsibilityCode).Count() + 1).ToString("00000"));
            //return sn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(_dataContext, _OldDataContext);
            search.Show();
        }

        private static string StripHTML(string input)
        {
            if (input != null)
            {
                string result = Regex.Replace(input, "<[a-zA-Z/].*?>", String.Empty);
                result = Regex.Replace(result, "&nbsp;", String.Empty);
                return result;
            }
            else
            {
                return "";
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SelectFile();

        }

        private void btnScanFile_Click(object sender, EventArgs e)
        {
            try
            {
                //get list of devices available
                List<string> devices = WIAScanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }
                //check if device is not available
                if (lbDevices.Items.Count == 0)
                {
                    MessageBox.Show("لايوجد أي جهاز ماسح متصل بهذا الكمبيوتر ");

                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                }

                //get images from scanner
                List<Image> images = WIAScanner.Scan((string)lbDevices.SelectedItem);
                if (images.Count > 0)
                {
                    List<string> docs = new List<string>();
                    var FileSize = 0;

                    try
                    {

                        //string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";
                        string FilePath = @"D:\ASC Project\ACS.Archives\ScanFiles\";
                        foreach (Image image in images)
                        {

                            var uniqeFilename = Guid.NewGuid().ToString();
                            FileSize += image.Height;

                            image.Save(FilePath + uniqeFilename + ".JPEG", ImageFormat.Jpeg);
                            {
                                var PdfFileName = FilePath + uniqeFilename + ".Pdf";
                                var ImageFileName = FilePath + uniqeFilename + ".JPEG";
                                PdfHelper.Instance.SaveImageAsPdf(ImageFileName, PdfFileName, 1000, true);
                            }

                            docs.Add(uniqeFilename);

                        }

                        string fileName = CustomPDFMergeAndStamp(docs, StaticParametrs.CurrentUser.FileNumber);

                        //string fileName = CustomPDFMergeAndStamp(docs.Select(r => r.Name.ToString()).ToList(), StaticParametrs.CurrentUser.FileNumber);
                        string FilePaht = @"D:\ASC Project\ACS.Archives\TempFiles\" + fileName + ".pdf";
                        picBox.Hide();
                        pdfViewerControl1.Show();
                        pdfViewerControl1.Load(FilePaht);
                        pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

                        //DocList.Items.Clear();
                        string[] row = { fileName, MessageSubject.Text + (DocList.Items.Count + 1).ToString(), "PDF", FileSize.ToString(), FilePath, "false" };
                        var listViewItem = new ListViewItem(row);
                        DocList.Items.Add(listViewItem);

                    }

                    //========================================================
                    catch (Exception)
                    {
                        MessageBox.Show("عفواً... النظام لا يدعم هذا النوع من الملفات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        throw;
                    }

                }



            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void outbox_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMessageId.Text.Trim() != "" && txtMessageId.Text.Trim() != null)
            {
                var TempMessage = _dataContext.Messages
              .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()) && m.IsDeleted == true);
                if (TempMessage != null)
                {
                    _dataContext.Messages.Remove(TempMessage);
                    _dataContext.SaveChangesAsync();
                }

            }

            txtMessageId.Text = null;
            MessageSerialNumber.Text = null;
            btnClear.Enabled = true;

            labComeFrom.Text = "صادر من";
            //AddTempMessage();
        }

        private void Inbox_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMessageId.Text.Trim() != "" && txtMessageId.Text.Trim() != null)
            {
                var TempMessage = _dataContext.Messages
              .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()) && m.IsDeleted == true);
                if (TempMessage != null)
                {
                    _dataContext.Messages.Remove(TempMessage);
                    _dataContext.SaveChangesAsync();
                }

            }

            txtMessageId.Text = null;
            MessageSerialNumber.Text = null;
            btnClear.Enabled = true;

            labComeFrom.Text = "وارد إلى";
            //AddTempMessage();

        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            if (MessageSubject.Text.Trim() == "" || txtOrg.Text.Trim() == "")
            {
                MessageBox.Show("اختر الرسالة التي تريد طباعة بطاقة إجراء لها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                PrintFollowCard();
            }

            btnSave.Show();
            btnUpdate.Hide();
            btnClear.Enabled = true;
            btnCancel.Enabled = false;
        }

        public void PrintFollowCard()
        {


            string fullPath = "D:\\ASC Project\\ACS.Archives\\CardTemplate.docx";
            WordDocument document = new WordDocument(fullPath);

            //WordDocument document = new WordDocument(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\CardTemplate.docx");

            document.Replace("1111111111111111111111111", MessageSerialNumber.Text, true, true);
            document.Replace("2", StaticParametrs.CurrentUser.FileNumber, true, true);
            document.Replace("3", DateTime.Now.Date.ToString(), true, true);
            document.Replace("4444444444444444444444444", MessageSubject.Text, true, true);
            document.Replace("5", txtOrg.Text, true, true);
            document.Replace("6", MessageSender.Text, true, true);
            document.Replace("7", SendDate.Value.ToString("dd/MM/yyyy"), true, true);
            document.Save(@"D:\DocCard.docx", FormatType.Docx);

            document.Open(fullPath);
            //document.Open(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\CardTemplate.docx");

            //Create an instance of DocToPDFConverter
            DocToPDFConverter converter = new DocToPDFConverter();
            //Convert Word document into PDF document
            PdfDocument pdfDocument = converter.ConvertToPDF(@"D:\DocCard.docx");
            //Save the PDF file
            pdfDocument.Save(@"D:\PDFCard.pdf");
            //Close the instance of document objects
            pdfDocument.Close(true);
            document.Close();

            followCard followForm = new followCard();
            followForm.Show();

            ClearForm();
            btnCard.Enabled = false;
        }

        private string PDFMergeAndStamp(List<string> FilesNames, string UserFileNumber)
        {
            List<object> dobj = new List<object>();
            string FilesPath = @"D:\ASC Project\ACS.Archives\TempFiles\";

            foreach (var fileName in FilesNames)
            {
                string FilePaht = FilesPath + fileName + ".PDF";
                FileStream file = new FileStream(FilePaht, FileMode.Open, FileAccess.Read);

                PdfDocument document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfBitmap image = new PdfBitmap(file);
                graphics.DrawImage(image, new System.Drawing.PointF(0, 0), new System.Drawing.SizeF(page.Size.Width, page.Size.Height));
                MemoryStream Stream2 = new MemoryStream();
                document.Save(Stream2);
                Stream2.Position = 0;
                document.Close(true);
                PdfLoadedDocument PdfDoc = new PdfLoadedDocument(Stream2);

                dobj.Add(PdfDoc);
                file.Close();

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

            //var TempName = $@"\[{ Guid.NewGuid()}]" + ".pdf";
            var TempName = Guid.NewGuid().ToString();
            using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\TempFiles\" + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            return TempName;
        }

        private void MessageSender_TextUpdate(object sender, EventArgs e)
        {
            string filter_param = MessageSender.Text;

            List<SystemUser> filteredItems = users.Where(x => x.JobCatId == 1 && x.JobtypeName.Contains(filter_param)).ToList();

            // another variant for filtering using StartsWith:
            // List<string> filteredItems = arrProjectList.FindAll(x => x.StartsWith(filter_param));

            MessageSender.DataSource = filteredItems;

            if (String.IsNullOrWhiteSpace(filter_param))
            {
                MessageSender.DataSource = users;
            }
            MessageSender.DroppedDown = true;

            // this will ensure that the drop down is as long as the list
            MessageSender.IntegralHeight = true;

            // remove automatically selected first item
            MessageSender.SelectedIndex = -1;

            MessageSender.Text = filter_param;

            // set the position of the cursor
            MessageSender.SelectionStart = filter_param.Length;
            MessageSender.SelectionLength = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm SearchForm = new SearchForm(_dataContext, _OldDataContext);

            SearchForm.Width = this.Width - 250;
            SearchForm.Height = this.Height - 200;
            SearchForm.StartPosition = FormStartPosition.CenterParent;

            SearchForm.ShowDialog(this);
        }

        private void btnCopyTo_Click(object sender, EventArgs e)
        {
            btnCloseCopyList.Show();
            txtFindCopy.Show();
            CopyList.Show();
        }

        private void btnCloseCopyList_Click(object sender, EventArgs e)
        {
            btnCloseCopyList.Hide();
            txtFindCopy.Hide();
            CopyList.Hide();
        }

        private void deleteCopyMenu_Click(object sender, EventArgs e)
        {
            copyToList.FocusedItem.Remove();

        }

        private string CustomPDFMergeAndStamp(List<string> FilesNames, string UserFileNumber)
        {
            PdfDocument FinalDoc = new PdfDocument();

            //  add  message docs to FinalDoc
            //string FilesPath = @"D:\ASC Project\ACS.Archives\TempFiles\";

            string FilesPath = @"D:\ASC Project\ACS.Archives\ScanFiles\";
            foreach (var fileName in FilesNames)
            {
                string FilePaht = Path.Combine(FilesPath, fileName + ".PDF");
                if (File.Exists(FilePaht))
                {
                    FileStream file = new FileStream(FilePaht, FileMode.Open, FileAccess.Read);
                    PdfLoadedDocument doc = new PdfLoadedDocument(file);
                    FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);

                    //File.Delete(FilePaht);
                }

            }

            // //Stamping
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            Syncfusion.Pdf.Graphics.PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 180f);
            foreach (PdfPageBase lPage in FinalDoc.Pages)
            {
                PdfGraphics graphics = lPage.Graphics;
                PdfGraphicsState state = graphics.Save();
                graphics.SetTransparency(0.25f);
                graphics.RotateTransform(-40);
                //graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, -50, 100);
                graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, 110, 250);
                graphics.SetTransparency(0.15f);
                graphics.DrawString(UserFileNumber, font2, PdfBrushes.Blue, -250, 300);
                graphics.Restore(state);
            }

            //Saving
            MemoryStream stream = new MemoryStream();
            FinalDoc.Save(stream);
            stream.Position = 0;
            FinalDoc.Close(true);
            var FileId = Guid.NewGuid().ToString();
            var TempFileName = FileId + ".pdf";
            using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\TempFiles\" + TempFileName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            return FileId;

        }

        private void txtFindCopy_TextChanged(object sender, EventArgs e)
        {
            CopyList.Items.Clear();

            List<SystemUser> filter = users.Where(x => x.JobtypeName.Contains(txtFindCopy.Text) || x.FullName.Contains(txtFindCopy.Text)).OrderBy(x => x.ResponsibilityCode).ToList();

            foreach (var user in filter)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                CopyList.Items.Add(listViewItem);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AddTempMessage();
            btnClear.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Show();
            btnUpdate.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Message TempMessage = new Core.Entities.Message();
            if (txtMessageId.Text.Trim() !="" && txtMessageId.Text.Trim()!=null)
            {
                var TempMessage = _dataContext.Messages
              .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()) && m.IsDeleted == true);
                if (TempMessage != null)
                {
                    _dataContext.Messages.Remove(TempMessage);
                    _dataContext.SaveChangesAsync();
                }

            }
            
            ClearForm();
            btnClear.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Show();
            btnUpdate.Hide();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var ReciptDescription = "";
            var SenderDescription = "";
            var vali = CheckValidation();
            if (vali)
            {

                // BaseUser SinderUser = new BaseUser();
                SystemUser SinderUser = new SystemUser();
                SystemUser ReciptUser = new SystemUser();

                if (outbox.Checked == true) // message type =0 ... form lisco to outside صادر

                {
                    SinderUser = users.FirstOrDefault(c => c.Id.ToString() == MessageSender.SelectedValue.ToString());

                    ReciptUser = users.FirstOrDefault(c => c.FileNumber == StaticParametrs.OrgnaizationUser.FileNumber);

                    ReciptDescription = txtOrg.Text;
                    SenderDescription = SinderUser.JobtypeName;

                }
                else if (Inbox.Checked == true) // message type =1 form outside to lisco  وارد
                {
                    ReciptUser = users.FirstOrDefault(c => c.Id.ToString() == MessageSender.SelectedValue.ToString());

                    SinderUser = users.FirstOrDefault(c => c.FileNumber == StaticParametrs.OrgnaizationUser.FileNumber);

                    SenderDescription = txtOrg.Text;
                    ReciptDescription = ReciptUser.JobtypeName;
                }

                var MessageModify = _dataContext.Messages.Include("Documents").Include("Sender").Include("Packages")
               .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()));

                List<Package> packages = new List<Package>();
                Package package = new Package
                {
                    Recipint = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.FileNumber == ReciptUser.FileNumber),
                    ResponsibilityCode = ReciptUser.ResponsibilityCode,
                    RecipintId = ReciptUser.Id.ToString(),
                    RecipintDiscription = ReciptDescription,
                    DesignationId = ReciptUser.DesignationId,
                    CreatedBy = StaticParametrs.CurrentUser,
                    CreatedById = StaticParametrs.CurrentUser.Id,
                    Message = MessageModify,
                };
                packages.Add(package);

                if (copyToList.Items.Count > 0) //&& txtMessageId.Text==""
                {
                    foreach (ListViewItem itemRow in copyToList.Items)
                    {

                        SystemUser Recipt = new SystemUser();
                        Recipt = users.FirstOrDefault(c => c.Id.ToString() == itemRow.SubItems[0].Text);

                        if (Recipt != null)
                        {
                            Package CopyPackage = new Package
                            {
                                ResponsibilityCode = Recipt.ResponsibilityCode,
                                RecipintId = Recipt.Id.ToString(),
                                RecipintDiscription = Recipt.FullName + " - " + Recipt.JobtypeName,
                                DesignationId = Recipt.DesignationId,
                                CreatedBy = StaticParametrs.CurrentUser,
                                CreatedOn = DateTime.Now,
                                CreatedById = StaticParametrs.CurrentUser.Id,
                                IsCC = true
                            };
                            packages.Add(CopyPackage);

                        }


                    }

                }
                MessageModify.SerialNumber = MessageSerialNumber.Text.Trim();
                MessageModify.Title = MessageSubject.Text.Trim();
                MessageModify.Body = MessageSubject.Text.Trim();
                MessageModify.SenderDiscription = SenderDescription;
                MessageModify.ResponsibilityCode = SinderUser.ResponsibilityCode;
                MessageModify.CreatedBy = StaticParametrs.CurrentUser;
                MessageModify.CreatedById = StaticParametrs.CurrentUser.Id;
                MessageModify.LastUpdatedBy = StaticParametrs.CurrentUser;
                MessageModify.LastUpdatedById = StaticParametrs.CurrentUser.Id;
                MessageModify.LastUpdatedOn = DateTime.Now;
                MessageModify.Sender = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.FileNumber == SinderUser.FileNumber);
                MessageModify.IsArchived = true;
                MessageModify.IsDeleted = false;
                MessageModify.Sent = true;
                MessageModify.IsOrigin = true;
                MessageModify.SendingDateTime = SendDate.Value;
                if (outbox.Checked == true)
                {
                    MessageModify.MessageType = MessageType.Export;
                }
                else if (Inbox.Checked == true)
                {
                    MessageModify.MessageType = MessageType.Inport;
                }
                MessageModify.IsForeign = true;

                MessageModify.Packages = packages;

                _dataContext.Update(MessageModify);
                _dataContext.SaveChangesAsync();


                //if (Inbox.Checked == true)
                //{

                //    DialogResult dialogResult = MessageBox.Show("تم تخزين البيانات بنجاح ... هل تريد طباعة بطاقة إجراءات", "معلومة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (dialogResult == DialogResult.Yes)
                //    {
                //        PrintFollowCard();
                //    }
                //}



                //else
                //{
                    MessageBox.Show("تم تخزين البيانات بنجاح ", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // }
                MessageList.Items.Clear();
                ClearForm();
                ViewMessagesAsync(StaticParametrs.OrgnaizationUser);


                btnSave.Show();
                btnUpdate.Hide();

            }

            btnClear.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Hide();
        }
    }
}
