
namespace ACS.Archives
{
    partial class NotificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            this.notificationList = new System.Windows.Forms.ListView();
            this.MessageId = new System.Windows.Forms.ColumnHeader();
            this.noteId = new System.Windows.Forms.ColumnHeader();
            this.noteDesc = new System.Windows.Forms.ColumnHeader();
            this.messageType = new System.Windows.Forms.ColumnHeader();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notificationList
            // 
            this.notificationList.BackColor = System.Drawing.Color.LemonChiffon;
            this.notificationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MessageId,
            this.noteId,
            this.noteDesc,
            this.messageType});
            this.notificationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.notificationList.FullRowSelect = true;
            this.notificationList.HideSelection = false;
            this.notificationList.Location = new System.Drawing.Point(0, 0);
            this.notificationList.Margin = new System.Windows.Forms.Padding(4);
            this.notificationList.MultiSelect = false;
            this.notificationList.Name = "notificationList";
            this.notificationList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.notificationList.RightToLeftLayout = true;
            this.notificationList.Size = new System.Drawing.Size(488, 256);
            this.notificationList.TabIndex = 49;
            this.notificationList.UseCompatibleStateImageBehavior = false;
            this.notificationList.View = System.Windows.Forms.View.Details;
           
            this.notificationList.Click += new System.EventHandler(this.notificationList_Click);
            // 
            // MessageId
            // 
            this.MessageId.DisplayIndex = 1;
            this.MessageId.Width = 0;
            // 
            // noteId
            // 
            this.noteId.DisplayIndex = 0;
            this.noteId.Text = "";
            this.noteId.Width = 0;
            // 
            // noteDesc
            // 
            this.noteDesc.Text = "تنبيــهـــــات";
            this.noteDesc.Width = 480;
            // 
            // messageType
            // 
            this.messageType.Width = 0;
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDone.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDone.Image = ((System.Drawing.Image)(resources.GetObject("btnDone.Image")));
            this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDone.Location = new System.Drawing.Point(0, 204);
            this.btnDone.Margin = new System.Windows.Forms.Padding(4);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(488, 52);
            this.btnDone.TabIndex = 50;
            this.btnDone.Text = "تــــــم";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(488, 256);
            this.ControlBox = false;
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.notificationList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView notificationList;
        private System.Windows.Forms.ColumnHeader MessageId;
        private System.Windows.Forms.ColumnHeader noteId;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ColumnHeader noteDesc;
        private System.Windows.Forms.ColumnHeader messageType;
    }
}