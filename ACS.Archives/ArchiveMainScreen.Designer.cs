
namespace ACS.Archives
{
    partial class ArchiveMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveMainScreen));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.nevigationPnl = new System.Windows.Forms.Panel();
            this.btnDeleMessage = new System.Windows.Forms.Button();
            this.btnRep = new System.Windows.Forms.Button();
            this.btnDeletedMessages = new System.Windows.Forms.Button();
            this.txtMessageType = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdvSearch = new System.Windows.Forms.Button();
            this.btnEixt = new System.Windows.Forms.Button();
            this.btnOutSideMessages = new System.Windows.Forms.Button();
            this.btnOutbox = new System.Windows.Forms.Button();
            this.btnInbox = new System.Windows.Forms.Button();
            this.btnNewMessage = new System.Windows.Forms.Button();
            this.DeleteMessagesSetting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.استرجاعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حدفنهائيToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.افراغسلةالمحدوفاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footerPnl = new System.Windows.Forms.Panel();
            this.CopyRightLab = new System.Windows.Forms.Label();
            this.labUserDesc = new System.Windows.Forms.Label();
            this.tlReply = new System.Windows.Forms.ToolTip(this.components);
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.rdRead = new System.Windows.Forms.RadioButton();
            this.rdReply = new System.Windows.Forms.RadioButton();
            this.rdToday = new System.Windows.Forms.RadioButton();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.notifi = new System.Windows.Forms.PictureBox();
            this.systemName = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.mailType = new System.Windows.Forms.Label();
            this.boxCountLab = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFindMessage = new System.Windows.Forms.TextBox();
            this.headerpnl = new System.Windows.Forms.Panel();
            this.btnBackColor = new System.Windows.Forms.LinkLabel();
            this.LabNotifi = new System.Windows.Forms.Label();
            this.showGroup = new System.Windows.Forms.GroupBox();
            this.clmMessageId = new System.Windows.Forms.ColumnHeader();
            this.clmMessageNumber = new System.Windows.Forms.ColumnHeader();
            this.clmMessageTitel = new System.Windows.Forms.ColumnHeader();
            this.clmSentDate = new System.Windows.Forms.ColumnHeader();
            this.clmComesFrom = new System.Windows.Forms.ColumnHeader();
            this.passedBy = new System.Windows.Forms.ColumnHeader();
            this.MessageList = new System.Windows.Forms.ListView();
            this.MultiCommentMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.إعادةتوجيهمراسلةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.nevigationPnl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DeleteMessagesSetting.SuspendLayout();
            this.footerPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.headerpnl.SuspendLayout();
            this.showGroup.SuspendLayout();
            this.MultiCommentMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // nevigationPnl
            // 
            this.nevigationPnl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nevigationPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nevigationPnl.Controls.Add(this.btnDeleMessage);
            this.nevigationPnl.Controls.Add(this.btnRep);
            this.nevigationPnl.Controls.Add(this.btnDeletedMessages);
            this.nevigationPnl.Controls.Add(this.txtMessageType);
            this.nevigationPnl.Controls.Add(this.groupBox1);
            this.nevigationPnl.Controls.Add(this.btnOutSideMessages);
            this.nevigationPnl.Controls.Add(this.btnOutbox);
            this.nevigationPnl.Controls.Add(this.btnInbox);
            this.nevigationPnl.Controls.Add(this.btnNewMessage);
            this.nevigationPnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.nevigationPnl.Location = new System.Drawing.Point(1089, 0);
            this.nevigationPnl.Name = "nevigationPnl";
            this.nevigationPnl.Size = new System.Drawing.Size(240, 727);
            this.nevigationPnl.TabIndex = 0;
            // 
            // btnDeleMessage
            // 
            this.btnDeleMessage.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleMessage.Image")));
            this.btnDeleMessage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleMessage.Location = new System.Drawing.Point(24, 339);
            this.btnDeleMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleMessage.Name = "btnDeleMessage";
            this.btnDeleMessage.Size = new System.Drawing.Size(191, 47);
            this.btnDeleMessage.TabIndex = 26;
            this.btnDeleMessage.Text = "حـــدف مراسلة";
            this.btnDeleMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleMessage.UseVisualStyleBackColor = false;
            this.btnDeleMessage.Click += new System.EventHandler(this.btnDeleMessage_Click);
            // 
            // btnRep
            // 
            this.btnRep.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRep.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRep.Location = new System.Drawing.Point(17, 415);
            this.btnRep.Margin = new System.Windows.Forms.Padding(4);
            this.btnRep.Name = "btnRep";
            this.btnRep.Size = new System.Drawing.Size(191, 47);
            this.btnRep.TabIndex = 25;
            this.btnRep.Text = "طباعة نمودج إحالة";
            this.btnRep.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRep.UseVisualStyleBackColor = false;
            this.btnRep.Click += new System.EventHandler(this.btnRep_Click);
            // 
            // btnDeletedMessages
            // 
            this.btnDeletedMessages.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDeletedMessages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeletedMessages.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletedMessages.Image")));
            this.btnDeletedMessages.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeletedMessages.Location = new System.Drawing.Point(17, 342);
            this.btnDeletedMessages.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletedMessages.Name = "btnDeletedMessages";
            this.btnDeletedMessages.Size = new System.Drawing.Size(191, 47);
            this.btnDeletedMessages.TabIndex = 24;
            this.btnDeletedMessages.Text = "المراسلات المحدوفة";
            this.btnDeletedMessages.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeletedMessages.UseVisualStyleBackColor = false;
            this.btnDeletedMessages.Click += new System.EventHandler(this.btnDeletedMessages_Click);
            // 
            // txtMessageType
            // 
            this.txtMessageType.Location = new System.Drawing.Point(55, 3);
            this.txtMessageType.Name = "txtMessageType";
            this.txtMessageType.Size = new System.Drawing.Size(125, 27);
            this.txtMessageType.TabIndex = 23;
            this.txtMessageType.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnAdvSearch);
            this.groupBox1.Controls.Add(this.btnEixt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 469);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 256);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(17, 94);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 47);
            this.button1.TabIndex = 19;
            this.button1.Text = "تغيير الرمز السري";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdvSearch
            // 
            this.btnAdvSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.btnAdvSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdvSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnAdvSearch.Image")));
            this.btnAdvSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdvSearch.Location = new System.Drawing.Point(17, 24);
            this.btnAdvSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdvSearch.Name = "btnAdvSearch";
            this.btnAdvSearch.Size = new System.Drawing.Size(191, 46);
            this.btnAdvSearch.TabIndex = 18;
            this.btnAdvSearch.Text = "بحث في الأرشيف";
            this.btnAdvSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdvSearch.UseVisualStyleBackColor = false;
            this.btnAdvSearch.Click += new System.EventHandler(this.btnAdvSearch_Click);
            // 
            // btnEixt
            // 
            this.btnEixt.BackColor = System.Drawing.Color.Red;
            this.btnEixt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEixt.Image = ((System.Drawing.Image)(resources.GetObject("btnEixt.Image")));
            this.btnEixt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEixt.Location = new System.Drawing.Point(17, 175);
            this.btnEixt.Margin = new System.Windows.Forms.Padding(4);
            this.btnEixt.Name = "btnEixt";
            this.btnEixt.Size = new System.Drawing.Size(191, 49);
            this.btnEixt.TabIndex = 17;
            this.btnEixt.Text = "تسجيل الخروج";
            this.btnEixt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEixt.UseVisualStyleBackColor = false;
            this.btnEixt.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnOutSideMessages
            // 
            this.btnOutSideMessages.BackColor = System.Drawing.Color.DarkOrange;
            this.btnOutSideMessages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOutSideMessages.Image = ((System.Drawing.Image)(resources.GetObject("btnOutSideMessages.Image")));
            this.btnOutSideMessages.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOutSideMessages.Location = new System.Drawing.Point(17, 279);
            this.btnOutSideMessages.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutSideMessages.Name = "btnOutSideMessages";
            this.btnOutSideMessages.Size = new System.Drawing.Size(191, 55);
            this.btnOutSideMessages.TabIndex = 19;
            this.btnOutSideMessages.Text = "المراسلات الخارجية";
            this.btnOutSideMessages.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOutSideMessages.UseVisualStyleBackColor = false;
            this.btnOutSideMessages.Click += new System.EventHandler(this.btnOutSideMessages_Click);
            // 
            // btnOutbox
            // 
            this.btnOutbox.BackColor = System.Drawing.Color.DarkOrange;
            this.btnOutbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOutbox.Image = ((System.Drawing.Image)(resources.GetObject("btnOutbox.Image")));
            this.btnOutbox.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOutbox.Location = new System.Drawing.Point(17, 219);
            this.btnOutbox.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutbox.Name = "btnOutbox";
            this.btnOutbox.Size = new System.Drawing.Size(191, 52);
            this.btnOutbox.TabIndex = 16;
            this.btnOutbox.Text = "البريد الصادر";
            this.btnOutbox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOutbox.UseVisualStyleBackColor = false;
            this.btnOutbox.Click += new System.EventHandler(this.btnOutbox_Click);
            // 
            // btnInbox
            // 
            this.btnInbox.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInbox.Image = ((System.Drawing.Image)(resources.GetObject("btnInbox.Image")));
            this.btnInbox.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInbox.Location = new System.Drawing.Point(17, 157);
            this.btnInbox.Margin = new System.Windows.Forms.Padding(4);
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Size = new System.Drawing.Size(191, 45);
            this.btnInbox.TabIndex = 15;
            this.btnInbox.Text = "البريد الوارد";
            this.btnInbox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInbox.UseVisualStyleBackColor = false;
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // btnNewMessage
            // 
            this.btnNewMessage.BackColor = System.Drawing.Color.DarkOrange;
            this.btnNewMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnNewMessage.Image")));
            this.btnNewMessage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewMessage.Location = new System.Drawing.Point(17, 48);
            this.btnNewMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewMessage.Name = "btnNewMessage";
            this.btnNewMessage.Size = new System.Drawing.Size(191, 49);
            this.btnNewMessage.TabIndex = 14;
            this.btnNewMessage.Text = "مراسلة جديدة";
            this.btnNewMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewMessage.UseVisualStyleBackColor = false;
            this.btnNewMessage.Click += new System.EventHandler(this.btnNewMessage_Click);
            // 
            // DeleteMessagesSetting
            // 
            this.DeleteMessagesSetting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteMessagesSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.استرجاعToolStripMenuItem,
            this.حدفنهائيToolStripMenuItem,
            this.افراغسلةالمحدوفاتToolStripMenuItem});
            this.DeleteMessagesSetting.Name = "DeleteReciptMenu";
            this.DeleteMessagesSetting.Size = new System.Drawing.Size(211, 76);
            this.DeleteMessagesSetting.Opening += new System.ComponentModel.CancelEventHandler(this.DeleteMessagesSetting_Opening);
            // 
            // استرجاعToolStripMenuItem
            // 
            this.استرجاعToolStripMenuItem.Name = "استرجاعToolStripMenuItem";
            this.استرجاعToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.استرجاعToolStripMenuItem.Text = "استرجاع المراسلة";
            this.استرجاعToolStripMenuItem.Click += new System.EventHandler(this.استرجاعToolStripMenuItem_Click);
            // 
            // حدفنهائيToolStripMenuItem
            // 
            this.حدفنهائيToolStripMenuItem.Name = "حدفنهائيToolStripMenuItem";
            this.حدفنهائيToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.حدفنهائيToolStripMenuItem.Text = "حدف نهائي";
            this.حدفنهائيToolStripMenuItem.Visible = false;
            this.حدفنهائيToolStripMenuItem.Click += new System.EventHandler(this.حدفنهائيToolStripMenuItem_Click);
            // 
            // افراغسلةالمحدوفاتToolStripMenuItem
            // 
            this.افراغسلةالمحدوفاتToolStripMenuItem.Name = "افراغسلةالمحدوفاتToolStripMenuItem";
            this.افراغسلةالمحدوفاتToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.افراغسلةالمحدوفاتToolStripMenuItem.Text = "افراغ سلة المحدوفات";
            this.افراغسلةالمحدوفاتToolStripMenuItem.Visible = false;
            this.افراغسلةالمحدوفاتToolStripMenuItem.Click += new System.EventHandler(this.افراغسلةالمحدوفاتToolStripMenuItem_Click);
            // 
            // footerPnl
            // 
            this.footerPnl.BackColor = System.Drawing.Color.Tan;
            this.footerPnl.Controls.Add(this.CopyRightLab);
            this.footerPnl.Controls.Add(this.labUserDesc);
            this.footerPnl.Location = new System.Drawing.Point(12, 655);
            this.footerPnl.Name = "footerPnl";
            this.footerPnl.Size = new System.Drawing.Size(1053, 68);
            this.footerPnl.TabIndex = 25;
            // 
            // CopyRightLab
            // 
            this.CopyRightLab.AutoSize = true;
            this.CopyRightLab.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CopyRightLab.ForeColor = System.Drawing.Color.DodgerBlue;
            this.CopyRightLab.Location = new System.Drawing.Point(12, 12);
            this.CopyRightLab.Name = "CopyRightLab";
            this.CopyRightLab.Size = new System.Drawing.Size(344, 31);
            this.CopyRightLab.TabIndex = 4;
            this.CopyRightLab.Text = "جميع الحقوق محفوظة للشركة الليبية للحديد والصلب 2022";
            this.CopyRightLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUserDesc
            // 
            this.labUserDesc.AutoSize = true;
            this.labUserDesc.BackColor = System.Drawing.Color.Tan;
            this.labUserDesc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labUserDesc.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labUserDesc.Location = new System.Drawing.Point(897, 12);
            this.labUserDesc.Name = "labUserDesc";
            this.labUserDesc.Size = new System.Drawing.Size(128, 23);
            this.labUserDesc.TabIndex = 3;
            this.labUserDesc.Text = "المستخدم الحالي";
            this.labUserDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlReply
            // 
            this.tlReply.BackColor = System.Drawing.Color.Orange;
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.BackColor = System.Drawing.Color.DodgerBlue;
            this.rdAll.Checked = true;
            this.rdAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdAll.Image = ((System.Drawing.Image)(resources.GetObject("rdAll.Image")));
            this.rdAll.Location = new System.Drawing.Point(369, 21);
            this.rdAll.Name = "rdAll";
            this.rdAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdAll.Size = new System.Drawing.Size(65, 48);
            this.rdAll.TabIndex = 0;
            this.rdAll.TabStop = true;
            this.tlReply.SetToolTip(this.rdAll, "عرض كل البريد");
            this.rdAll.UseVisualStyleBackColor = false;
            this.rdAll.CheckedChanged += new System.EventHandler(this.rdAll_CheckedChanged);
            // 
            // rdRead
            // 
            this.rdRead.AutoSize = true;
            this.rdRead.BackColor = System.Drawing.Color.DodgerBlue;
            this.rdRead.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdRead.Image = ((System.Drawing.Image)(resources.GetObject("rdRead.Image")));
            this.rdRead.Location = new System.Drawing.Point(141, 21);
            this.rdRead.Name = "rdRead";
            this.rdRead.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdRead.Size = new System.Drawing.Size(65, 48);
            this.rdRead.TabIndex = 1;
            this.tlReply.SetToolTip(this.rdRead, "بريد غير مقروؤ");
            this.rdRead.UseVisualStyleBackColor = false;
            this.rdRead.CheckedChanged += new System.EventHandler(this.rdRead_CheckedChanged);
            // 
            // rdReply
            // 
            this.rdReply.AutoSize = true;
            this.rdReply.BackColor = System.Drawing.Color.DodgerBlue;
            this.rdReply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdReply.Image = ((System.Drawing.Image)(resources.GetObject("rdReply.Image")));
            this.rdReply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdReply.Location = new System.Drawing.Point(25, 21);
            this.rdReply.Name = "rdReply";
            this.rdReply.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdReply.Size = new System.Drawing.Size(65, 48);
            this.rdReply.TabIndex = 2;
            this.tlReply.SetToolTip(this.rdReply, "بريد لم يتم الرد عليه");
            this.rdReply.UseVisualStyleBackColor = false;
            this.rdReply.CheckedChanged += new System.EventHandler(this.rdReply_CheckedChanged);
            // 
            // rdToday
            // 
            this.rdToday.AutoSize = true;
            this.rdToday.BackColor = System.Drawing.Color.DodgerBlue;
            this.rdToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdToday.Image = ((System.Drawing.Image)(resources.GetObject("rdToday.Image")));
            this.rdToday.Location = new System.Drawing.Point(255, 21);
            this.rdToday.Name = "rdToday";
            this.rdToday.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdToday.Size = new System.Drawing.Size(65, 48);
            this.rdToday.TabIndex = 3;
            this.tlReply.SetToolTip(this.rdToday, "بريد اليوم");
            this.rdToday.UseVisualStyleBackColor = false;
            this.rdToday.CheckedChanged += new System.EventHandler(this.rdToday_CheckedChanged);
            // 
            // refresh
            // 
            this.refresh.Image = ((System.Drawing.Image)(resources.GetObject("refresh.Image")));
            this.refresh.Location = new System.Drawing.Point(173, 76);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(54, 52);
            this.refresh.TabIndex = 29;
            this.refresh.TabStop = false;
            this.tlReply.SetToolTip(this.refresh, "تحديث");
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // notifi
            // 
            this.notifi.Image = ((System.Drawing.Image)(resources.GetObject("notifi.Image")));
            this.notifi.Location = new System.Drawing.Point(86, 76);
            this.notifi.Name = "notifi";
            this.notifi.Size = new System.Drawing.Size(54, 49);
            this.notifi.TabIndex = 30;
            this.notifi.TabStop = false;
            this.tlReply.SetToolTip(this.notifi, "تنبيهات");
            this.notifi.Click += new System.EventHandler(this.notifi_Click);
            // 
            // systemName
            // 
            this.systemName.AutoSize = true;
            this.systemName.BackColor = System.Drawing.Color.Tan;
            this.systemName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.systemName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.systemName.Location = new System.Drawing.Point(901, 59);
            this.systemName.Name = "systemName";
            this.systemName.Size = new System.Drawing.Size(183, 28);
            this.systemName.TabIndex = 3;
            this.systemName.Text = "نظام إدارة المراسلات";
            this.systemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Tan;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(974, 17);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(63, 37);
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // mailType
            // 
            this.mailType.AutoSize = true;
            this.mailType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mailType.ForeColor = System.Drawing.Color.Black;
            this.mailType.Location = new System.Drawing.Point(790, 38);
            this.mailType.Name = "mailType";
            this.mailType.Size = new System.Drawing.Size(79, 23);
            this.mailType.TabIndex = 2;
            this.mailType.Text = "نوع البريد";
            this.mailType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxCountLab
            // 
            this.boxCountLab.AutoSize = true;
            this.boxCountLab.BackColor = System.Drawing.Color.DarkOrange;
            this.boxCountLab.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.boxCountLab.Location = new System.Drawing.Point(745, 45);
            this.boxCountLab.Name = "boxCountLab";
            this.boxCountLab.Size = new System.Drawing.Size(20, 23);
            this.boxCountLab.TabIndex = 23;
            this.boxCountLab.Text = "0";
            this.boxCountLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(13, 38);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 34);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "بحث";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFindMessage
            // 
            this.txtFindMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFindMessage.Location = new System.Drawing.Point(103, 38);
            this.txtFindMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindMessage.Name = "txtFindMessage";
            this.txtFindMessage.Size = new System.Drawing.Size(144, 34);
            this.txtFindMessage.TabIndex = 27;
            this.txtFindMessage.TextChanged += new System.EventHandler(this.txtFindMessage_TextChanged);
            // 
            // headerpnl
            // 
            this.headerpnl.BackColor = System.Drawing.Color.Tan;
            this.headerpnl.Controls.Add(this.btnBackColor);
            this.headerpnl.Controls.Add(this.LabNotifi);
            this.headerpnl.Controls.Add(this.notifi);
            this.headerpnl.Controls.Add(this.refresh);
            this.headerpnl.Controls.Add(this.txtFindMessage);
            this.headerpnl.Controls.Add(this.btnSearch);
            this.headerpnl.Controls.Add(this.showGroup);
            this.headerpnl.Controls.Add(this.boxCountLab);
            this.headerpnl.Controls.Add(this.mailType);
            this.headerpnl.Controls.Add(this.logo);
            this.headerpnl.Controls.Add(this.systemName);
            this.headerpnl.Location = new System.Drawing.Point(0, 4);
            this.headerpnl.Name = "headerpnl";
            this.headerpnl.Size = new System.Drawing.Size(1083, 128);
            this.headerpnl.TabIndex = 23;
            this.headerpnl.Paint += new System.Windows.Forms.PaintEventHandler(this.headerpnl_Paint);
            // 
            // btnBackColor
            // 
            this.btnBackColor.AutoSize = true;
            this.btnBackColor.BackColor = System.Drawing.Color.Tan;
            this.btnBackColor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBackColor.LinkColor = System.Drawing.Color.Crimson;
            this.btnBackColor.Location = new System.Drawing.Point(777, 86);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(131, 23);
            this.btnBackColor.TabIndex = 32;
            this.btnBackColor.TabStop = true;
            this.btnBackColor.Text = "تغيير لون الخلفية";
            this.btnBackColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnBackColor_LinkClicked);
            // 
            // LabNotifi
            // 
            this.LabNotifi.AutoSize = true;
            this.LabNotifi.BackColor = System.Drawing.Color.DarkOrange;
            this.LabNotifi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabNotifi.Location = new System.Drawing.Point(46, 96);
            this.LabNotifi.Name = "LabNotifi";
            this.LabNotifi.Size = new System.Drawing.Size(20, 23);
            this.LabNotifi.TabIndex = 31;
            this.LabNotifi.Text = "0";
            this.LabNotifi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabNotifi.Visible = false;
            // 
            // showGroup
            // 
            this.showGroup.Controls.Add(this.rdToday);
            this.showGroup.Controls.Add(this.rdReply);
            this.showGroup.Controls.Add(this.rdRead);
            this.showGroup.Controls.Add(this.rdAll);
            this.showGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showGroup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.showGroup.ForeColor = System.Drawing.Color.Black;
            this.showGroup.Location = new System.Drawing.Point(254, 25);
            this.showGroup.Name = "showGroup";
            this.showGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.showGroup.Size = new System.Drawing.Size(470, 87);
            this.showGroup.TabIndex = 24;
            this.showGroup.TabStop = false;
            this.showGroup.Text = "تصنيف  حسب";
            // 
            // clmMessageId
            // 
            this.clmMessageId.DisplayIndex = 5;
            this.clmMessageId.Text = "message id";
            this.clmMessageId.Width = 0;
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
            // MessageList
            // 
            this.MessageList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.MessageList.AllowColumnReorder = true;
            this.MessageList.BackColor = System.Drawing.SystemColors.Window;
            this.MessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMessageId,
            this.clmMessageNumber,
            this.clmMessageTitel,
            this.clmSentDate,
            this.clmComesFrom,
            this.passedBy});
            this.MessageList.ContextMenuStrip = this.MultiCommentMenu;
            this.MessageList.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MessageList.FullRowSelect = true;
            this.MessageList.GridLines = true;
            this.MessageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MessageList.HideSelection = false;
            this.MessageList.HoverSelection = true;
            listViewItem1.StateImageIndex = 0;
            this.MessageList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.MessageList.LabelWrap = false;
            this.MessageList.Location = new System.Drawing.Point(30, 157);
            this.MessageList.Margin = new System.Windows.Forms.Padding(4);
            this.MessageList.Name = "MessageList";
            this.MessageList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MessageList.RightToLeftLayout = true;
            this.MessageList.Size = new System.Drawing.Size(1052, 233);
            this.MessageList.TabIndex = 24;
            this.MessageList.UseCompatibleStateImageBehavior = false;
            this.MessageList.Click += new System.EventHandler(this.MessageList_Click);
            // 
            // MultiCommentMenu
            // 
            this.MultiCommentMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MultiCommentMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إعادةتوجيهمراسلةToolStripMenuItem});
            this.MultiCommentMenu.Name = "MultiCommentMenu";
            this.MultiCommentMenu.Size = new System.Drawing.Size(199, 28);
            this.MultiCommentMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MultiCommentMenu_Opening);
            // 
            // إعادةتوجيهمراسلةToolStripMenuItem
            // 
            this.إعادةتوجيهمراسلةToolStripMenuItem.Name = "إعادةتوجيهمراسلةToolStripMenuItem";
            this.إعادةتوجيهمراسلةToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.إعادةتوجيهمراسلةToolStripMenuItem.Text = "إعادة توجيه مراسلة";
            this.إعادةتوجيهمراسلةToolStripMenuItem.Click += new System.EventHandler(this.إعادةتوجيهمراسلةToolStripMenuItem_Click);
            // 
            // ArchiveMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1329, 727);
            this.Controls.Add(this.footerPnl);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.headerpnl);
            this.Controls.Add(this.nevigationPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ArchiveMainScreen";
            this.Text = "نظام إدارة المراسلات( V 24.01.01 ) ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ArchiveMainScreen_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ArchiveMainScreen_KeyPress);
            this.nevigationPnl.ResumeLayout(false);
            this.nevigationPnl.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.DeleteMessagesSetting.ResumeLayout(false);
            this.footerPnl.ResumeLayout(false);
            this.footerPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.headerpnl.ResumeLayout(false);
            this.headerpnl.PerformLayout();
            this.showGroup.ResumeLayout(false);
            this.showGroup.PerformLayout();
            this.MultiCommentMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel nevigationPnl;
        private System.Windows.Forms.Button btnOutSideMessages;
        private System.Windows.Forms.Button btnAdvSearch;
        private System.Windows.Forms.Button btnEixt;
        private System.Windows.Forms.Button btnOutbox;
        private System.Windows.Forms.Button btnInbox;
        private System.Windows.Forms.Button btnNewMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMessageType;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn serailNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender;
        private System.Windows.Forms.Panel footerPnl;
        private System.Windows.Forms.Label CopyRightLab;
        private System.Windows.Forms.Label labUserDesc;
        private System.Windows.Forms.ToolTip tlReply;
        private System.Windows.Forms.Button btnDeletedMessages;
        private System.Windows.Forms.Label systemName;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label mailType;
        private System.Windows.Forms.Label boxCountLab;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFindMessage;
        private System.Windows.Forms.Panel headerpnl;
        private System.Windows.Forms.GroupBox showGroup;
        private System.Windows.Forms.RadioButton rdToday;
        private System.Windows.Forms.RadioButton rdReply;
        private System.Windows.Forms.RadioButton rdRead;
        private System.Windows.Forms.RadioButton rdAll;
        private System.Windows.Forms.ContextMenuStrip DeleteMessagesSetting;
        private System.Windows.Forms.ToolStripMenuItem استرجاعToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حدفنهائيToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem افراغسلةالمحدوفاتToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox refresh;
        private System.Windows.Forms.Label LabNotifi;
        private System.Windows.Forms.PictureBox notifi;
        private System.Windows.Forms.ColumnHeader clmMessageId;
        private System.Windows.Forms.ColumnHeader clmMessageNumber;
        private System.Windows.Forms.ColumnHeader clmMessageTitel;
        private System.Windows.Forms.ColumnHeader clmSentDate;
        private System.Windows.Forms.ColumnHeader clmComesFrom;
        private System.Windows.Forms.ColumnHeader passedBy;
        private System.Windows.Forms.ListView MessageList;
        private System.Windows.Forms.Button btnRep;
        private System.Windows.Forms.ContextMenuStrip MultiCommentMenu;
        private System.Windows.Forms.ToolStripMenuItem إعادةتوجيهمراسلةToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.LinkLabel btnBackColor;
        private System.Windows.Forms.Button btnDeleMessage;
        private System.Windows.Forms.Label labInboxCount;
    }
}