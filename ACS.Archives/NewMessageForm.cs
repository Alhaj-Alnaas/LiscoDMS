using System;
using System.Collections.Generic;
using System.Data;
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.DataAccess;
using ACS.Web.Providers;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using Syncfusion.Windows.Forms.PdfViewer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Globalization;

namespace ACS.Archives
{
    public partial class NewMessageForm : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;
        private ArchiveMainScreen _mainForm;

        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");

        public BaseUser MainUser;
        public List<SystemUser> SystemUsersList;
        public List<SystemUser> ReciptesUsers;
        public string myNetworkPath = string.Empty;

        public static object WIA_DPS_DOCUMENT_HANDLING_SELECT { get; private set; }
        public static object WIA_PROPERTIES { get; private set; }
        public static object WIA_DPS_DOCUMENT_HANDLING_STATUS { get; private set; }
        public NewMessageForm(
             DataContext dataContext
            , OldSysDBContext OldDataContext
            , ArchiveMainScreen mainForm

             )
        {
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;
            _mainForm = mainForm;

            InitializeComponent();

            copyToList.MouseClick += new MouseEventHandler(copyToList_MouseClick);
            CopyList.MouseDoubleClick += new MouseEventHandler(CopyList_MouseDoubleClick);

            UsersList.MouseDoubleClick += new MouseEventHandler(UsersList_MouseDoubleClick);
            Reciptes.MouseClick += new MouseEventHandler(Reciptes_MouseClick);

            DocList.MouseClick += new MouseEventHandler(DocList_MouseClick);
        }

        private void NewMessageForm_Load(object sender, EventArgs e)
        {
            txtDateAgr.Text = DateTime.Now.ToString("dd/MM/yyy");
            txtDateHij.Text = ConvertDateCalendar(DateTime.Now, "Hijri", "en-US");
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
            groupBox1.Text = "";
            pdfViewerControl1.Hide();
            pdfViewerControl1.ToolbarSettings.OpenButton.IsVisible = false;

            picBox.Width = (this.Width / 2) - 60;
            picBox.Top = 5;
            picBox.Left = 5;
            picBox.Height = ((this.Height / 6) * 5) + 10;

            pdfViewerControl1.Width = picBox.Width;
            pdfViewerControl1.Top = picBox.Top;
            pdfViewerControl1.Left = picBox.Left;
            pdfViewerControl1.Height = picBox.Height;

            panel3.Top = picBox.Top + picBox.Height + 5;
            panel3.Left = picBox.Left;
            panel3.Width = picBox.Width;
            panel3.Height = picBox.Height / 10;

            btnSave.Left = (panel3.Width / 4);
            btnSave.Top = 10;
            btnSave.Width = panel3.Width / 2;
            btnSave.Height = panel3.Height - 20;

            //----------------------------------------------------------------
            sendType.Top = picBox.Top;
            sendType.Left = picBox.Left + picBox.Width + 5;
            sendType.Width = (this.Width / 2) + 25;
            sendType.Height = this.Height / 12;

            groupBox1.Top = sendType.Top + sendType.Height + 5;
            groupBox1.Left = sendType.Left;
            groupBox1.Width = sendType.Width;
            groupBox1.Height = picBox.Height / 2; //(this.Height / 3);//+ (this.Height / 10);

            //reciptes
            Reciptes.Top = 10;
            Reciptes.Left = 10; 
            Reciptes.Width = (groupBox1.Width / 3) + (groupBox1.Width / 17);
            Reciptes.Height = (groupBox1.Height / 3)+ (groupBox1.Height / 10); //80

            // btnAddUsers
            btnAddUsers.Left = Reciptes.Left + Reciptes.Width;
            btnAddUsers.Height = Reciptes.Height + 3;
            btnAddUsers.Width = groupBox1.Width / 9; //100
            btnAddUsers.Top = Reciptes.Top;

            // copy to list
            copyToList.Left = Reciptes.Left;
            copyToList.Width = Reciptes.Width;
            copyToList.Top = Reciptes.Top + Reciptes.Height + 10;
            copyToList.Height = (groupBox1.Height / 4);

            // btnCopyTo
            btnCopyTo.Left = btnAddUsers.Left;
            btnCopyTo.Height = copyToList.Height+3;
            btnCopyTo.Width = btnAddUsers.Width;
            btnCopyTo.Top = copyToList.Top;

            // btnclose
            btnClose.Left = Reciptes.Left;
            btnClose.Height = 40;
            btnClose.Width = 40;
            btnClose.Top = Reciptes.Top + Reciptes.Height + 5;

            //txtSearch
            txtSearch.Width = (Reciptes.Width + btnAddUsers.Width) - 10;
            txtSearch.Top = btnClose.Top;
            txtSearch.Left = Reciptes.Left + btnClose.Left;
            txtSearch.Height = btnClose.Height;

            //userlist
            UsersList.Width = (Reciptes.Width + btnAddUsers.Width);
            UsersList.Top = txtSearch.Top + txtSearch.Height;
            UsersList.Left = btnClose.Left;
            UsersList.Height = Reciptes.Height + 50;
            //====================================================
            // btnCloseCopyList
            btnCloseCopyList.Left = copyToList.Left;
            btnCloseCopyList.Height = 40;
            btnCloseCopyList.Width = 40;
            btnCloseCopyList.Top = Reciptes.Top;//copyToList.Top + copyToList.Height + 5;

            //txtFindCopy
            txtFindCopy.Width = (copyToList.Width + btnCopyTo.Width) - 10;
            txtFindCopy.Top = btnCloseCopyList.Top;
            txtFindCopy.Left = copyToList.Left + btnCloseCopyList.Left;
            txtFindCopy.Height = btnCloseCopyList.Height;

            //CopyList
            CopyList.Width = UsersList.Width;
            CopyList.Top = txtFindCopy.Top + txtFindCopy.Height;
            CopyList.Left = btnCloseCopyList.Left;
            CopyList.Height = Reciptes.Height- txtFindCopy.Left; //copyToList.Height + 50;
            //==========================================================

            //txt mesage no
            txtMessageNo.Left = btnAddUsers.Left + btnAddUsers.Width + 30;
            txtMessageNo.Width = groupBox1.Width - (Reciptes.Width + (btnAddUsers.Width * 3)) + 30;
            txtMessageNo.Top = btnAddUsers.Top;
            txtMessageNo.Height = txtSearch.Height;

            //labMesNo
            labMesNo.Top = txtMessageNo.Top;
            labMesNo.Height = txtMessageNo.Height;
            labMesNo.Left = txtMessageNo.Left + txtMessageNo.Width + 10;
            //==================================================
            //txt date agr
            txtDateAgr.Width = txtMessageNo.Width;
            txtDateAgr.Top = txtMessageNo.Top + txtMessageNo.Height + 10;
            txtDateAgr.Left = txtMessageNo.Left;
            txtDateAgr.Height =  txtMessageNo.Height;

            // lab date agr
            labDateAg.Left = labMesNo.Left;
           // labDateAg.Width = labMesNo.Width;
            labDateAg.Top = txtDateAgr.Top;
            labDateAg.Height = txtDateAgr.Height;
            labDateAg.Left = txtDateAgr.Left+ txtDateAgr.Width+10;
            labDateAg.Text = "تاريخ ميلادي";

            //txt date Hijri
            txtDateHij.Width = txtMessageNo.Width;
            txtDateHij.Top = txtDateAgr.Top + txtDateAgr.Height + 10;
            txtDateHij.Left = txtDateAgr.Left;
            txtDateHij.Height = txtDateAgr.Height;

            // lab date Hijri
            labDateHij.Left = labMesNo.Left;
           // labDateHij.Width = labMesNo.Width;
            labDateHij.Top = txtDateHij.Top;
            labDateHij.Height = labMesNo.Height;
            labDateHij.Text = "تاريخ هجري";
          
            //==================================================

            //txtMessageSubject
            txtMessageSubject.Multiline = true;
            txtMessageSubject.Width = txtMessageNo.Width;
            txtMessageSubject.Top = txtDateHij.Top + txtDateHij.Height + 10;
            txtMessageSubject.Left = txtMessageNo.Left;
            txtMessageSubject.Height = Reciptes.Height - txtDateHij.Height;

            // labMesgSub
            labMesgSub.Left = labMesNo.Left;
            labMesgSub.Width = labMesNo.Width;
            labMesgSub.Top = txtMessageSubject.Top;
            labMesgSub.Height = txtMessageSubject.Height;

            //SENDER
            MessageSender.Left = txtMessageNo.Left;
            MessageSender.Width = txtMessageNo.Width;
            MessageSender.Top = txtMessageSubject.Top + txtMessageSubject.Height + 10;
           
            //lab sender
            labSender.Left = labMesNo.Left;
            //labMesNo.Width = labMesgSub.Width;
            labSender.Top = MessageSender.Top;
            labSender.Height = labMesNo.Height;

            //txt days to reply
            txtReplyDays.Left = txtMessageNo.Left;
            txtReplyDays.Width = txtMessageNo.Width/2;
            txtReplyDays.Top = MessageSender.Top + MessageSender.Height + 10;
            txtReplyDays.Value=0;

            //lab days to reply
            labReplyDays.Left = txtReplyDays.Left+ txtReplyDays.Width+5;
            labReplyDays.Width = txtReplyDays.Width+ labMesNo.Width;
            labReplyDays.Top = txtReplyDays.Top;
            labReplyDays.Text = "عدد الأيام المتوقعة للرد";
            // labReplyDays.Height = labMesNo.Height;

            // group box3------------------------------------------------
            groupBox3.Top = groupBox1.Top + groupBox1.Height + 5;
            groupBox3.Left = groupBox1.Left;
            groupBox3.Width = groupBox1.Width;
            groupBox3.Height = (groupBox1.Height / 3);// - 20; //150;

            //btnSelectFile.Top = 10;
            btnSelectFile.Left = groupBox3.Width / 4;
            btnSelectFile.Width = groupBox3.Width / 4;
            btnSelectFile.Height = 40;

            btnScanFile.Top = btnSelectFile.Top;
            btnScanFile.Left = btnSelectFile.Left + btnSelectFile.Width + 40;
            btnScanFile.Width = btnSelectFile.Width;
            btnScanFile.Height = btnSelectFile.Height;


            addAttchFile.Top = btnScanFile.Top + btnScanFile.Height + 20;
            addAttchFile.Left = btnScanFile.Left + btnScanFile.Width + 60;
            addAttchFile.Width = 60;
            addAttchFile.Height = 30;
            //----------------------------------------
            DocList.Top = groupBox3.Top + groupBox3.Height + 5;
            DocList.Left = groupBox3.Left;
            DocList.Width = groupBox3.Width;
            DocList.Height = this.Height - (sendType.Height + groupBox1.Height + groupBox3.Height + 80);

            DocList.BackColor = ArchiveSettings.Default.ListColor;
            this.Show();
            //==========================================================
            rdSpecific.Checked = true;
            btnAddUsers.Enabled = true;
            btnCopyTo.Enabled = true;

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

           
            SystemUsersList = _dataContext.SystemUsers.FromSqlRaw("sp_show_system_users {0}"
            , MainUser.Id).ToList();

            // List<BaseUser> users;
            List<SystemUser> SenderTypes;
            if (StaticParametrs.CurrentUser.Discriminator != "SubApplicationUser")
            {
                SenderTypes = SystemUsersList.Where(x => x.FileNumber == StaticParametrs.CurrentUser.FileNumber).OrderBy(x => x.ResponsibilityCode).ToList();

            }
            else
            {
                SenderTypes = SystemUsersList.Where(x => x.FileNumber == MainUser.FileNumber).OrderBy(x => x.ResponsibilityCode).ToList();

            }


            MessageSender.DataSource = SenderTypes;
            MessageSender.DisplayMember = "JobtypeName";
            MessageSender.ValueMember = "Id";


            GetMessageNumber(MainUser.ResponsibilityCode, MainUser.DesignationId);


            if (MainUser.JobCatId != 1 && MainUser.ResponsibilityCode.Substring(0,2)!="49")
            {
                ReciptesUsers = SystemUsersList.Where(x => x.Id.ToString() != MainUser.Id && x.ResponsibilityCode==MainUser.ResponsibilityCode).OrderBy(x => x.ResponsibilityCode).ToList();
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

            DocList.View = View.Details;

            Reciptes.View = View.Details;
            UsersList.View = View.Details;
            CopyList.View = View.Details;
            copyToList.View = View.Details;
        }

        private void DocList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeleteDocMenu.Show();
            }
        }

        //private async void DocList_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    var DocId = DocList.SelectedItems[0].Text.Trim().ToString();
        //    var DocName = DocList.SelectedItems[0].SubItems[1].Text.Trim().ToString();
        //    string FilePaht = "";

        //    picBox.Image = null;

        //    picBox.Hide();


        //    if (txtMessageId.Text.Trim() != "")

        //    {
        //        using (new ConnectToSharedFolder(networkPath, credentials))

        //        FilePaht = Path.Combine(networkPath, DocId + ".PDF");
        //    }

        //    else if (txtMessageId.Text.Trim() == "" && DocId != "")
        //    {
        //        FilePaht = Path.Combine(@"D:\ASC Project\ACS.Archives\TempFiles\", DocName + ".PDF");

        //    }

        //    pdfViewerControl1.Load(FilePaht);
        //    pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;
        //    pdfViewerControl1.Show();

        //}

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
                        picBox.Image = new Bitmap(open.FileName);
                        //picBox.Image.Save(FilePath + uniqeFilename + ".JPEG", ImageFormat.Jpeg);
                        {
                            var PdfFileName = FilePath + uniqeFilename + ".Pdf";
                            var ImageFileName = FilePath + uniqeFilename + ".JPEG";
                            PdfHelper.Instance.SaveImageAsPdf(ImageFileName, PdfFileName, 600, true);
                        }
                    }

                    // add file details to DocList
                    string[] row = { uniqeFilename, name, "PDF", FileSize.ToString(), paht, "false" };
                    var listViewItem = new ListViewItem(row);
                    DocList.Items.Add(listViewItem);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("عفواً... النظام لا يدعم هذا النوع من الملفات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //throw;
            }

        }

        private void MessageSubject_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                // MessageSender.Focus();
            }
        }

        public void ClearForm()
        {
            txtMessageId.Text = null;
            txtMessageSubject.Text = null;
            txtSearch.Text = null;
            picBox.Image = null;
            DocList.Items.Clear();
            Reciptes.Items.Clear();
            copyToList.Items.Clear();

            pdfViewerControl1.Unload();
            pdfViewerControl1.Hide();
            picBox.Image = null;
            picBox.Show();

        }

        public bool CheckValidation()
        {

            if (txtMessageNo.Text.Trim() == "")
            {
                MessageBox.Show("أدخل الرقم الإشاري للمراسلة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessageNo.Focus();
                return false;

            }

            else if (txtMessageSubject.Text.Trim() == "")
            {
                MessageBox.Show("أدخل موضوع المراسلة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessageSubject.Focus();
                return false;
            }

            else if (MessageSender.Text.Trim() == "")
            {
                MessageBox.Show("اختر صفة المرسل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageSender.Focus();
                return false;
            }

            else if (Reciptes.Items.Count == 0)
            {
                MessageBox.Show("اختر المرسل إليهم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";
            string AttachFilesPath = @"D:\ASC Project\ACS.Archives\AttachTempFiles\";
            var vali = CheckValidation();

          
            if (vali)
            {
               //var X = Reciptes.Items.Count;
                //BaseUser SinderUser = new BaseUser();

                List<Package> packages = new List<Package>();
                foreach (ListViewItem itemRow in Reciptes.Items)
                {
                    SystemUser Recipt = new SystemUser();
                    Recipt = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == itemRow.SubItems[0].Text);
                  
                    if (Recipt != null)
                    {
                        Package package = new Package
                        {
                            ResponsibilityCode = Recipt.ResponsibilityCode,
                            RecipintId = Recipt.Id.ToString(),
                            RecipintDiscription = Recipt.FullName + " - " + Recipt.JobtypeName,
                            DesignationId = Recipt.DesignationId,
                            CreatedBy = StaticParametrs.CurrentUser,
                            DaysToReplay =Convert.ToInt32(Math.Round(txtReplyDays.Value,0)),
                            IsCC = false
                        };
                        packages.Add(package);

                    }

                }

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

                var message = new Core.Entities.Message();
                SystemUser UserSender = new SystemUser();
                UserSender = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == MessageSender.SelectedValue.ToString());
               
                {

                    message.SerialNumber = txtMessageNo.Text.Trim();
                    message.Title = txtMessageSubject.Text.Trim();
                    message.OriginMessageId = null;
                    message.Body = txtMessageSubject.Text.Trim(); 
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
                    message.IsOrigin = true;
                    message.IsForeign = false;
                    message.SendingDateTime = DateTime.Now;
                    message.DesignationId = UserSender.DesignationId;

                }

                List<Doc> docs = new List<Doc>();
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
                            File.Move(item, Path.Combine(networkPath,      Path.GetFileName(item)));
                            File.Delete(item);
                        }
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message); 
                }

                // save attach files on the server 

                string networkTempPath = @"\\10.10.102.16\TempAttach";
                try
                {
                    string[] txtTemmFiles = Directory.GetFiles(AttachFilesPath);
                    using (new ConnectToSharedFolder(networkTempPath, credentials))
                    {
                        foreach (var item in txtTemmFiles)
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


                message.Packages = packages;
                message.Documents = docs;
                _dataContext.Messages.Add(message);
                _dataContext.SaveChanges();

                MessageBox.Show("تمت عملية الإرسال  بنجاح ", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
              
                _mainForm.ViewOutboxMessages(MainUser);
                this.Close();

                // new code 29.05.2023 =======================
                string ScanFilePath = @"D:\ASC Project\ACS.Archives\ScanFiles\";
                string[] ScanTemmFiles = Directory.GetFiles(ScanFilePath);

                {
                    foreach (var item in ScanTemmFiles)
                    {

                        File.Delete(item);
                    }
                }

                //==================================================
            }



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

                       // string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";

                        string FilePath = @"D:\ASC Project\ACS.Archives\ScanFiles\"; 

                        foreach (Image image in images)
                        {

                            var uniqeFilename = Guid.NewGuid().ToString();
                            FileSize += image.Height;

                            image.Save(FilePath + uniqeFilename + ".JPEG", ImageFormat.Jpeg);
                            {
                                var PdfFileName = FilePath + uniqeFilename + ".Pdf";
                                var ImageFileName = FilePath + uniqeFilename + ".JPEG";
                                PdfHelper.Instance.SaveImageAsPdf(ImageFileName,    PdfFileName, 600, true);
                            }
                            docs.Add(uniqeFilename);
                        }



                        string fileName = CustomPDFMergeAndStamp(docs, StaticParametrs.CurrentUser.FileNumber);
                        string FilePaht = @"D:\ASC Project\ACS.Archives\TempFiles\" + fileName + ".pdf";
                        pdfViewerControl1.Show();
                        pdfViewerControl1.Load(FilePaht);
                        pdfViewerControl1.ZoomMode = ZoomMode.FitWidth;

                        //DocList.Items.Clear(); stopprd on 7-5-2023
                        string[] row = { fileName, txtMessageSubject.Text + (DocList.Items.Count + 1).ToString(), "PDF", FileSize.ToString(), FilePath, "false" };
                        var listViewItem = new ListViewItem(row);
                        DocList.Items.Add(listViewItem);

                    }


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

        public void GetMessageNumber(string ResponsibilityCode, int DesignationId)
        {

            var SerailNumbers = _dataContext.Messages.Where(m => m.ResponsibilityCode == ResponsibilityCode &&( m.DesignationId == DesignationId || m.ResponsibilityCode=="43000") && m.Sent == true && m.SerialNumber != null && m.IsForeign == false && m.SerialNumber.Length == 13 && m.CreatedOn.Year == DateTime.Now.Year).OrderByDescending(x => x.CreatedOn).Select(x => x.SerialNumber.Substring(9, 4)).ToList();

            int temp;
            int SN = 0;
            if (SerailNumbers.Count > 0)
            {
                SN = SerailNumbers.Select(n => int.TryParse(n, out temp) ? temp : 0).Max();

            }
            SN = SN + 1;
            txtMessageNo.Text = (DateTime.Now.Year.ToString().Substring(2, 2) + "-" + ResponsibilityCode + "-" + SN.ToString("0000"));
        }

        public void PrintFollowCard()
        {
            WordDocument document = new WordDocument(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\CardTemplate.docx");
            document.Replace("1111111111111111111111111", txtMessageNo.Text, true, true);
            document.Replace("2", StaticParametrs.CurrentUser.FileNumber, true, true);
            document.Replace("3", DateTime.Now.Date.ToString(), true, true);
            document.Replace("4444444444444444444444444", txtMessageSubject.Text, true, true);
            document.Replace("5", MessageSender.Text, true, true);
            document.Replace("6", MessageSender.Text, true, true);
            document.Replace("7", DateTime.Now.ToString("0000-00-00"), true, true);
            document.Save(@"D:\DocCard.docx", FormatType.Docx);
            document.Open(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\CardTemplate.docx");

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

        }

        
        private void UsersList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DeleteReciptMenu.Show();
            }
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            copyToList.Hide();
            btnCopyTo.Hide();

            txtSearch.Show();
            UsersList.Show();
            btnClose.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtSearch.Hide();
            UsersList.Hide();
            btnClose.Hide();

            copyToList.Show();
            btnCopyTo.Show();
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

        private void DeleteReciptMenu_MouseClick_1(object sender, MouseEventArgs e)
        {
            Reciptes.FocusedItem.Remove();
        }

        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    ClearForm();
        //}

        private void btnCopyTo_Click(object sender, EventArgs e)
        {
            btnAddUsers.Hide();
            Reciptes.Hide();

            btnCloseCopyList.Show();
            txtFindCopy.Show();
            CopyList.Show();

        }

        private void btnCloseCopyList_Click(object sender, EventArgs e)
        {
            btnCloseCopyList.Hide();
            txtFindCopy.Hide();
            CopyList.Hide();

            btnAddUsers.Show();
            Reciptes.Show();

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

        private void deleteCopyMenu_Click(object sender, EventArgs e)
        {
            copyToList.FocusedItem.Remove();
        }

        private void addAttchFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    var FileExt = Path.GetExtension(open.FileName);
                    if (FileExt.StartsWith("."))
                    {
                        FileExt = FileExt.Remove(0, 1);
                    }

                    var FileSize = (int)new FileInfo(open.FileName).Length;
                    var name = (string)new FileInfo(open.FileName).Name;
                    var uniqeFilename = Guid.NewGuid().ToString();

                    var paht = open.FileName.ToString();

                    var temppath = @"D:\ASC Project\ACS.Archives\AttachTempFiles\";

                    var copyToPath = Path.Combine(temppath, uniqeFilename + "." + FileExt);

                    if (File.Exists(copyToPath))
                    {
                        File.Delete(copyToPath);
                    }
                    File.Copy(paht, copyToPath);
                    
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

        private void rdLowLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdLowLevel.Checked == true)
            {
                btnAddUsers.Enabled = false;
                btnCopyTo.Enabled = false;
                Reciptes.Items.Clear();

                 List<SystemUser> LowLevelUsers = GetLowLevelUsers(MainUser.DesignationId, MainUser.ResponsibilityCode);

                foreach (var user in LowLevelUsers)
                {
                    string[] row = { user.Id.ToString(), user.JobtypeName, user.FullName };
                    var listViewItem = new ListViewItem(row);
                    Reciptes.Items.Add(listViewItem);
                }

            }
        }

        private void rdSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSpecific.Checked == true)
            {
                btnAddUsers.Enabled = true;
                btnCopyTo.Enabled = true;

                Reciptes.Items.Clear();

            }
        }

        public List<SystemUser> GetLowLevelUsers(int designationId, string CurrRespCode)
        {
            
            if (CurrRespCode.Substring(0, 2) == "43")
            {
               return SystemUsersList.Where(x => x.JobCatId == 1 &&
                        (x.ResponsibilityCode.Substring(2, 3) == "000" && x.ResponsibilityCode != CurrRespCode)
                           ).ToList();
               // return LowLevelUsers;
            }
            else
            {
                switch (designationId)
                {
                    case 4:// Director Cases

                        return  SystemUsersList.Where(x =>  x.JobCatId == 1 && x.ResponsibilityCode != CurrRespCode
                        && (
                         // your departmen without general departmen
                         (x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3) && x.ResponsibilityCode.Substring(4, 1) == "0") ||
                            //your general department
                            (x.ResponsibilityCode.Substring(0, 2) == CurrRespCode.Substring(0, 2) && x.ResponsibilityCode.Substring(3, 2) == "00"))
                            ).ToList();
                    // return LowLevelUsers;

                    case 5: //general maneger Cases
                        return SystemUsersList.Where(x => x.JobCatId == 1 && x.ResponsibilityCode != CurrRespCode && (
                        //Your Departments
                        (x.ResponsibilityCode.Substring(4, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)) ||
                        // your sections  without  departments
                        (x.ResponsibilityCode.Substring(3, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)))).ToList();
                       // return LowLevelUsers;

                    case 6: // maneger cases
                        return SystemUsersList.Where(x => x.JobCatId == 1 && x.ResponsibilityCode != CurrRespCode && (
                         (x.ResponsibilityCode.Substring(0, 4) == CurrRespCode.Substring(0, 4))
                            )).ToList();
                       // return LowLevelUsers;

                    case 8:// Head of section cases
                        return SystemUsersList.Where(x => x.ResponsibilityCode == CurrRespCode).ToList();
                       // return LowLevelUsers;

                    default:
                        return SystemUsersList.Where(x => x.ResponsibilityCode == CurrRespCode).ToList();
                        // return LowLevelUsers;
                }
            }
        }

        private string CustomPDFMergeAndStamp(List<string> FilesNames, string UserFileNumber)
        {
            PdfDocument FinalDoc = new PdfDocument();

            //  add  message docs to FinalDoc
          
            // string FilesPath = @"D:\ASC Project\ACS.Archives\TempFiles\"; old path
            string FilesPath = @"D:\ASC Project\ACS.Archives\ScanFiles\"; // new path

            //using (new ConnectToSharedFolder(networkPath, credentials)) ;
            foreach (var fileName in FilesNames)
            {
                string FilePaht = Path.Combine(FilesPath, fileName + ".PDF");
                FileStream file = new FileStream(FilePaht, FileMode.Open, FileAccess.Read);
                PdfLoadedDocument doc = new PdfLoadedDocument(file);
                FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);

               // File.Delete(FilePaht);

            }

            // //Stamping
            Syncfusion.Pdf.Graphics.PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            Syncfusion.Pdf.Graphics.PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 180f);
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
            var FileId = Guid.NewGuid().ToString();
            var TempFileName = FileId + ".pdf";
            using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\TempFiles\" + TempFileName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            return FileId;

        }

        private void DeleteDocMenu_Click(object sender, EventArgs e)
        {
            DocList.FocusedItem.Remove();
        }

        private void MessageSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   var SenderAs = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == MessageSender.SelectedValue.ToString());
            //    GetMessageNumber(SenderAs.ResponsibilityCode, SenderAs.DesignationId);
        }

        private void MessageSender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var SenderAs = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == MessageSender.SelectedValue.ToString());
            GetMessageNumber(SenderAs.ResponsibilityCode, SenderAs.DesignationId);

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

        private void UsersList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdForAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdForAll.Checked == true)
            {
                btnAddUsers.Enabled = false;
                btnCopyTo.Enabled = false;

                Reciptes.Items.Clear();

                List<SystemUser> AllReciptesUsers = SystemUsersList.Where(x =>  x.Id.ToString()!= StaticParametrs.CurrentUser.Id).OrderBy(x => x.ResponsibilityCode).ToList();

                foreach (var user in AllReciptesUsers)
                {
                    string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                    var listViewItem = new ListViewItem(row);
                    Reciptes.Items.Add(listViewItem);
                }

            }
        }

        public static string ConvertDateCalendar(DateTime DateConv, string Calendar, string DateLangCulture)
        {
            DateTimeFormatInfo DTFormat;
            DateLangCulture = DateLangCulture.ToLower();
            /// We can't have the hijri date writen in English. We will get a runtime error

            if (Calendar == "Hijri" && DateLangCulture.StartsWith("en-"))
            {
                DateLangCulture = "ar-sa";
            }

            /// Set the date time format to the given culture
            DTFormat = new System.Globalization.CultureInfo(DateLangCulture, false).DateTimeFormat;

            /// Set the calendar property of the date time format to the given calendar
            switch (Calendar)
            {
                case "Hijri":
                    DTFormat.Calendar = new System.Globalization.HijriCalendar();
                    break;

                case "Gregorian":
                    DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                    break;

                default:
                    return "";
            }

            /// We format the date structure to whatever we want
            DTFormat.ShortDatePattern = "dd/MM/yyyy";
            return (DateConv.Date.ToString("f", DTFormat));
        }
    }

}
