
namespace ACS.Archives
{
    partial class AddMultiComments
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMultiComments));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.DeleteDocMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCloseCopyList = new System.Windows.Forms.Button();
            this.CopyList = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.txtFindCopy = new System.Windows.Forms.TextBox();
            this.btnCopyTo = new System.Windows.Forms.Button();
            this.copyToList = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.deleteCopyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.حدفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labSendAs = new System.Windows.Forms.Label();
            this.SendAs = new System.Windows.Forms.ComboBox();
            this.btnAddUsers = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.UsersList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colUserJob = new System.Windows.Forms.ColumnHeader();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Reciptes = new System.Windows.Forms.ListView();
            this.columId = new System.Windows.Forms.ColumnHeader();
            this.columDesc = new System.Windows.Forms.ColumnHeader();
            this.DeleteReciptMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.حــدفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.MessageList = new System.Windows.Forms.ListView();
            this.clmMessageId = new System.Windows.Forms.ColumnHeader();
            this.clmMessageNumber = new System.Windows.Forms.ColumnHeader();
            this.clmMessageTitel = new System.Windows.Forms.ColumnHeader();
            this.clmSentDate = new System.Windows.Forms.ColumnHeader();
            this.clmComesFrom = new System.Windows.Forms.ColumnHeader();
            this.passedBy = new System.Windows.Forms.ColumnHeader();
            this.DeleteDocMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.deleteCopyMenu.SuspendLayout();
            this.DeleteReciptMenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeleteDocMenu
            // 
            this.DeleteDocMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteDocMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteDoc});
            this.DeleteDocMenu.Name = "DeleteDocMenu";
            this.DeleteDocMenu.Size = new System.Drawing.Size(117, 28);
            this.DeleteDocMenu.Text = "حذف";
            // 
            // DeleteDoc
            // 
            this.DeleteDoc.Name = "DeleteDoc";
            this.DeleteDoc.Size = new System.Drawing.Size(116, 24);
            this.DeleteDoc.Text = "حــذف";
            this.DeleteDoc.ToolTipText = "حـــذف";
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtComment.Location = new System.Drawing.Point(88, 336);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.PlaceholderText = "نص التأشيرة";
            this.txtComment.Size = new System.Drawing.Size(648, 45);
            this.txtComment.TabIndex = 46;
            this.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.btnCloseCopyList);
            this.groupBox1.Controls.Add(this.CopyList);
            this.groupBox1.Controls.Add(this.txtFindCopy);
            this.groupBox1.Controls.Add(this.btnCopyTo);
            this.groupBox1.Controls.Add(this.copyToList);
            this.groupBox1.Controls.Add(this.labSendAs);
            this.groupBox1.Controls.Add(this.SendAs);
            this.groupBox1.Controls.Add(this.btnAddUsers);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.UsersList);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.Reciptes);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(756, 440);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات المراسلة";
            // 
            // btnCloseCopyList
            // 
            this.btnCloseCopyList.BackColor = System.Drawing.Color.Red;
            this.btnCloseCopyList.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseCopyList.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseCopyList.Image")));
            this.btnCloseCopyList.Location = new System.Drawing.Point(6, 181);
            this.btnCloseCopyList.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseCopyList.Name = "btnCloseCopyList";
            this.btnCloseCopyList.Size = new System.Drawing.Size(34, 31);
            this.btnCloseCopyList.TabIndex = 57;
            this.btnCloseCopyList.UseVisualStyleBackColor = false;
            this.btnCloseCopyList.Click += new System.EventHandler(this.btnCloseCopyList_Click);
            // 
            // CopyList
            // 
            this.CopyList.BackColor = System.Drawing.Color.White;
            this.CopyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.CopyList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CopyList.FullRowSelect = true;
            this.CopyList.HideSelection = false;
            this.CopyList.Location = new System.Drawing.Point(7, 208);
            this.CopyList.Margin = new System.Windows.Forms.Padding(4);
            this.CopyList.MultiSelect = false;
            this.CopyList.Name = "CopyList";
            this.CopyList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CopyList.RightToLeftLayout = true;
            this.CopyList.Size = new System.Drawing.Size(291, 31);
            this.CopyList.TabIndex = 56;
            this.CopyList.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 1;
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 0;
            this.columnHeader5.Text = "الاسم";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "الوظيفة";
            this.columnHeader6.Width = 230;
            // 
            // txtFindCopy
            // 
            this.txtFindCopy.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFindCopy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFindCopy.Location = new System.Drawing.Point(38, 181);
            this.txtFindCopy.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindCopy.Name = "txtFindCopy";
            this.txtFindCopy.PlaceholderText = "اكتب هنا للبحث عن مستخدم";
            this.txtFindCopy.Size = new System.Drawing.Size(260, 30);
            this.txtFindCopy.TabIndex = 55;
            this.txtFindCopy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFindCopy.TextChanged += new System.EventHandler(this.txtFindCopy_TextChanged);
            // 
            // btnCopyTo
            // 
            this.btnCopyTo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCopyTo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCopyTo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyTo.Image")));
            this.btnCopyTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopyTo.Location = new System.Drawing.Point(263, 120);
            this.btnCopyTo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyTo.Name = "btnCopyTo";
            this.btnCopyTo.Size = new System.Drawing.Size(90, 64);
            this.btnCopyTo.TabIndex = 54;
            this.btnCopyTo.Text = "صورة إلى";
            this.btnCopyTo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyTo.UseVisualStyleBackColor = false;
            this.btnCopyTo.Click += new System.EventHandler(this.btnCopyTo_Click);
            // 
            // copyToList
            // 
            this.copyToList.BackColor = System.Drawing.Color.White;
            this.copyToList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.copyToList.ContextMenuStrip = this.deleteCopyMenu;
            this.copyToList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copyToList.FullRowSelect = true;
            this.copyToList.HideSelection = false;
            this.copyToList.Location = new System.Drawing.Point(7, 134);
            this.copyToList.Margin = new System.Windows.Forms.Padding(4);
            this.copyToList.MultiSelect = false;
            this.copyToList.Name = "copyToList";
            this.copyToList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.copyToList.RightToLeftLayout = true;
            this.copyToList.Size = new System.Drawing.Size(248, 50);
            this.copyToList.TabIndex = 53;
            this.copyToList.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 1;
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 0;
            this.columnHeader8.Text = "";
            this.columnHeader8.Width = 400;
            // 
            // deleteCopyMenu
            // 
            this.deleteCopyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.deleteCopyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حدفToolStripMenuItem});
            this.deleteCopyMenu.Name = "deleteCopyMenu";
            this.deleteCopyMenu.Size = new System.Drawing.Size(111, 28);
            this.deleteCopyMenu.Click += new System.EventHandler(this.deleteCopyMenu_Click);
            // 
            // حدفToolStripMenuItem
            // 
            this.حدفToolStripMenuItem.Name = "حدفToolStripMenuItem";
            this.حدفToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.حدفToolStripMenuItem.Text = "حدف";
            // 
            // labSendAs
            // 
            this.labSendAs.AutoSize = true;
            this.labSendAs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labSendAs.Location = new System.Drawing.Point(605, 81);
            this.labSendAs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSendAs.Name = "labSendAs";
            this.labSendAs.Size = new System.Drawing.Size(101, 23);
            this.labSendAs.TabIndex = 51;
            this.labSendAs.Text = "صفة المرسل";
            // 
            // SendAs
            // 
            this.SendAs.FormattingEnabled = true;
            this.SendAs.Location = new System.Drawing.Point(337, 80);
            this.SendAs.Margin = new System.Windows.Forms.Padding(4);
            this.SendAs.Name = "SendAs";
            this.SendAs.Size = new System.Drawing.Size(266, 28);
            this.SendAs.TabIndex = 50;
            
            // 
            // btnAddUsers
            // 
            this.btnAddUsers.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddUsers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUsers.Image")));
            this.btnAddUsers.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddUsers.Location = new System.Drawing.Point(616, 120);
            this.btnAddUsers.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUsers.Name = "btnAddUsers";
            this.btnAddUsers.Size = new System.Drawing.Size(90, 83);
            this.btnAddUsers.TabIndex = 47;
            this.btnAddUsers.Text = "إرسال إلى";
            this.btnAddUsers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddUsers.UseVisualStyleBackColor = false;
            this.btnAddUsers.Click += new System.EventHandler(this.btnAddUsers_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(369, 204);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 31);
            this.btnClose.TabIndex = 46;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UsersList
            // 
            this.UsersList.BackColor = System.Drawing.Color.White;
            this.UsersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colUserName,
            this.colUserJob});
            this.UsersList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsersList.FullRowSelect = true;
            this.UsersList.HideSelection = false;
            this.UsersList.Location = new System.Drawing.Point(369, 243);
            this.UsersList.Margin = new System.Windows.Forms.Padding(4);
            this.UsersList.MultiSelect = false;
            this.UsersList.Name = "UsersList";
            this.UsersList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UsersList.RightToLeftLayout = true;
            this.UsersList.Size = new System.Drawing.Size(379, 26);
            this.UsersList.TabIndex = 45;
            this.UsersList.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Width = 0;
            // 
            // colUserName
            // 
            this.colUserName.DisplayIndex = 0;
            this.colUserName.Text = "الاسم";
            this.colUserName.Width = 200;
            // 
            // colUserJob
            // 
            this.colUserJob.Text = "الوظيفة";
            this.colUserJob.Width = 230;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(397, 204);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "اكتب هنا للبحث عن مستخدم";
            this.txtSearch.Size = new System.Drawing.Size(337, 30);
            this.txtSearch.TabIndex = 44;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Reciptes
            // 
            this.Reciptes.BackColor = System.Drawing.Color.White;
            this.Reciptes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columId,
            this.columDesc});
            this.Reciptes.ContextMenuStrip = this.DeleteReciptMenu;
            this.Reciptes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Reciptes.FullRowSelect = true;
            this.Reciptes.HideSelection = false;
            this.Reciptes.Location = new System.Drawing.Point(369, 134);
            this.Reciptes.Margin = new System.Windows.Forms.Padding(4);
            this.Reciptes.MultiSelect = false;
            this.Reciptes.Name = "Reciptes";
            this.Reciptes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Reciptes.RightToLeftLayout = true;
            this.Reciptes.Size = new System.Drawing.Size(248, 62);
            this.Reciptes.TabIndex = 43;
            this.Reciptes.UseCompatibleStateImageBehavior = false;
            // 
            // columId
            // 
            this.columId.DisplayIndex = 1;
            this.columId.Width = 0;
            // 
            // columDesc
            // 
            this.columDesc.DisplayIndex = 0;
            this.columDesc.Text = "";
            this.columDesc.Width = 400;
            // 
            // DeleteReciptMenu
            // 
            this.DeleteReciptMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteReciptMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حــدفToolStripMenuItem});
            this.DeleteReciptMenu.Name = "DeleteReciptMenu";
            this.DeleteReciptMenu.Size = new System.Drawing.Size(117, 28);
            this.DeleteReciptMenu.Click += new System.EventHandler(this.DeleteReciptMenu_Click);
            // 
            // حــدفToolStripMenuItem
            // 
            this.حــدفToolStripMenuItem.Name = "حــدفToolStripMenuItem";
            this.حــدفToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.حــدفToolStripMenuItem.Text = "حــدف";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox4.Controls.Add(this.sendMessage);
            this.groupBox4.Location = new System.Drawing.Point(13, 461);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(760, 79);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            // 
            // sendMessage
            // 
            this.sendMessage.BackColor = System.Drawing.Color.DarkOrange;
            this.sendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendMessage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendMessage.Image = ((System.Drawing.Image)(resources.GetObject("sendMessage.Image")));
            this.sendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sendMessage.Location = new System.Drawing.Point(92, 28);
            this.sendMessage.Margin = new System.Windows.Forms.Padding(4);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(567, 41);
            this.sendMessage.TabIndex = 27;
            this.sendMessage.Text = "إرســـال";
            this.sendMessage.UseVisualStyleBackColor = false;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // MessageList
            // 
            this.MessageList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.MessageList.AllowColumnReorder = true;
            this.MessageList.BackColor = System.Drawing.Color.AliceBlue;
            this.MessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMessageId,
            this.clmMessageNumber,
            this.clmMessageTitel,
            this.clmSentDate,
            this.clmComesFrom,
            this.passedBy});
            this.MessageList.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MessageList.FullRowSelect = true;
            this.MessageList.GridLines = true;
            this.MessageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MessageList.HideSelection = false;
            this.MessageList.HoverSelection = true;
            listViewItem2.StateImageIndex = 0;
            this.MessageList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.MessageList.LabelWrap = false;
            this.MessageList.Location = new System.Drawing.Point(787, 13);
            this.MessageList.Margin = new System.Windows.Forms.Padding(4);
            this.MessageList.Name = "MessageList";
            this.MessageList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MessageList.RightToLeftLayout = true;
            this.MessageList.Size = new System.Drawing.Size(350, 696);
            this.MessageList.TabIndex = 47;
            this.MessageList.UseCompatibleStateImageBehavior = false;
            // 
            // clmMessageId
            // 
            this.clmMessageId.DisplayIndex = 5;
            this.clmMessageId.Text = "message id";
            this.clmMessageId.Width = 50;
            // 
            // clmMessageNumber
            // 
            this.clmMessageNumber.DisplayIndex = 0;
            this.clmMessageNumber.Text = "رقم الرسالة";
            this.clmMessageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmMessageNumber.Width = 230;
            // 
            // clmMessageTitel
            // 
            this.clmMessageTitel.DisplayIndex = 1;
            this.clmMessageTitel.Text = "موضوع الرسالة";
            this.clmMessageTitel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmMessageTitel.Width = 400;
            // 
            // clmSentDate
            // 
            this.clmSentDate.DisplayIndex = 2;
            this.clmSentDate.Text = "تاريخ الإرسال";
            this.clmSentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmSentDate.Width = 200;
            // 
            // clmComesFrom
            // 
            this.clmComesFrom.DisplayIndex = 3;
            this.clmComesFrom.Text = "المرسل";
            this.clmComesFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmComesFrom.Width = 350;
            // 
            // passedBy
            // 
            this.passedBy.DisplayIndex = 4;
            this.passedBy.Text = "عن طريق";
            this.passedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passedBy.Width = 350;
            // 
            // AddMultiComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 722);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMultiComments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "شاشة إعادة توجيه المراسلات";
            this.Load += new System.EventHandler(this.AddMultiComments_Load);
            this.DeleteDocMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.deleteCopyMenu.ResumeLayout(false);
            this.DeleteReciptMenu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCloseCopyList;
        private System.Windows.Forms.ListView CopyList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtFindCopy;
        private System.Windows.Forms.Button btnCopyTo;
        private System.Windows.Forms.ListView copyToList;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label labSendAs;
        private System.Windows.Forms.ComboBox SendAs;
        private System.Windows.Forms.Button btnAddUsers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView UsersList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colUserJob;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView Reciptes;
        private System.Windows.Forms.ColumnHeader columId;
        private System.Windows.Forms.ColumnHeader columDesc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.ListView MessageList;
        private System.Windows.Forms.ColumnHeader clmMessageId;
        private System.Windows.Forms.ColumnHeader clmMessageNumber;
        private System.Windows.Forms.ColumnHeader clmMessageTitel;
        private System.Windows.Forms.ColumnHeader clmSentDate;
        private System.Windows.Forms.ColumnHeader clmComesFrom;
        private System.Windows.Forms.ColumnHeader passedBy;
        private System.Windows.Forms.ContextMenuStrip DeleteDocMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteDoc;
        private System.Windows.Forms.ContextMenuStrip DeleteReciptMenu;
        private System.Windows.Forms.ToolStripMenuItem حــدفToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip deleteCopyMenu;
        private System.Windows.Forms.ToolStripMenuItem حدفToolStripMenuItem;
    }
}