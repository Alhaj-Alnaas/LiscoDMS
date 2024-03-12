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
using System.Windows.Forms;
using Message = ACS.Core.Entities.Message;

namespace ACS.Archives
{
    public partial class AddMultiComments : Form
    {
        protected readonly DataContext _dataContext;
        private readonly List<Message> _messages;
 
        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");

        public BaseUser MainUser;
        public BaseUser Sender;

        public List<SystemUser> SystemUsersList;
        public List<SystemUser> ReciptesUsers;

        public string myNetworkPath = string.Empty;
        public AddMultiComments(DataContext dataContext , List<Message> messages)
            
        {
            _dataContext = dataContext;
            _messages = messages;
            
            InitializeComponent();
            copyToList.MouseClick += new MouseEventHandler(copyToList_MouseClick);
            CopyList.MouseDoubleClick += new MouseEventHandler(CopyList_MouseDoubleClick);

            UsersList.MouseDoubleClick += new MouseEventHandler(UsersList_MouseDoubleClick);
            Reciptes.MouseClick += new MouseEventHandler(Reciptes_MouseClick);

        }

        private void AddMultiComments_Load(object sender, EventArgs e)
        {
            try
            {

                MessageList.Top = 5;
                MessageList.Left = 5;
                MessageList.Width = (this.Width / 2)- (this.Width / 30);
                MessageList.Height = this.Height - 10;

                //----------------------------------------------------------------

                groupBox1.Top = MessageList.Top;
                groupBox1.Left = MessageList.Left + MessageList.Width + 5;
                groupBox1.Width = (this.Width / 2) ;
                groupBox1.Height = (this.Height / 4)*3;

                //send as 
                SendAs.Left = groupBox1.Width / 20;
                SendAs.Width = groupBox1.Width /2;
                SendAs.Top = 20;
                SendAs.Height = groupBox1.Height / 6;

                // send as lab
                labSendAs.Left = SendAs.Left + SendAs.Width + 10;
                labSendAs.Height = 40;
                labSendAs.Top = SendAs.Top;

                //reciptes
                Reciptes.Top = SendAs.Top+ SendAs.Height+20;
                Reciptes.Left = SendAs.Left;
                Reciptes.Width = (groupBox1.Width/4)*3;
                Reciptes.Height = (groupBox1.Height / 4) ; 

                // btnAddUsers
                btnAddUsers.Left = Reciptes.Left + Reciptes.Width;
                btnAddUsers.Height = Reciptes.Height + 3;
                btnAddUsers.Width = Reciptes.Width /4; //100
                btnAddUsers.Top = Reciptes.Top;

                // copy to list
                copyToList.Left = Reciptes.Left;
                copyToList.Width = Reciptes.Width;
                copyToList.Top = Reciptes.Top + Reciptes.Height + 10;
                copyToList.Height = (groupBox1.Height / 5);

                // btnCopyTo
                btnCopyTo.Left = btnAddUsers.Left;
                btnCopyTo.Height = copyToList.Height + 3;
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
                
                // btnCloseCopyList
                btnCloseCopyList.Left = copyToList.Left;
                btnCloseCopyList.Height = 40;
                btnCloseCopyList.Width = 40;
                btnCloseCopyList.Top = Reciptes.Top;

                //txtFindCopy
                txtFindCopy.Width = (copyToList.Width + btnCopyTo.Width) - 10;
                txtFindCopy.Top = btnCloseCopyList.Top;
                txtFindCopy.Left = copyToList.Left + btnCloseCopyList.Left;
                txtFindCopy.Height = btnCloseCopyList.Height;

                //CopyList
                CopyList.Width = UsersList.Width;
                CopyList.Top = txtFindCopy.Top + txtFindCopy.Height;
                CopyList.Left = btnCloseCopyList.Left;
                CopyList.Height = Reciptes.Height- txtFindCopy.Height; 
                  
                txtComment.Top = copyToList.Top+ copyToList.Height+ (copyToList.Height/3);
                txtComment.Left = copyToList.Left;
                txtComment.Width = copyToList.Width;
                txtComment.Height = copyToList.Height ;


                //group box4--------------------------------
                groupBox4.Top = txtComment.Top + txtComment.Height + 5;
                groupBox4.Left = groupBox1.Left;
                groupBox4.Width = groupBox1.Width;
                groupBox4.Height = this.Height - groupBox1.Height - 25;

                //sendMessage.Top = 10;
                sendMessage.Left = groupBox4.Width / 4;
                sendMessage.Height = (groupBox4.Height / 2) ;
                sendMessage.Width = groupBox4.Width / 2;
               
                //============================================================
               

                txtSearch.Hide();
                UsersList.Hide();
                btnClose.Hide();

                btnCloseCopyList.Hide();
                txtFindCopy.Hide();
                CopyList.Hide();

                this.Show();

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

                List<SystemUser> LowLevelUsers = GetLowLevelUsers(MainUser.DesignationId, MainUser.ResponsibilityCode);

                foreach (var user in LowLevelUsers)
                {
                    string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                    var listViewItem = new ListViewItem(row);
                    UsersList.Items.Add(listViewItem);
                }

                foreach (var user in LowLevelUsers)
                {
                    string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                    var listViewItem = new ListViewItem(row);
                    CopyList.Items.Add(listViewItem);
                }
                Reciptes.View = View.Details;
                UsersList.View = View.Details;
                CopyList.View = View.Details;
                copyToList.View = View.Details;
            }


            catch (Exception)
            {
                throw;

            }

            MessageList.Columns.Clear();

            MessageList.Columns.Add("clmMessageId", 0, HorizontalAlignment.Center);
            MessageList.Columns.Add("الرقم الإشاري",MessageList.Width / 3, HorizontalAlignment.Center);
            MessageList.Columns.Add("موضوع المراسلة", (MessageList.Width / 3)*2, HorizontalAlignment.Left);
           
            MessageList.Items.Clear();

            foreach (var message in _messages)
            {
                string[] row = { message.Id.ToString(), message.SerialNumber, message.Title };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }
            MessageList.BackColor = ArchiveSettings.Default.ListColor;
            MessageList.View = View.Details;
        }

        public List<SystemUser> GetLowLevelUsers(int designationId, string CurrRespCode)
        {

            if (CurrRespCode.Substring(0, 2) == "43")
            {
                return SystemUsersList.Where(x => x.ResponsibilityCode != CurrRespCode
                            ).ToList();
                // return LowLevelUsers;
            }
            else
            {
                switch (designationId)
                {
                    case 4:// Director Cases

                        return SystemUsersList.Where(x => x.JobCatId == 1 && x.ResponsibilityCode != CurrRespCode
                       && (
                        // your departmen without general departmen
                        (x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3) && x.ResponsibilityCode.Substring(4, 1) == "0") ||
                           //your general department
                           (x.ResponsibilityCode.Substring(0, 2) == CurrRespCode.Substring(0, 2) && x.ResponsibilityCode.Substring(3, 2) == "00"))
                            ).ToList();


                    case 5: //general maneger Cases
                        return SystemUsersList.Where(x => x.JobCatId == 1 && x.ResponsibilityCode != CurrRespCode && (
                        //Your Departments
                        (x.ResponsibilityCode.Substring(4, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)) ||
                        // your sections  without  departments
                        (x.ResponsibilityCode.Substring(3, 1) == "0" && x.ResponsibilityCode.Substring(0, 3) == CurrRespCode.Substring(0, 3)))).ToList();


                    case 6: // maneger cases
                        return SystemUsersList.Where(x => x.JobCatId == 1 && x.ResponsibilityCode != CurrRespCode && (
                         (x.ResponsibilityCode.Substring(0, 4) == CurrRespCode.Substring(0, 4))
                            )).ToList();


                    case 8:// Head of section cases
                        return SystemUsersList.Where(x => x.ResponsibilityCode == CurrRespCode).ToList();


                    default:
                        return SystemUsersList.Where(x => x.ResponsibilityCode == CurrRespCode).ToList();

                }
            }
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            copyToList.Hide();
            btnCopyTo.Hide();
            txtComment.Hide();

            txtSearch.Show();
            UsersList.Show();
            btnClose.Show();
        }

        private void btnCopyTo_Click(object sender, EventArgs e)
        {
            btnAddUsers.Hide();
            Reciptes.Hide();

            btnCloseCopyList.Show();
            txtFindCopy.Show();
            CopyList.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtSearch.Hide();
            UsersList.Hide();
            btnClose.Hide();

            copyToList.Show();
            btnCopyTo.Show();
            txtComment.Show();
        }

        private void btnCloseCopyList_Click(object sender, EventArgs e)
        {
            btnCloseCopyList.Hide();
            txtFindCopy.Hide();
            CopyList.Hide();

            btnAddUsers.Show();
            Reciptes.Show();
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

        private void DeleteReciptMenu_Click(object sender, EventArgs e)
        {
            Reciptes.FocusedItem.Remove();

        }

        private void deleteCopyMenu_Click(object sender, EventArgs e)
        {
            copyToList.FocusedItem.Remove();

        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                var vali = CheckValidation();
                if ( vali)
                {
                    foreach (ListViewItem item in MessageList.Items)
                    {
                        Message MainMessage = new Message();
                        MainMessage.Id = Guid.Parse(item.SubItems[0].Text.ToString());
                        MainMessage.SerialNumber = item.SubItems[1].Text.ToString();
                        MainMessage.Title = item.SubItems[2].Text.ToString();

                            List<Package> packages = new List<Package>();
                           
                            foreach (ListViewItem itemRow in Reciptes.Items)
                            {

                            SystemUser Recipt = SystemUsersList.Where(c => c.Id.ToString()== itemRow.SubItems[0].Text).FirstOrDefault();
                          
                            if (Recipt != null)
                                {
                                    Package package = new Package
                                    {
                                        ResponsibilityCode = Recipt.ResponsibilityCode,
                                        RecipintId = Recipt.Id.ToString(),
                                        RecipintDiscription = Recipt.FullName ,
                                        DesignationId = Recipt.DesignationId,
                                        CreatedBy = StaticParametrs.CurrentUser,
                                        IsCC = false
                                    };
                                    packages.Add(package);
                                }

                            }

                      
                            foreach (ListViewItem itemRow in copyToList.Items)
                            {
                            SystemUser Recipt = SystemUsersList.Where(c => c.Id.ToString() == itemRow.SubItems[0].Text).FirstOrDefault();

                            if (Recipt != null)
                            {
                                Package package = new Package
                                {
                                    ResponsibilityCode = Recipt.ResponsibilityCode,
                                    RecipintId = Recipt.Id.ToString(),
                                    RecipintDiscription = Recipt.FullName ,
                                    DesignationId = Recipt.DesignationId,
                                    CreatedBy = StaticParametrs.CurrentUser,
                                    IsCC = true
                                };
                                packages.Add(package);
                            }
                                
                           
                        }

                        SystemUser UserSender = new SystemUser();
                            UserSender = SystemUsersList.FirstOrDefault(c => c.Id.ToString() == SendAs.SelectedValue.ToString());

                            var message = new Message();
                            {
                                message.SerialNumber = "";
                                message.Title = MainMessage.Title;
                                message.OriginMessageId = MainMessage.Id.ToString();
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

                            
                            message.Packages = packages;
                           
                            _dataContext.Messages.Add(message);
                            _dataContext.SaveChanges();

                        }

                      
                    MessageBox.Show("تمت عملية الإرسال بنجاح ", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("اختر الرسائل التي تريد إعادة توجيهها");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckValidation()
        {

            if (SendAs.Text.Trim() == "")
            {
                MessageBox.Show("اختر صفة المرسل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SendAs.Focus();
                return false;
            }

            else if (txtComment.Text.Trim()=="" || txtComment.Text.Trim() == null)
            {
                MessageBox.Show("أدخل نص التأشيرة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (Reciptes.Items.Count == 0)
            {
                MessageBox.Show("اختر المرسل إليهم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else { return true; };

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UsersList.Items.Clear();

            ReciptesUsers = GetLowLevelUsers(MainUser.DesignationId, MainUser.ResponsibilityCode);

            List<SystemUser> filter = ReciptesUsers.Where(x => x.JobtypeName.Contains(txtSearch.Text) || x.FullName.Contains(txtSearch.Text)).OrderBy(x => x.ResponsibilityCode).ToList();

            foreach (var user in filter)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                UsersList.Items.Add(listViewItem);
            }
        }

        private void txtFindCopy_TextChanged(object sender, EventArgs e)
        {
            CopyList.Items.Clear();

            ReciptesUsers= GetLowLevelUsers(MainUser.DesignationId, MainUser.ResponsibilityCode);

            List<SystemUser> filter = ReciptesUsers.Where(x => x.JobtypeName.Contains(txtFindCopy.Text) || x.FullName.Contains(txtFindCopy.Text)).OrderBy(x => x.ResponsibilityCode).ToList();

            foreach (var user in filter)
            {
                string[] row = { user.Id.ToString(), user.FullName, user.JobtypeName };
                var listViewItem = new ListViewItem(row);
                CopyList.Items.Add(listViewItem);
            }
        }

    }
}
