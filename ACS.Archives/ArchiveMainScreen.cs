using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Services;
using ACS.DataAccess;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Message = ACS.Core.Entities.Message;

namespace ACS.Archives
{
    public partial class ArchiveMainScreen : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;
        private readonly IMessagesServices<Message> _messageServices;

        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");

        public BaseUser MainUser;
        public List<CollectingMessage> inboxMessages;
        public List<CollectingMessage> outboxMessages;
        public List<CollectingMessage> DeletedMessages;
        public List<CollectingMessage> noteList;

        public string myNetworkPath = string.Empty;
       
        public static object WIA_DPS_DOCUMENT_HANDLING_SELECT { get; private set; }
        public static object WIA_PROPERTIES { get; private set; }
        public static object WIA_DPS_DOCUMENT_HANDLING_STATUS { get; private set; }

        public ArchiveMainScreen(
             DataContext dataContext
            , OldSysDBContext OldDataContext
            )
        {
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;

            InitializeComponent();
            MessageList.MouseDoubleClick += new MouseEventHandler(MessageList_MouseDoubleClick);
            //DeletedMessagesList.MouseClick += new MouseEventHandler(DeletedMessagesList_Click);

            MessageList.MouseClick += new MouseEventHandler(MessageList_Click);

        }

        private void DeletedMessagesList_Click(object sender, MouseEventArgs e)
        {
            DeleteMessagesSetting.Show();
        }

        
        private void ArchiveMainScreen_Load(object sender, EventArgs e)
        {
            // delete temp files
            DeleteTempsFiles();

           //*************************************************
            //this.Hide();
            
           // Loginfrm logon = new Loginfrm(_dataContext);

            //if (logon.ShowDialog() != DialogResult.OK)
            //{
            //    this.Close();
            //}
            //else
            {
                // ListInbox.View = View.Details;
                btnDeleMessage.Hide();
               
                MessageList.View = View.Details;
                MessageList.Show();
                
                headerpnl.Left = this.Left;
                headerpnl.Top = this.Top;
                headerpnl.Height = 100;
                headerpnl.Width = this.Width;

                btnSearch.Left = 30;
                btnSearch.Top = 30;
                btnSearch.Width = (headerpnl.Width / 20);
                btnSearch.Height = 34;
                
                btnBackColor.Left = btnSearch.Left;
                btnBackColor.Top = btnSearch.Top + btnSearch.Height + 10;
               // btnBackColor.Width = btnSearch.Width;

                txtFindMessage.Top = btnSearch.Top;
                txtFindMessage.Left = btnSearch.Left + btnSearch.Width;
                txtFindMessage.Width = (headerpnl.Width / 9);
                txtFindMessage.Height = 34;

                refresh.Top = btnSearch.Top;
                refresh.Left = txtFindMessage.Left + txtFindMessage.Width + 100;
                refresh.Width = 40;
                refresh.Height = 40;

                notifi.Top = btnSearch.Top-5;
                notifi.Left = refresh.Left + refresh.Width + 60;
                notifi.Width = 50;
                notifi.Height = 45;

                LabNotifi.Top = notifi.Top + notifi.Height + 5 ;
                LabNotifi.Left = notifi.Left+ 10;
               
                showGroup.Top = txtFindMessage.Top - 10;
                //showGroup.Left = (txtFindMessage.Width * 2) + 300;
                showGroup.Left = refresh.Left+ refresh.Width + 200;
                showGroup.Height = 70;
                showGroup.Width = (txtFindMessage.Width * 2) + 80;
                //------------------------------------------
                rdReply.Left = 30;
                rdReply.Height = 50;
                rdReply.Width = showGroup.Width / 5;

                rdRead.Left = rdReply.Left + rdReply.Width + 40;
                rdRead.Height = rdReply.Height;
                rdRead.Width = rdReply.Width;

                rdToday.Left = rdRead.Left + rdRead.Width + 40;
                rdToday.Height = rdReply.Height;
                rdToday.Width = rdReply.Width;

                rdAll.Left = rdToday.Left + rdToday.Width + 40;
                rdAll.Height = rdReply.Height;
                rdAll.Width = rdReply.Width;

                //---------------------------------------------
                boxCountLab.Left = showGroup.Left + showGroup.Width + txtFindMessage.Width + 20;
                boxCountLab.Top = 70;
                boxCountLab.Height = txtFindMessage.Height; 
                boxCountLab.Width = 40;

                mailType.Left = boxCountLab.Left + boxCountLab.Width + 15;
                mailType.Top = 50;
                mailType.Height = txtFindMessage.Height;
                mailType.Width = 60;

                logo.Left = headerpnl.Width - 150;
                logo.Top = 10;
                logo.Height = 40;
                logo.Width = 50;

                systemName.Left = headerpnl.Width - 230;
                systemName.Top = 50;
                systemName.Height = mailType.Height;
                systemName.Width = 200;

                //------------------------------------------------

                MessageList.Left = this.Left - 10;
                MessageList.Top = headerpnl.Top + headerpnl.Height;
                MessageList.Height = this.Height - (headerpnl.Height + 80 );
                MessageList.Width = this.Width - 230;

                //----------------------------------------------------

                labUserDesc.Text= StaticParametrs.CurrentUser.FullName + " :: " + StaticParametrs.CurrentUser.JobtypeName;
                footerPnl.Left = this.Left;
                footerPnl.Top = MessageList.Top + MessageList.Height;
                footerPnl.Height = 80;
                footerPnl.Width = MessageList.Width - 10;

                labUserDesc.Left = (footerPnl.Width / 3) * 2;

                CopyRightLab.Text = "جميع الحقوق محفوظة للشركة الليبية للحديد والصلب " + DateTime.Now.Year.ToString();

               
                //====================================================
                nevigationPnl.Left = MessageList.Left + MessageList.Width;
                nevigationPnl.Top = MessageList.Top;
                nevigationPnl.Height = MessageList.Height;
                nevigationPnl.Width = this.Width/8;
               
                //updateSysLab.Left = MessageList.Left + 50;
                //updateSysLab.Top = nevigationPnl.Top - nevigationPnl.Height-50;

                btnNewMessage.Top = nevigationPnl.Top + 130;
               // btnNewMessage.Left = btnRefresh.Left;
                btnNewMessage.Height = (nevigationPnl.Height / 13) ;
                btnNewMessage.Width = nevigationPnl.Width - 25;

                btnInbox.Top = btnNewMessage.Top + btnNewMessage.Height + 30;
                btnInbox.Left = btnNewMessage.Left;
                btnInbox.Height = btnNewMessage.Height;
                btnInbox.Width = btnNewMessage.Width;

                btnOutbox.Top = btnInbox.Top + btnNewMessage.Height + 30;
                btnOutbox.Left = btnNewMessage.Left;
                btnOutbox.Height = btnNewMessage.Height;
                btnOutbox.Width = btnNewMessage.Width;

                btnDeletedMessages.Top = btnOutbox.Top + btnNewMessage.Height + 30;
                btnDeletedMessages.Left = btnNewMessage.Left;
                btnDeletedMessages.Height = btnNewMessage.Height;
                btnDeletedMessages.Width = btnNewMessage.Width;

                btnRep.Top = btnDeletedMessages.Top + btnNewMessage.Height + 30;
                btnRep.Left = btnNewMessage.Left;
                btnRep.Height = btnNewMessage.Height - 10;
                btnRep.Width = btnNewMessage.Width;

                btnOutSideMessages.Top = btnRep.Top + btnNewMessage.Height + 30;
                btnOutSideMessages.Left = btnNewMessage.Left;
                btnOutSideMessages.Height = btnNewMessage.Height ;
                btnOutSideMessages.Width = btnNewMessage.Width ;

                btnDeleMessage.Top = btnRep.Top + btnNewMessage.Height + 30;
                btnDeleMessage.Left = btnNewMessage.Left;
                btnDeleMessage.Height = btnNewMessage.Height;
                btnDeleMessage.Width = btnNewMessage.Width;

                btnAdvSearch.Width = btnNewMessage.Width;
                button1.Width = btnNewMessage.Width;
                btnEixt.Width = btnNewMessage.Width;
                
                btnNewMessage.Enabled = false;
                btnInbox.Enabled = false;
                btnOutbox.Enabled = false;
                btnAdvSearch.Enabled = false;
                btnOutSideMessages.Enabled = false;
                btnDeletedMessages.Enabled = false;

                // FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Left = Top = 0;
                MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                WindowState = FormWindowState.Maximized;

                MessageList.BackColor = ArchiveSettings.Default.ListColor;

               // this.Show();

                //**********************************end of desgine****
                var CurrentUser = StaticParametrs.CurrentUser;

                if (CurrentUser.IsArchiveUser==true)
                {
                    btnOutSideMessages.Enabled=true;
                    btnDeletedMessages.Enabled = true;
                }

                if (CurrentUser.IsArchiveUser == true && CurrentUser.JobCatId != 1 && CurrentUser.Discriminator != "SubApplicationUser")
                {
                    btnNewMessage.Enabled = false;
                    btnInbox.Enabled = false;
                    btnOutbox.Enabled = false;
                    btnAdvSearch.Enabled = false;
                    btnDeletedMessages.Enabled = false;

                }

                if (CurrentUser.ResponsibilityCode=="46120"  && CurrentUser.JobCatId == 1 && CurrentUser.Discriminator != "SubApplicationUser")
                {
                    btnOutSideMessages.Hide();
                    btnDeleMessage.Show();
                }
                else
                {
                    btnOutSideMessages.Show();
                    btnDeleMessage.Hide();
                }

                //=================call FillNotification ====================

                FillNotification(CurrentUser);

                //CurrentUser.FileNumber == CurrentUser.UserName
                if (CurrentUser.JobCatId != 1 && CurrentUser.Discriminator == "SubApplicationUser")
                {
                    MainUser = (ApplicationUser)_dataContext.Users.Where(x => x is ApplicationUser && x.JobCatId == 1 && x.JobStatus == "AE" && (x.ResponsibilityCode == CurrentUser.ResponsibilityCode)).OrderBy(x => x.ResponsibilityCode).FirstOrDefault();
                    
                    var Roles = _dataContext.UserRoles.FromSqlRaw("sp_show_User_Roles {0}", CurrentUser.Id.ToString() ).ToList();

                    foreach (var role in Roles)
                    {
                        if (role.Name == "SEND")
                        {
                            btnNewMessage.Enabled = true;
                        }

                        else if (role.Name == "INBOX")
                        {
                            btnInbox.Enabled = true;
                        }

                        else if (role.Name == "OUTBOX")
                        {
                            btnOutbox.Enabled = true;
                        }

                        else if (role.Name == "OLDSYSTEM")
                        {
                            btnAdvSearch.Enabled = true;
                        }

                        btnDeletedMessages.Enabled = false;
                    }

                }
                else if((CurrentUser.JobCatId == 1) || (CurrentUser.IsArchiveUser == false && CurrentUser.JobCatId != 1 && CurrentUser.Discriminator != "SubApplicationUser"))
                {
                    MainUser = CurrentUser;

                    btnNewMessage.Enabled = true;
                    btnInbox.Enabled = true;
                    btnOutbox.Enabled = true;
                    btnAdvSearch.Enabled = true;
                    btnDeletedMessages.Enabled = true; ;
                }

                if (btnInbox.Enabled==true)
                {
                   // btnRefresh.Enabled = true;
                    ViewInboxMessages(MainUser);
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        public void ViewInboxMessages(BaseUser User)
        {
         List<CollectingMessage> inboxMessages = new List<CollectingMessage>();

            //MessageList.Hide();
            MessageList.Show();

            rdAll.Checked = true;
            txtMessageType.Text = "Inbox";//بريد وارد
            mailType.Text = "البريد الوارد";

            MessageList.Columns.Clear();

            MessageList.Columns.Add("clmMessageId", 0, System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("الرقم الإشاري", MessageList.Width / 8, System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("موضوع المراسلة", MessageList.Width / 4, System.Windows.Forms.HorizontalAlignment.Left);
            MessageList.Columns.Add("تاريخ الارسال", (MessageList.Width / 8), System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("المرسل", (MessageList.Width / 4)-60, System.Windows.Forms.HorizontalAlignment.Left);
            MessageList.Columns.Add("عن طريق", (MessageList.Width / 4) - 30, System.Windows.Forms.HorizontalAlignment.Left);

            MessageList.Items.Clear();
           
            if (inboxMessages != null)
            {
                inboxMessages.Clear(); 
            }

            inboxMessages = _dataContext.CollectingMessages.FromSqlRaw("sp_show_inbox {0}, {1}, {2}, {3}, {4}", User.ResponsibilityCode, User.FileNumber, User.Id, User.JobCatId, User.DesignationId).ToList();
            
           

            foreach (var message in inboxMessages)
            {
                string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription,message.passedBy };
                var listViewItem = new ListViewItem(row);
                if (message.IsReaded==false)
                {
                    listViewItem.BackColor = Color.Orange;
                }
               // listViewItem.BackColor = Color.DarkRed;
                MessageList.Items.Add(listViewItem);
            }

            boxCountLab.Text = (MessageList.Items.Count).ToString();
           
           // labInboxCount.Text = inboxMessages.Where(c => c.IsReaded = false).Count().ToString();

        }

        public void ViewOutboxMessages(BaseUser User)
        {
            //DeletedMessagesList.Hide();
            MessageList.Show();

            rdAll.Checked = true;
            txtMessageType.Text = "Outbox";//بريد صادر
            mailType.Text = "البريد الصادر";

            MessageList.Columns.Clear();

            MessageList.Columns.Add("clmMessageId", 0, System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("الرقم الإشاري", MessageList.Width / 8, System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("موضوع المراسلة", MessageList.Width / 4, System.Windows.Forms.HorizontalAlignment.Left);
            MessageList.Columns.Add("تاريخ الارسال", (MessageList.Width / 8), System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("صفة المرسل", (MessageList.Width / 4)-60, System.Windows.Forms.HorizontalAlignment.Left);
            MessageList.Columns.Add("إرسال إلى", (MessageList.Width / 4)+30 , System.Windows.Forms.HorizontalAlignment.Left);

            MessageList.Items.Clear();

            outboxMessages = _dataContext.CollectingMessages.FromSqlRaw("sp_show_outbox {0}, {1}, {2}, {3}, {4}", User.ResponsibilityCode, User.FileNumber, User.Id, User.JobCatId, User.DesignationId).ToList();

            foreach (var message in outboxMessages)
            {
                string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }

            boxCountLab.Text = (MessageList.Items.Count).ToString();

        }

        private void MessageList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtMessageType.Text!= "Deleted")
            {
                try
                {
                    var _messageId = MessageList.SelectedItems[0].Text.Trim().ToString();

                    //var message = inboxMessages.FirstOrDefault(m => m.Id == Guid.Parse(_messageId));
                    //message.IsReaded = true;


                    MessageDetailsForm MessageDetl = new MessageDetailsForm(_dataContext, _OldDataContext, _messageId, txtMessageType.Text.Trim());

                    MessageDetl.Width = this.Width - 250;
                    MessageDetl.Height = this.Height - 200;
                    MessageDetl.StartPosition = FormStartPosition.CenterParent;

                    MessageDetl.ShowDialog(this);

                }
                catch (Exception)
                {
                    //throw;

                    MessageBox.Show("حدث خطأ أثناء محاولة استعراض المراسلة ... راجع مسؤول النظام", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
           
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            ViewInboxMessages(MainUser);
        }

        private void btnOutbox_Click(object sender, EventArgs e)
        {
            ViewOutboxMessages(MainUser);
        }

        private void rdToday_CheckedChanged(object sender, EventArgs e)
        {

            if (rdToday.Checked==true)
            {

            MessageList.Items.Clear();
            if (txtMessageType.Text == "Inbox")
            {
                var todayInbox = inboxMessages.Where(x => x.SendingDateTime.ToShortDateString() == DateTime.Now.ToShortDateString()).ToList();

                foreach (var message in todayInbox)
                {
                    string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.passedBy };
                    var listViewItem = new ListViewItem(row);
                    MessageList.Items.Add(listViewItem);
                }
                boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = " واردالبوم";

            }

            else if (txtMessageType.Text == "Outbox")
                {
                var todayOutbox = outboxMessages.Where(x => x.SendingDateTime.ToShortDateString() == DateTime.Now.ToShortDateString()).ToList();

                foreach (var message in todayOutbox)
                {
                    string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm   dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                    var listViewItem = new ListViewItem(row);
                    MessageList.Items.Add(listViewItem);
                }

                boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = "صادر اليوم";
                }

            }
        }
        
        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAll.Checked == true)
            {
                MessageList.Items.Clear();


                if (txtMessageType.Text == "Inbox")
                {
                    var todayInbox = inboxMessages.ToList();

                    foreach (var message in todayInbox)
                    {
                        string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.passedBy };
                        var listViewItem = new ListViewItem(row);
                        MessageList.Items.Add(listViewItem);
                    }
                    boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = "كل الوارد";

                }

                else if (txtMessageType.Text == "Outbox")
                {
                    var todayOutbox = outboxMessages.ToList();

                    foreach (var message in todayOutbox)
                    {
                        string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                        var listViewItem = new ListViewItem(row);
                        MessageList.Items.Add(listViewItem);
                    }

                    boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = "كل الصادر";
                }
            }
        }

        private void rdRead_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRead.Checked == true)
            {
                MessageList.Items.Clear();
                if (txtMessageType.Text == "Inbox")
                {
                    List<CollectingMessage> inboxMSG = _dataContext.CollectingMessages.FromSqlRaw("sp_show_inbox {0}, {1}, {2}, {3}, {4}", MainUser.ResponsibilityCode, MainUser.FileNumber, MainUser.Id, MainUser.JobCatId, MainUser.DesignationId).ToList();

                    var unReadInbox = inboxMSG.Where(x => x.IsReaded == false).ToList();

                    foreach (var message in unReadInbox)
                    {
                        string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.passedBy };
                        var listViewItem = new ListViewItem(row);
                        MessageList.Items.Add(listViewItem);
                    }
                    boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = "وارد غير مقروؤ";

                }

                  else if (txtMessageType.Text == "Outbox")
                {
                    List<CollectingMessage> outboxMSG = _dataContext.CollectingMessages.FromSqlRaw("sp_show_outbox {0}, {1}, {2}, {3}, {4}", MainUser.ResponsibilityCode, MainUser.FileNumber, MainUser.Id, MainUser.JobCatId, MainUser.DesignationId).ToList();

                    List<CollectingMessage> UnReadOutbox = outboxMSG.Where(x => x.IsReaded == false).ToList();

                    foreach (var message in UnReadOutbox)
                    {
                        string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                        var listViewItem = new ListViewItem(row);
                        MessageList.Items.Add(listViewItem);
                    }

                    boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = "صادر غير مقروؤ";
                }
            }
        }

        private void rdReply_CheckedChanged(object sender, EventArgs e)
        {
            if (rdReply.Checked == true)
            {
                MessageList.Items.Clear();
                if (txtMessageType.Text == "Inbox")
                {
                    List<CollectingMessage> inboxMSG = _dataContext.CollectingMessages.FromSqlRaw("sp_show_inbox {0}, {1}, {2}, {3}, {4}", MainUser.ResponsibilityCode, MainUser.FileNumber, MainUser.Id, MainUser.JobCatId, MainUser.DesignationId).ToList();

                    List<CollectingMessage> UnReplyInbox = inboxMSG.Where(x => x.IsReplyed == false).ToList();

                    foreach (var message in UnReplyInbox)
                    {
                        string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.passedBy };
                        var listViewItem = new ListViewItem(row);
                        MessageList.Items.Add(listViewItem);
                    }
                    boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = "وارد لم يتم الرد عليه";

                }

                else if (txtMessageType.Text == "Outbox")
                {
                    List<CollectingMessage> outboxMSG = _dataContext.CollectingMessages.FromSqlRaw("sp_show_outbox {0}, {1}, {2}, {3}, {4}", MainUser.ResponsibilityCode, MainUser.FileNumber, MainUser.Id, MainUser.JobCatId, MainUser.DesignationId).ToList();

                    List<CollectingMessage> UnReplyOutbox = outboxMSG.Where(x => x.IsReplyed == false).ToList();

                    foreach (var message in UnReplyOutbox)
                    {
                        string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                        var listViewItem = new ListViewItem(row);
                        MessageList.Items.Add(listViewItem);
                    }

                    boxCountLab.Text = (MessageList.Items.Count).ToString();
                    mailType.Text = "صادر لم يتم الرد عليه";
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            DeletedMessages = _dataContext.CollectingMessages.FromSqlRaw("sp_show_deleted_messages {0}", MainUser.Id).ToList();
           // ViewOutboxMessages(MainUser);
            ViewInboxMessages(MainUser);
        }

        private void btnDeletedMessages_Click(object sender, EventArgs e)
        {
            rdAll.Checked = true;
            txtMessageType.Text = "Deleted";
            mailType.Text = "المحدوفة";

            MessageList.Columns.Clear();

            MessageList.Columns.Add("clmMessageId", 0, System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("الرقم الإشاري", MessageList.Width / 8, System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add("موضوع المراسلة", MessageList.Width / 4, System.Windows.Forms.HorizontalAlignment.Left);
            MessageList.Columns.Add("تاريخ الارسال", (MessageList.Width / 8), System.Windows.Forms.HorizontalAlignment.Center);
            MessageList.Columns.Add(" المرسل", (MessageList.Width / 4) - 60, System.Windows.Forms.HorizontalAlignment.Left);
            MessageList.Columns.Add("إرسال إلى", (MessageList.Width / 4)+30 , System.Windows.Forms.HorizontalAlignment.Left);

            ViewDeletedMessages();

            //MessageList.Hide();
            //DeletedMessagesList.Show();

            //====================== old code =================================
            //DeletedMessagesList.Columns.Clear();

            //DeletedMessagesList.Columns.Add("clmMessageId", 0, System.Windows.Forms.HorizontalAlignment.Center);
            //DeletedMessagesList.Columns.Add("الرقم الإشاري", MessageList.Width / 8, System.Windows.Forms.HorizontalAlignment.Center);
            //DeletedMessagesList.Columns.Add("موضوع المراسلة", MessageList.Width / 4, System.Windows.Forms.HorizontalAlignment.Left);
            //DeletedMessagesList.Columns.Add("تاريخ الارسال", (MessageList.Width / 8), System.Windows.Forms.HorizontalAlignment.Center);
            //DeletedMessagesList.Columns.Add(" المرسل", (MessageList.Width / 4)-20, System.Windows.Forms.HorizontalAlignment.Left);
            //DeletedMessagesList.Columns.Add("إرسال إلى", (MessageList.Width / 4) - 20, System.Windows.Forms.HorizontalAlignment.Left);

            //ViewDeletedMessages();

            //MessageList.Hide();
            //DeletedMessagesList.Show();
        }

        public void ViewDeletedMessages()
        {
            MessageList.Items.Clear();
            DeletedMessages = _dataContext.CollectingMessages.FromSqlRaw("sp_show_deleted_messages {0}", MainUser.Id).ToList();
                                            
            foreach (var message in DeletedMessages)
            {
                string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                var listViewItem = new ListViewItem(row);
                MessageList.Items.Add(listViewItem);
            }

            boxCountLab.Text = (MessageList.Items.Count).ToString();
            MessageList.View = View.Details;

        }

        private void حدفنهائيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //var package = _dataContext.Packages.FirstOrDefault(p => p.Id == Guid.Parse(DeletedMessagesList.SelectedItems[0].Text.Trim().ToString()) && p.RecipintId == MainUser.Id.ToString());

                //if (package != null)
                //{
                //    _dataContext.Remove(package);
                //    _dataContext.SaveChangesAsync();
                //    DeletedMessagesList.SelectedItems.Clear();

                //    MessageBox.Show("تم حدف المراسلة بنجاح", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //}
                //ViewDeletedMessages();
            }
            catch (Exception)
            {

                MessageBox.Show("حدث خطأ أثناء محاولة حدف المراسلة ... راجع مسؤول النظام", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void استرجاعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var package = _dataContext.Packages.FirstOrDefault(p => p.Id == Guid.Parse(MessageList.SelectedItems[0].Text.Trim().ToString()));
                //&& p.RecipintId == MainUser.Id.ToString()); 
                if (package != null)
                {
                    package.IsDeleted = false;
                    _dataContext.Update(package);
                    _dataContext.SaveChangesAsync();

                    //DeletedMessagesList.SelectedItems.Clear();
                    MessageBox.Show("تم استرجاع المراسلة بنجاح", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                ViewDeletedMessages();
            }
            catch (Exception)
            {
                MessageBox.Show("حدث خطأ أثناء محاولة استرجاع المراسلة ... راجع مسؤول النظام", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void افراغسلةالمحدوفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                 List<Package> pakcageList = _dataContext.Packages.Where(p => p.IsDeleted == true && p.RecipintId == MainUser.Id).ToList();
                foreach (var package in pakcageList)
                {
                    _dataContext.Remove(package);
                    
                }
                _dataContext.SaveChangesAsync();


                MessageBox.Show("تم افراغ سلة المحدوفات بنجاح", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ViewDeletedMessages();
            }
            catch (Exception)
            {

                MessageBox.Show("حدث خطأ أثناء محاولة افراغ سلة المحدوفات ... راجع مسؤول النظام", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMessageType.Text == "Inbox")
            {
                var searchResult = inboxMessages.Where(x => (x.SerialNumber !=null && x.SerialNumber.Contains(txtFindMessage.Text))
                || (x.Title != null && x.Title.Contains(txtFindMessage.Text))
                || (x.passedBy != null && x.passedBy.Contains(txtFindMessage.Text))
                || (x.SenderDiscription != null && x.SenderDiscription.Contains(txtFindMessage.Text))
                ).ToList();

                MessageList.Items.Clear();
                foreach (var message in searchResult)
                {
                    string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.passedBy };
                    var listViewItem = new ListViewItem(row);
                    MessageList.Items.Add(listViewItem);
                }
                boxCountLab.Text = (MessageList.Items.Count).ToString();

            }

            else if (txtMessageType.Text == "Outbox")
            {
                var searchResult = outboxMessages.Where(x => (x.SerialNumber != null && x.SerialNumber.Contains(txtFindMessage.Text))
                || (x.Title != null && x.Title.Contains(txtFindMessage.Text))
                || (x.RecipintDiscription != null && x.RecipintDiscription.Contains(txtFindMessage.Text))
                || (x.SenderDiscription != null && x.SenderDiscription.Contains(txtFindMessage.Text))
                ).ToList();

                MessageList.Items.Clear();
                foreach (var message in searchResult)
                {
                    string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                    var listViewItem = new ListViewItem(row);
                    MessageList.Items.Add(listViewItem);
                }

                boxCountLab.Text = (MessageList.Items.Count).ToString();
            }
        }

        private void txtFindMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtMessageType.Text == "Inbox")
            {
                var searchResult = inboxMessages.Where(x => (x.SerialNumber != null && x.SerialNumber.Contains(txtFindMessage.Text))
                || (x.Title != null && x.Title.Contains(txtFindMessage.Text))
                || (x.passedBy != null && x.passedBy.Contains(txtFindMessage.Text))
                || (x.SenderDiscription != null && x.SenderDiscription.Contains(txtFindMessage.Text))
                ).ToList();

                MessageList.Items.Clear();
                foreach (var message in searchResult)
                {
                    string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.passedBy };
                    var listViewItem = new ListViewItem(row);
                    MessageList.Items.Add(listViewItem);
                }
                boxCountLab.Text = (MessageList.Items.Count).ToString();

            }

            else if (txtMessageType.Text == "Outbox")
            {
                var searchResult = outboxMessages.Where(x => (x.SerialNumber != null && x.SerialNumber.Contains(txtFindMessage.Text))
                || (x.Title != null && x.Title.Contains(txtFindMessage.Text))
                || (x.RecipintDiscription != null && x.RecipintDiscription.Contains(txtFindMessage.Text))
                || (x.SenderDiscription != null && x.SenderDiscription.Contains(txtFindMessage.Text))
                ).ToList();

                MessageList.Items.Clear();
                foreach (var message in searchResult)
                {
                    string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                    var listViewItem = new ListViewItem(row);
                    MessageList.Items.Add(listViewItem);
                }

                boxCountLab.Text = (MessageList.Items.Count).ToString();
            }

            else if (txtMessageType.Text == "Deleted")
            {
                var searchResult = DeletedMessages.Where(x => (x.SerialNumber != null && x.SerialNumber.Contains(txtFindMessage.Text))
                || (x.Title != null && x.Title.Contains(txtFindMessage.Text))
                || (x.RecipintDiscription != null && x.RecipintDiscription.Contains(txtFindMessage.Text))
                || (x.SenderDiscription != null && x.SenderDiscription.Contains(txtFindMessage.Text))
                ).ToList();

                MessageList.Items.Clear();
                foreach (var message in searchResult)
                {
                    string[] row = { message.Id.ToString(), message.SerialNumber, message.Title, message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy"), message.SenderDiscription, message.RecipintDiscription };
                    var listViewItem = new ListViewItem(row);
                    MessageList.Items.Add(listViewItem);
                }

                boxCountLab.Text = (MessageList.Items.Count).ToString();
            }
        }

        private void btnOutSideMessages_Click(object sender, EventArgs e)
        {
            mainScreen ArchiveForm = new mainScreen(_dataContext, _OldDataContext, _messageServices);

            //ArchiveForm.Width = this.Width - 100;
            //ArchiveForm.Height = this.Height - 100;
            //ArchiveForm.StartPosition = FormStartPosition.CenterParent;

             ArchiveForm.Show();
            //ArchiveForm.ShowDialog(this);
        }

        private void btnNewMessage_Click(object sender, EventArgs e)
        {
            NewMessageForm NewMessage = new NewMessageForm(_dataContext, _OldDataContext,this);

            NewMessage.Width = this.Width - 100;
            NewMessage.Height = this.Height - 100;
            NewMessage.StartPosition = FormStartPosition.CenterParent;

            // NewMessage.Show();
            NewMessage.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangingPassword changePassForm = new ChangingPassword(_dataContext);
            changePassForm.ShowDialog(this);
        }

        private void btnAdvSearch_Click(object sender, EventArgs e)
        {
            //SearchInOldSystem SearchForm = new SearchInOldSystem(_dataContext, _OldDataContext);

            ArchiveForm SearchForm = new ArchiveForm(_dataContext, _OldDataContext);

            SearchForm.Width = this.Width - 250;
            SearchForm.Height = this.Height - 200;
            SearchForm.StartPosition = FormStartPosition.CenterParent;

            // NewMessage.Show();
            SearchForm.ShowDialog(this);
        }

        private void headerpnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ArchiveMainScreen_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F5)

            {
                ViewInboxMessages(MainUser);

                //button1_Click("", e);

            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
           // _dataContext.SaveChanges();

            if (StaticParametrs.CurrentUser.IsArchiveUser==false || (StaticParametrs.CurrentUser.IsArchiveUser == true && StaticParametrs.CurrentUser.JobCatId==1))
            {
                FillNotification(StaticParametrs.CurrentUser);

                DeletedMessages = _dataContext.CollectingMessages.FromSqlRaw("sp_show_deleted_messages {0}", MainUser.Id).ToList();
                // ViewOutboxMessages(MainUser);
                ViewInboxMessages(MainUser);
            }
           
        }

        private void MessageList_Click(object sender, EventArgs e)
        {
            //if (txtMessageType.Text == "Deleted")
            //{
            //    DeleteMessagesSetting.Items[0].Visible = true;
            //}
            //else
            //{
            //    DeleteMessagesSetting.Items[0].Visible = false;

            //}
        }

        private void DeleteMessagesSetting_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtMessageType.Text == "Deleted")
            {
                DeleteMessagesSetting.Items[0].Visible = true;
            }
            else
            {
                DeleteMessagesSetting.Items[0].Visible = false;

            }

        }


        private void notifi_Click(object sender, EventArgs e)
        {
            if (LabNotifi.Text!="0")
            {
                NotificationForm notiForm = new NotificationForm(_dataContext, _OldDataContext,this);
                notiForm.Left = 20;
                notiForm.Top = headerpnl.Top + headerpnl.Height;
                notiForm.Show(this);
            }
            else
            {
                MessageBox.Show("لاتوجد تنبيهات للعرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
        }

        public void FillNotification(BaseUser User)
        {
            if (User.JobCatId==1)
            {
                noteList = _dataContext.CollectingMessages.FromSqlRaw("sp_show_notes {0}, {1}, {2}, {3}, {4}", User.ResponsibilityCode, User.FileNumber, User.Id, User.JobCatId, User.DesignationId).ToList();
                LabNotifi.Text = noteList.Count.ToString();
            }
            else
            {
                LabNotifi.Text = "0";
            }
            
        }


        private void btnUdateSystem_Click(object sender, EventArgs e)
        {
            //updateSysForm updateSys = new updateSysForm();
            //updateSys.ShowDialog();
            this.Enabled = false;
            //updateSysLab.Visible = true;
            try
            {
                string sourceDir = @"\\10.10.102.16\ASC Project\ACS.Archives";

                using (new ConnectToSharedFolder(sourceDir, credentials))
                {
                  
                   // string destinationDir = @"C:\ASC Project\ACS.Archives";
                    //CopyDirectory(sourceDir, destinationDir, true);

                    //updateSys.Close();
                    //MessageBox.Show("تمت عملية تحديث النظام بنجاح...للحصول على آخر التحديثات قم بإعادة تشغيل النظام");
                   
                    //this.Enabled = true;
                    //updateSysLab.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
           // progBar.Visible() = true;
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"حدث خطأ أثناء محاولة تحديث الملف: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
               
                if (File.Exists(targetFilePath))
                {
                    File.Delete(targetFilePath);
                }
               
                file.CopyTo(targetFilePath);
            }
            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        private void btnRep_Click(object sender, EventArgs e)
        {
            RepForm repForm = new RepForm(_dataContext);
            repForm.Show();
        }

        private void إعادةتوجيهمراسلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Message> messages= new List<Message>(); ;
            if (MessageList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in MessageList.SelectedItems)
                {
                    Message message = new Message();
                    message.Id = Guid.Parse(item.SubItems[0].Text.ToString());
                    message.SerialNumber = item.SubItems[1].Text.ToString();
                    message.Title = item.SubItems[2].Text.ToString();
                   
                    messages.Add(message);
                }

                AddMultiComments MultiComments = new AddMultiComments(_dataContext, messages);

                MultiComments.Width = (this.Width / 3) * 2;
                MultiComments.Height = (this.Height / 2) ;
                MultiComments.StartPosition = FormStartPosition.CenterParent;

                MultiComments.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("اختر الرسائل التي تريد إعادة توجيهها");
            }

            

        }

        private void MultiCommentMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtMessageType.Text == "Inbox")
            {
                DeleteMessagesSetting.Items[0].Visible = true;
            }
            else
            {
                DeleteMessagesSetting.Items[0].Visible = false;

            }

        }

        private void btnBackColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = MessageList.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                MessageList.BackColor = MyDialog.Color;
            ArchiveSettings.Default.ListColor = MyDialog.Color;
            ArchiveSettings.Default.Save();
        }

        private void DeleteTempsFiles()
        {
            string FilePath = @"D:\ASC Project\ACS.Archives\CommentTempFiles\";
            DirectoryInfo dir = new DirectoryInfo(FilePath);
            IEnumerable<FileInfo> Files = dir.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (var item in Files)
            {
                item.Delete();
            }
            //-----------------------------------
            string FilePath1 = @"D:\ASC Project\ACS.Archives\AttachTempFiles\";
            DirectoryInfo dir1 = new DirectoryInfo(FilePath1);
            IEnumerable<FileInfo> Files1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (var item in Files1)
            {
                item.Delete();
            }
            //------------------------------------------------
            string FilePath2 = @"D:\ASC Project\ACS.Archives\ScanFiles\";
            DirectoryInfo dir2 = new DirectoryInfo(FilePath2);
            IEnumerable<FileInfo> Files2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (var item in Files2)
            {
                item.Delete();
            }
            //---------------------------------------------
            string FilePath3 = @"D:\ASC Project\ACS.Archives\TempFiles\";
            DirectoryInfo dir3 = new DirectoryInfo(FilePath3);
            IEnumerable<FileInfo> Files3 = dir3.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (var item in Files3)
            {
                item.Delete();
            }

        }

        private void btnDeleMessage_Click(object sender, EventArgs e)
        {
            DeleteMessageScreen DelForm = new DeleteMessageScreen(_dataContext);
            //DeleteMessageScreen DelForm = new DeleteMessageScreen();
            DelForm.Show();
        }
    }
}
