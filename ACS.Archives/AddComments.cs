using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.DataAccess;
using ACS.Web.Providers;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
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
using System.Text;
using System.Windows.Forms;


namespace ACS.Archives
{
    public partial class AddComments : Form

    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;
        private readonly string _messageId;
        private readonly string _messageType;
        private MessageDetailsForm _detiForm;
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
        public AddComments(DataContext dataContext
            , OldSysDBContext OldDataContext
            , string MessageId
            , string MessageType
            , MessageDetailsForm detiForm)
        {
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;
            _messageId = MessageId;
           _messageType = MessageType;
            _detiForm = detiForm;
            InitializeComponent();

            copyToList.MouseClick += new MouseEventHandler(copyToList_MouseClick);
            CopyList.MouseDoubleClick += new MouseEventHandler(CopyList_MouseDoubleClick);

            UsersList.MouseDoubleClick += new MouseEventHandler(UsersList_MouseDoubleClick);

            Reciptes.MouseClick += new MouseEventHandler(Reciptes_MouseClick);

            DocList.MouseClick += new MouseEventHandler(DocList_MouseClick);
        }

        private void AddComments_Load(object sender, EventArgs e)
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
           
            try
            {


                pdfViewerControl1.Hide();
                pdfViewerControl1.ToolbarSettings.OpenButton.IsVisible = false;

                picBox.Top = 5;
                picBox.Left = 5;
                picBox.Width = (this.Width / 2) - (this.Width / 12);
                picBox.Height = (this.Height)- (this.Height/6);

                pdfViewerControl1.Width = picBox.Width;
                pdfViewerControl1.Top = picBox.Top;
                pdfViewerControl1.Left = picBox.Left;
                pdfViewerControl1.Height = picBox.Height;

                // group box4------------------------------------------------
                groupBox4.Top = picBox.Top + picBox.Height + 5;
                groupBox4.Left = picBox.Left;
                groupBox4.Width = picBox.Width;
                groupBox4.Height = this.Height - (picBox.Height + (this.Height / 12) );

                sendMessage.Top = 10;
                sendMessage.Left = groupBox4.Width / 4 ;
                sendMessage.Height = (groupBox4.Height / 4)*3;
                sendMessage.Width = groupBox4.Width / 2 ;

                //----------------------------------------------------------------

                groupBox1.Top = picBox.Top;
                groupBox1.Left = picBox.Left + picBox.Width + 5;
                groupBox1.Width = (this.Width / 2) + (this.Width / 15);
                groupBox1.Height = (this.Height / 3) + (this.Height / 12);

                //send as 
                SendAs.Left = 10;
                SendAs.Width = (groupBox1.Width / 3) ;
                SendAs.Top = 30;
                SendAs.Height = groupBox1.Height / 6;

                // send as lab
                labSendAs.Left = SendAs.Left + SendAs.Width + 10;
                labSendAs.Height = 40;
                labSendAs.Top = SendAs.Top;

                //reciptes  Reciptes
                copyToList.Left = 10;
                copyToList.Width = SendAs.Width;
                copyToList.Top = SendAs.Top + SendAs.Height + 20;
                copyToList.Height = groupBox1.Height/3;

                // btnAddUsers
                btnCopyTo.Left = copyToList.Left + copyToList.Width;
                btnCopyTo.Height = copyToList.Height + 3;
                btnCopyTo.Width = groupBox1.Width / 8;
                btnCopyTo.Top = copyToList.Top;

                // btnClose
                btnCloseCopyList.Left = copyToList.Left;
                btnCloseCopyList.Height = 40;
                btnCloseCopyList.Width = 40;
                btnCloseCopyList.Top = copyToList.Top + copyToList.Height + 3;

                //txtSearch
                txtFindCopy.Width = (copyToList.Width + btnAddUsers.Width) ;
                txtFindCopy.Top = btnCloseCopyList.Top;
                txtFindCopy.Left = copyToList.Left + btnCloseCopyList.Left;
                txtFindCopy.Height = btnCloseCopyList.Height;

                //UsersList
                CopyList.Width = (copyToList.Width + btnCopyTo.Width);
                CopyList.Top = txtFindCopy.Top + txtFindCopy.Height;
                CopyList.Left = btnCloseCopyList.Left;
                CopyList.Height = copyToList.Height + 50;

                //============================================================
                //txt mesage no
                txtMessageNo.Left = btnCopyTo.Left + btnCopyTo.Width + 30;
                txtMessageNo.Width = groupBox1.Width / 3;
                    //groupBox1.Width - (copyToList.Width + (btnCopyTo.Width * 3)) + 35;
                txtMessageNo.Top = SendAs.Top;
                txtMessageNo.Height = SendAs.Height;

                //labMesNo
                labMesNo.Top = txtMessageNo.Top;
                labMesNo.Height = txtMessageNo.Height;
                labMesNo.Left = txtMessageNo.Left + txtMessageNo.Width + 10;

                // cc list
                Reciptes.Left = txtMessageNo.Left;
                Reciptes.Width = copyToList.Width;
                Reciptes.Top = copyToList.Top ;
                Reciptes.Height = copyToList.Height;

    
                btnAddUsers.Left = Reciptes.Left + Reciptes.Width; ;
                btnAddUsers.Height = btnCopyTo.Height;
                btnAddUsers.Width = btnCopyTo.Width;
                btnAddUsers.Top = btnCopyTo.Top;

                btnClose.Left = Reciptes.Left;
                btnClose.Height = 40;
                btnClose.Width = 40;
                btnClose.Top = Reciptes.Top + Reciptes.Height + 3;

    
                txtSearch.Width = (Reciptes.Width + btnAddUsers.Width) - btnClose.Width;
                txtSearch.Top = btnClose.Top;
                txtSearch.Left =  btnClose.Left + btnClose.Width;
                txtSearch.Height = btnClose.Height;

                //CopyList
                UsersList.Width = txtSearch.Width + btnClose.Width;
                UsersList.Top = txtSearch.Top + txtSearch.Height;
                UsersList.Left = btnClose.Left;
                UsersList.Height = Reciptes.Height + 50;
                //======================================================================


                // group box3------------------------------------------------
                groupBox3.Top = groupBox1.Top + groupBox1.Height + 5;
                groupBox3.Left = groupBox1.Left;
                groupBox3.Width = groupBox1.Width;
                groupBox3.Height = groupBox1.Height/2;

                rdDocComment.Left = groupBox3.Width / 2;
                rdTextComment.Left = rdDocComment.Left + rdDocComment.Width + 50;

                btnSelectFile.Top = rdTextComment.Top+ rdTextComment.Height+10;
                btnSelectFile.Left = (groupBox3.Width / 4) - 20;
                btnSelectFile.Width = groupBox3.Width / 4;
                btnSelectFile.Height = groupBox3.Height /4;

                btnScanFile.Top = btnSelectFile.Top;
                btnScanFile.Left = btnSelectFile.Left + btnSelectFile.Width + 40;
                btnScanFile.Width = btnSelectFile.Width;
                btnScanFile.Height = btnSelectFile.Height;

               
                txtComment.Top = btnSelectFile.Top;
                txtComment.Left = btnSelectFile.Left;
                txtComment.Width = (groupBox3.Width / 4)*3;
                txtComment.Height = groupBox3.Height / 3;

                addAttchFile.Top = btnScanFile.Top + btnScanFile.Height + 30;
                addAttchFile.Left = btnScanFile.Left + btnScanFile.Width + 60;
                addAttchFile.Width = txtComment.Width/3;
                addAttchFile.Height = groupBox3.Height / 5;

                //----------------------------------------
                DocList.Top = groupBox3.Top + groupBox3.Height + 5;
                DocList.Left = groupBox3.Left;
                DocList.Width = groupBox3.Width;
                DocList.Height = this.Height - (groupBox1.Height + groupBox3.Height + (groupBox3.Height/2)-25);

                DocList.BackColor = ArchiveSettings.Default.ListColor;
                //============================================================
                this.Show();

                txtSearch.Hide();
                UsersList.Hide();
                btnClose.Hide();

                btnCloseCopyList.Hide();
                txtFindCopy.Hide();
                CopyList.Hide();

                if (StaticParametrs.CurrentUser.Discriminator == "SubApplicationUser")
                {
                    MainUser = _dataContext.Users.Where(x => x is ApplicationUser && x.JobCatId == 1 && x.JobStatus == "AE" && (x.ResponsibilityCode == StaticParametrs.CurrentUser.ResponsibilityCode)).OrderBy(x => x.ResponsibilityCode).FirstOrDefault();
                }
                else
                {
                    MainUser = _dataContext.Users.Where(x => x is ApplicationUser && x.JobStatus == "AE" && x.Id == StaticParametrs.CurrentUser.Id).FirstOrDefault();
                }

                //MainUser = _dataContext.Users.Where(x => x is ApplicationUser && x.JobCatId == 1 && x.JobStatus == "AE" && (x.ResponsibilityCode == StaticParametrs.CurrentUser.ResponsibilityCode)).OrderBy(x => x.ResponsibilityCode).FirstOrDefault();

                SystemUsersList = _dataContext.SystemUsers.FromSqlRaw("sp_show_system_users {0}"
              , MainUser.Id).ToList();

                List<SystemUser> SenderTypes;

                if (StaticParametrs.CurrentUser.Discriminator != "SubApplicationUser")
                {
                    SenderTypes = SystemUsersList.Where(x => x.FileNumber == StaticParametrs.CurrentUser.FileNumber).OrderBy(x => x.ResponsibilityCode).ToList();

                }
                else
                {
                    SenderTypes = SystemUsersList.Where(x => x.FileNumber == MainUser.FileNumber).OrderBy(x => x.ResponsibilityCode).ToList();

                }
               
                SendAs.DataSource = SenderTypes;
                SendAs.DisplayMember = "JobtypeName";
                SendAs.ValueMember = "Id";


                //GetMessageNumber(MainUser.ResponsibilityCode, MainUser.DesignationId);

                if (MainUser.JobCatId != 1 && MainUser.ResponsibilityCode.Substring(0, 2) != "49")
                {
                    ReciptesUsers = SystemUsersList.Where(x => x.Id.ToString() != MainUser.Id && x.ResponsibilityCode == MainUser.ResponsibilityCode).OrderBy(x => x.ResponsibilityCode).ToList();
                }
                else
                {
                    ReciptesUsers = SystemUsersList.Where(x => x.Id.ToString() != MainUser.Id).OrderBy(x => x.ResponsibilityCode).ToList();
                }

                //ReciptesUsers = SystemUsersList.Where(x => x.Id.ToString() != MainUser.Id).OrderBy(x => x.ResponsibilityCode).ToList();

                foreach (var user in ReciptesUsers)
                {
                    string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                    var listViewItem = new ListViewItem(row);
                    UsersList.Items.Add(listViewItem);
                }

                foreach (var user in ReciptesUsers)
                {
                    string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                    var listViewItem = new ListViewItem(row);
                    CopyList.Items.Add(listViewItem);
                }

                txtMessageId.Text = _messageId;
                var message = _dataContext.Messages.Include("Documents").Include("Sender").Include("Packages")
                   .FirstOrDefault(m => m.Id == Guid.Parse(txtMessageId.Text.Trim().ToString()));

                if (message.OriginMessageId != null)
                {
                    txtMessageId.Text = message.OriginMessageId.ToString();
                }


                var count = _dataContext.Messages.Count(m => m.OriginMessageId == txtMessageId.Text) + 1;

                if (message.SerialNumber != null && message.SerialNumber !="")
                {
                    txtMessageNo.Text = message.SerialNumber + "." + count.ToString("00");
                }
               
                txtMessageSubject.Text = "تأشيرة على : " +  message.Title;

                DocList.View = View.Details;
                Reciptes.View = View.Details;
                UsersList.View = View.Details;
                CopyList.View = View.Details;
                copyToList.View = View.Details;
            }


            catch (Exception)
            {
                throw ;

            }

        }

        private async void UsersList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var UseId = UsersList.SelectedItems[0].Text.Trim().ToString();
            var UserJob = UsersList.SelectedItems[0].SubItems[2].Text.Trim().ToString();

            string[] row = { UseId, UserJob };
            var listViewItem = new ListViewItem(row);

            Reciptes.Items.Add(listViewItem);
        }

        private void Reciptes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeleteReciptMenu.Show();
            }
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

        public bool CheckValidation()
        {

            if (SendAs.Text.Trim() == "")
            {
                MessageBox.Show("اختر صفة المرسل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SendAs.Focus();
                return false;
            }

            else if (DocList.Items.Count == 0 && txtComment.Text=="")
            {
                MessageBox.Show("أدخل نص التأشيرة أو أضف تأشيرة ورقية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else { return true; };

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
                    var name = (string)new FileInfo(open.FileName).Name;

                    var paht = open.FileName.ToString();

                    string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";


                    if (FileExt == ".pdf")
                    {
                        picBox.Hide();
                        string FileName = Path.Combine(FilePath, uniqeFilename + ".PDF");
                        pdfViewerControl1.Show();
                        pdfViewerControl1.Load(open.FileName);
                        pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;
                        pdfViewerControl1.LoadedDocument.Save(FilePath + uniqeFilename + ".Pdf");

                    }
                    else
                    {
                        pdfViewerControl1.Hide();
                        picBox.Show();
                        picBox.Image = new Bitmap(open.FileName);
                        picBox.Image.Save(FilePath + uniqeFilename + ".JPEG", ImageFormat.Jpeg);
                        {
                            var PdfFileName = FilePath + uniqeFilename + ".Pdf";
                            var ImageFileName = FilePath + uniqeFilename + ".JPEG";
                            PdfHelper.Instance.SaveImageAsPdf(ImageFileName, PdfFileName, 1000, true);
                        }
                    }

                    // add file details to DocList
                    string[] row = { uniqeFilename, name, FileExt, FileSize.ToString(), paht,"false" };
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

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            //copyToList.Hide();
            //btnCopyTo.Hide();

            txtSearch.Show();
            UsersList.Show();
            btnClose.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtSearch.Hide();
            UsersList.Hide();
            btnClose.Hide();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UsersList.Items.Clear();

            List<SystemUser> filter = ReciptesUsers.Where(x => x.JobtypeName.Contains(txtSearch.Text) || x.FullName.Contains(txtSearch.Text)).OrderBy(x => x.ResponsibilityCode).ToList();

            foreach (var user in filter)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                UsersList.Items.Add(listViewItem);
            }
        }

        private void DeleteReciptMenu_MouseClick(object sender, MouseEventArgs e)
        {
            Reciptes.FocusedItem.Remove();
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
                        string FilePaht = @"D:\ASC Project\ACS.Archives\TempFiles\" + fileName + ".pdf";
                        picBox.Hide();
                        pdfViewerControl1.Show();
                        pdfViewerControl1.Load(FilePaht);
                        pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

                        string[] row = { fileName, txtMessageSubject.Text + (DocList.Items.Count + 1).ToString(), "PDF", FileSize.ToString(), FilePath, "false" };
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

        private void sendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";
                var vali = CheckValidation();
                if (vali)
                {

                    BaseUser SinderUser = new BaseUser();

                    List<Package> packages = new List<Package>();
                    if (Reciptes.Items.Count > 0)
                    {
                        foreach (ListViewItem itemRow in Reciptes.Items)
                        {
                            SystemUser Recipt = new SystemUser();
                            Recipt = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == itemRow.SubItems[0].Text);

                            Package package = new Package
                            {
                                Recipint = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.FileNumber == Recipt.FileNumber),
                                ResponsibilityCode = Recipt.ResponsibilityCode,
                                RecipintId = Recipt.Id.ToString(),
                                RecipintDiscription = Recipt.FullName + " - " +     Recipt.JobtypeName,
                                DesignationId = Recipt.DesignationId,
                                CreatedBy = StaticParametrs.CurrentUser,
                                IsCC = false
                            };
                            packages.Add(package);

                        }

                    }

                    if (copyToList.Items.Count > 0)
                    {
                        foreach (ListViewItem itemRow in copyToList.Items)
                        {
                            SystemUser Recipt = new SystemUser();
                            Recipt = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == itemRow.SubItems[0].Text);
                            Package package = new Package
                            {
                                Recipint = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.FileNumber == Recipt.FileNumber),
                                ResponsibilityCode = Recipt.ResponsibilityCode,
                                RecipintId = Recipt.Id.ToString(),
                                RecipintDiscription = Recipt.FullName + " - " + Recipt.JobtypeName,
                                DesignationId = Recipt.DesignationId,
                                CreatedBy = StaticParametrs.CurrentUser,
                                IsCC = true
                            };
                            packages.Add(package);

                        }

                    }

                    SystemUser UserSender = new SystemUser();
                    UserSender = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == SendAs.SelectedValue.ToString());

                    var message = new Core.Entities.Message();
                    {
                        message.SerialNumber = txtMessageNo.Text;
                        message.Title = txtMessageSubject.Text;
                        message.OriginMessageId = txtMessageId.Text.Trim();
                        message.Body = txtComment.Text;
                        message.SenderDiscription = UserSender.JobtypeName;
                        message.ResponsibilityCode = UserSender.ResponsibilityCode;
                        message.CreatedBy = StaticParametrs.CurrentUser;
                        message.CreatedById = StaticParametrs.CurrentUser.Id;
                        message.LastUpdatedBy = StaticParametrs.CurrentUser;
                        message.LastUpdatedById = StaticParametrs.CurrentUser.Id;
                        message.Sender = (ApplicationUser)_dataContext.Users.FirstOrDefault(c => c.FileNumber == UserSender.FileNumber);
                        message.IsArchived = false;
                        message.IsDeleted = false;
                        message.Sent = true;
                        message.IsOrigin = false;
                        message.IsForeign = false;
                        message.SendingDateTime = DateTime.Now;
                        message.DesignationId = UserSender.DesignationId;
                    }

                    List<Doc> docs = new List<Doc>();
                    if (DocList.Items.Count > 0)
                    {
                        foreach (ListViewItem itemRow in this.DocList.Items)
                        {
                            var isTempFile = false;

                            if (itemRow.SubItems[5].Text != "" && itemRow.SubItems[5].Text == "true")
                            {
                                isTempFile = true;
                            }

                            Doc doc = new Doc
                            {
                                Name = itemRow.SubItems[1].Text,
                                Extention = itemRow.SubItems[2].Text,
                                Size = Convert.ToInt32(itemRow.SubItems[3].Text),
                                LastUpdatedBy = StaticParametrs.CurrentUser,
                                LastUpdatedById = StaticParametrs.CurrentUser.Id,
                                LastUpdatedOn = DateTime.Now,
                                CreatedBy = StaticParametrs.CurrentUser,
                                CreatedById = StaticParametrs.CurrentUser.Id,
                                ResponsibilityCode = MainUser.ResponsibilityCode,
                                IsTemp = isTempFile,
                                Id = Guid.Parse(itemRow.SubItems[0].Text),
                                Message = message
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
                        catch (Exception exc)
                        {
                             MessageBox.Show(exc.Message);
                        }

                        // save attach files on the server 

                        string AttachFilesPath = @"D:\ASC Project\ACS.Archives\AttachTempFiles\";
                        string networkTempPath = @"\\10.10.102.16\TempAttach";
                        try
                        {
                            string[] txtFiles = Directory.GetFiles(AttachFilesPath);
                            using (new ConnectToSharedFolder(networkTempPath, credentials))
                            {
                                foreach (var item in txtFiles)
                                {
                                    File.Move(item, Path.Combine(networkTempPath, Path.GetFileName(item)));
                                    File.Delete(item);
                                }
                            }


                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }

                    }

                    message.Packages = packages;
                    message.Documents = docs;

                    _dataContext.Messages.Add(message);
                    _dataContext.SaveChanges();

                    // make packge as replyed
                    if (_messageType == "Inbox")
                    {
                        var OrgnaizationsResponsibilityCodes = _dataContext.Organizations.Where(m => m.DelegateNo == MainUser.FileNumber && DateTime.Now <= m.EndDate && m.IsDeleted == false).Select(d => d.ResponsibilityCode).ToList();

                        var messages = _dataContext.Messages.Include("Packages").Where(m => m.Id.ToString() == _messageId || m.OriginMessageId == _messageId);
                        foreach (var mes in messages)
                        {

                            var packs = mes.Packages.Where(a => a.RecipintId == MainUser.Id || (a.ResponsibilityCode == MainUser.ResponsibilityCode && a.DesignationId == MainUser.DesignationId) || OrgnaizationsResponsibilityCodes.Contains(a.ResponsibilityCode)).ToList();

                            if (packs != null || packs.Count() > 0)
                            {
                                foreach (var pac in packs)
                                {

                                    {
                                        pac.LastUpdatedBy =StaticParametrs.CurrentUser;
                                    pac.LastUpdatedById=StaticParametrs.CurrentUser.Id;
                                        pac.LastUpdatedOn = DateTime.Now;
                                        pac.IsReplyed = true;
                                        _dataContext.Packages.Update(pac);
                                        _dataContext.SaveChangesAsync();
                                    }

                                }

                            }
                        }
                    }

                    // add to notification 

                    var notification = new Notification();
                    {
                        notification.MessageId= txtMessageId.Text;
                        notification.MessageType = _messageType;
                        notification.CreatedOn = DateTime.Now;
                        notification.CreatedById = MainUser.Id;
                        _dataContext.Notifications.Add(notification);
                        _dataContext.SaveChanges();

                    }

                    MessageBox.Show("تمت عملية الإرسال بنجاح ", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                   // ClearTempFolders();
                    ClearForm();
                    this.Close();

                    _detiForm.GetMessageDocs(_messageId);
                    //_detiForm.Show();

                }

            }
            catch (Exception)
            {

                throw;
            }
           
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

        private void txtFindCopy_TextChanged(object sender, EventArgs e)
        {
            CopyList.Items.Clear();

            List<SystemUser> filter = ReciptesUsers.Where(x => x.JobtypeName.Contains(txtFindCopy.Text) || x.FullName.Contains(txtFindCopy.Text)).OrderBy(x => x.ResponsibilityCode).ToList();

            foreach (var user in filter)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                CopyList.Items.Add(listViewItem);
            }
        }

        private void deleteCopyMenu_MouseClick(object sender, MouseEventArgs e)
        {
            copyToList.FocusedItem.Remove();
        }

        private void rdDocComment_CheckedChanged(object sender, EventArgs e)
        {
            txtComment.Text = null;
            pdfViewerControl1.Unload();
            picBox.Image = null;
            DocList.Items.Clear();

            if (rdDocComment.Checked==true)
            {
                txtComment.Hide();
                btnScanFile.Show();
                btnSelectFile.Show();

            }
            else
            {
                
                btnScanFile.Hide();
                btnSelectFile.Hide();
                txtComment.Show();

            }
        }

        private void rdTextComment_CheckedChanged(object sender, EventArgs e)
        {
            txtComment.Text = null;
            pdfViewerControl1.Unload();
            picBox.Image = null;

            if (rdTextComment.Checked == true)
            {
                
                btnScanFile.Hide();
                btnSelectFile.Hide();
                txtComment.Show();
                
            }
            else
            {
                txtComment.Hide();
                btnScanFile.Show();
                btnSelectFile.Show();
               
            }
        }

        private void addAttchFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                //open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bnp; *.pdf) | *.jpg; *.jpeg; *.gif; *.bnp; *.pdf";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    var uniqeFilename = Guid.NewGuid().ToString();
                    var FileExt = Path.GetExtension(open.FileName);
                    if (FileExt.StartsWith("."))
                    {
                        FileExt = FileExt.Remove(0, 1);
                    }
                    var FileSize = (int)new FileInfo(open.FileName).Length;
                    var name = (string)new FileInfo(open.FileName).Name;

                    var paht = open.FileName.ToString();

                    var temppath = @"D:\ASC Project\ACS.Archives\AttachTempFiles\";

                    var copyToPath = Path.Combine(temppath, uniqeFilename + "." + FileExt);

                    if (File.Exists(copyToPath))
                    {
                        File.Delete(copyToPath);
                    }
                    System.IO.File.Copy(paht, copyToPath);


                    // add file details to DocList
                    string[] row = { uniqeFilename, name, FileExt, FileSize.ToString(), paht, "true" };
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

        private void DocList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeleteDocMenu.Show();
            }

        }

        private void DeleteDocMenu_Click(object sender, EventArgs e)
        {
            DocList.FocusedItem.Remove();
        }

        public void ClearForm()
        {
            txtMessageId.Text = null;
            txtMessageSubject.Text = null;
            txtMessageNo.Text = null;
            txtComment.Text = null;
            txtSearch.Text = null;
            picBox.Image = null;
            DocList.Items.Clear();
            Reciptes.Items.Clear();
            copyToList.Items.Clear();
            pdfViewerControl1.Hide();
            picBox.Image = null;
            picBox.Show();

        }

        private string CustomPDFMergeAndStamp(List<string> FilesNames, string UserFileNumber)
        {
            PdfDocument FinalDoc = new PdfDocument();

            //  add  message docs to FinalDoc
            //string FilesPath = @"D:\ASC Project\ACS.Archives\TempFiles\";

            string FilesPath = @"D:\ASC Project\ACS.Archives\ScanFiles\"; // new path
            foreach (var fileName in FilesNames)
            {
                string FilePaht = Path.Combine(FilesPath, fileName + ".PDF");
                FileStream file = new FileStream(FilePaht, FileMode.Open, FileAccess.Read);
                PdfLoadedDocument doc = new PdfLoadedDocument(file);
                FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);
            }

            //Stamping
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

        private void ClearTempFolders()
        {
            string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";
            string AttachFilesPath = @"D:\ASC Project\ACS.Archives\AttachTempFiles\";

            try
            {
                // delete temp files

                DirectoryInfo dir = new DirectoryInfo(FilePath);
                IEnumerable<FileInfo> Files = dir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (var item in Files)
                {
                    item.Delete();
                }

                // delete temp attch files

                DirectoryInfo Tempdir = new DirectoryInfo(AttachFilesPath);
                IEnumerable<FileInfo> TempFiles = Tempdir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (var item in TempFiles)
                {
                    item.Delete();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SendAs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var SenderAs = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == SendAs.SelectedValue.ToString());
           // GetMessageNumber(SenderAs.ResponsibilityCode, SenderAs.DesignationId);

            if (MainUser.JobCatId != 1 && SenderAs.ResponsibilityCode.Substring(0, 2) != "49")
            {
                ReciptesUsers = SystemUsersList.Where(x => x.Id.ToString() != MainUser.Id && x.ResponsibilityCode == MainUser.ResponsibilityCode).OrderBy(x => x.ResponsibilityCode).ToList();
            }
            else
            {
                ReciptesUsers = SystemUsersList.Where(x => x.Id.ToString() != MainUser.Id).OrderBy(x => x.ResponsibilityCode).ToList();
            }

            UsersList.Items.Clear();
            CopyList.Items.Clear();

            foreach (var user in ReciptesUsers)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                UsersList.Items.Add(listViewItem);
                //CopyList.Items.Add(listViewItem);
            }

            foreach (var user in ReciptesUsers)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                CopyList.Items.Add(listViewItem);
            }
        }
    }
}
