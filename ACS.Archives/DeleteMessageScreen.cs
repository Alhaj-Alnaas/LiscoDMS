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

namespace ACS.Archives
{
    public partial class DeleteMessageScreen : Form
    {
        protected readonly DataContext _dataContext;
        public DeleteMessageScreen( DataContext dataContext)
        {
            _dataContext = dataContext;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            showMessagedata();
            
        }

        private void DeleteMessage_Click(object sender, EventArgs e)
        {
            var messages = _dataContext.Messages.Include("Packages").Where(m => m.Id == Guid.Parse(txtMessageId.Text.ToString()) || m.OriginMessageId == txtMessageId.Text.ToString());

            DialogResult result;
            result = MessageBox.Show("هل تريد بالتأكيد حدف هدة المراسلة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (var message in messages)
                {
                    message.IsDeleted = true;
                    message.DeletedBy = StaticParametrs.CurrentUser;
                    message.DeletedById = StaticParametrs.CurrentUser.Id;
                    message.DeletedOn = DateTime.Now;
                    _dataContext.Messages.Update(message);
                    //  _dataContext.Messages.Remove(message);

                }
                _dataContext.SaveChangesAsync();

                txtMessageNo.Text = "";
                txtMessageSubject.Text = "";
                MessageSender.Text = "";
                txtSendingDate.Text = "";

                MessageBox.Show("تم حدف المراسلة بنجاح", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        void showMessagedata()
        {
            var message = _dataContext.Messages.FirstOrDefault(m => m.SerialNumber == txtMessageNo.Text.Trim().ToString() && m.IsDeleted==false);
            txtMessageId.Text = message.Id.ToString();
            if (message== null)
            {
                MessageBox.Show("لاتوجد مراسلة بهدا الرقم ، نأمل التأكد من رقم المراسلة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //if (message.OriginMessageId != null)
                //{
                //    txtMessageId.Text = message.OriginMessageId.ToString();
                //}
                txtMessageId.Text = message.Id.ToString();
                txtMessageNo.Text = message.SerialNumber;
                txtMessageSubject.Text = message.Title;
                MessageSender.Text = message.SenderDiscription;
                txtSendingDate.Text = message.SendingDateTime.ToString("HH:mm  dd/MM/yyyy");
            }

        }

        private void txtMessageNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                showMessagedata();
            }

        }

    }
}
