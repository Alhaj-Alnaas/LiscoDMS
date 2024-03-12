using ACS.Core.Entities;
using ACS.DataAccess;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ACS.Archives
{
    public partial class NotificationForm : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;
        private ArchiveMainScreen _mainForm;

        public List<CollectingMessage> noteList;
        public NotificationForm(
             DataContext dataContext
             , OldSysDBContext OldDataContext
             , ArchiveMainScreen mainForm
            )
        {
            _dataContext = dataContext;
            _OldDataContext = OldDataContext;
            _mainForm = mainForm;
            InitializeComponent();
            //notificationList.MouseDoubleClick += new MouseEventHandler(notificationList_MouseDoubleClick);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //List<Notification> notifi = new List<Notification>();
            if (notificationList.Items.Count > 0)
            {
                Notification notifi = new Notification();
                foreach (ListViewItem itemRow in notificationList.Items)
                {
                    notifi = _dataContext.Notifications.Where(n => n.Id == Guid.Parse(itemRow.SubItems[1].Text)).FirstOrDefault();
                    if (notifi != null)
                    {
                        _dataContext.Notifications.Remove(notifi);
                    }
                }
                _dataContext.SaveChangesAsync();

            }
            _mainForm.FillNotification(StaticParametrs.CurrentUser);
            this.Close();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            notificationList.View = View.Details;

            var CurrentUser = StaticParametrs.CurrentUser;
            noteList = _dataContext.CollectingMessages.FromSqlRaw("sp_show_notes {0}, {1}, {2}, {3}, {4}", CurrentUser.ResponsibilityCode, CurrentUser.FileNumber, CurrentUser.Id, CurrentUser.JobCatId, CurrentUser.DesignationId).ToList();

            foreach (var note in noteList)
            {
                string[] row = { note.OriginMessageId.ToString(), note.Id.ToString(), note.Body,note.MessageFrom };
                var listViewItem = new ListViewItem(row);
                notificationList.Items.Add(listViewItem);
            }

            //boxCountLab.Text = (notificationList.Items.Count).ToString();
        }

        private void notificationList_Click(object sender, EventArgs e)
        {
            try
            {
                //ArchiveMainScreen M = new ArchiveMainScreen(_dataContext, _OldDataContext);

                var _messageId = notificationList.SelectedItems[0].Text.Trim().ToString();
                MessageDetailsForm MessageDetl = new MessageDetailsForm(_dataContext, _OldDataContext, _messageId, notificationList.FocusedItem.SubItems[3].Text);

                MessageDetl.Width = _mainForm.Width - 250;
                MessageDetl.Height = _mainForm.Height - 200;
                MessageDetl.StartPosition = FormStartPosition.CenterScreen;

                MessageDetl.ShowDialog(_mainForm);

            }
            catch (Exception)
            {
                //throw;

                MessageBox.Show("حدث خطأ أثناء محاولة استعراض المراسلة ... راجع مسؤول النظام", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
