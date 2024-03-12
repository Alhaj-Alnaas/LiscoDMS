
namespace ACS.Archives
{
    partial class mainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainScreen));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings1 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings1 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            this.DeleteMessageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDocMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outbox = new System.Windows.Forms.RadioButton();
            this.Inbox = new System.Windows.Forms.RadioButton();
            this.MessageList = new System.Windows.Forms.ListView();
            this.clmMessageId = new System.Windows.Forms.ColumnHeader();
            this.clmMessageNumber = new System.Windows.Forms.ColumnHeader();
            this.clmMessageTitel = new System.Windows.Forms.ColumnHeader();
            this.clmSentDate = new System.Windows.Forms.ColumnHeader();
            this.clmComesFrom = new System.Windows.Forms.ColumnHeader();
            this.clmSentTo = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCloseCopyList = new System.Windows.Forms.Button();
            this.CopyList = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.txtFindCopy = new System.Windows.Forms.TextBox();
            this.btnCopyTo = new System.Windows.Forms.Button();
            this.copyToList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.deleteCopyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.حدفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMessageId = new System.Windows.Forms.TextBox();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.MessageSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MessageSender = new System.Windows.Forms.ComboBox();
            this.SendDate = new System.Windows.Forms.DateTimePicker();
            this.MessageSerialNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labComeFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clmId = new System.Windows.Forms.ColumnHeader();
            this.clmFileName = new System.Windows.Forms.ColumnHeader();
            this.clmFileExtention = new System.Windows.Forms.ColumnHeader();
            this.clmFileSize = new System.Windows.Forms.ColumnHeader();
            this.clmFilePath = new System.Windows.Forms.ColumnHeader();
            this.DocList = new System.Windows.Forms.ListView();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnScanFile = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DeleteMessageMenu.SuspendLayout();
            this.DeleteDocMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.deleteCopyMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "pdf";
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.Title = "Select file";
            // 
            // DeleteMessageMenu
            // 
            this.DeleteMessageMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteMessageMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMessage});
            this.DeleteMessageMenu.Name = "contextMenuStrip1";
            this.DeleteMessageMenu.Size = new System.Drawing.Size(117, 28);
            this.DeleteMessageMenu.Text = "حذف";
            this.DeleteMessageMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip1_MouseClick);
            // 
            // deleteMessage
            // 
            this.deleteMessage.Name = "deleteMessage";
            this.deleteMessage.Size = new System.Drawing.Size(116, 24);
            this.deleteMessage.Text = "حــذف";
            this.deleteMessage.ToolTipText = "حــذف";
            // 
            // DeleteDocMenu
            // 
            this.DeleteDocMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteDocMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteDoc});
            this.DeleteDocMenu.Name = "DeleteDocMenu";
            this.DeleteDocMenu.Size = new System.Drawing.Size(117, 28);
            this.DeleteDocMenu.Text = "حذف";
            this.DeleteDocMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteDocMenu_MouseClick);
            // 
            // DeleteDoc
            // 
            this.DeleteDoc.Name = "DeleteDoc";
            this.DeleteDoc.Size = new System.Drawing.Size(116, 24);
            this.DeleteDoc.Text = "حــذف";
            this.DeleteDoc.ToolTipText = "حـــذف";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(1567, 14);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 52);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.btnCard);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Location = new System.Drawing.Point(41, 13);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(1870, 74);
            this.panel3.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(1218, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 52);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.Location = new System.Drawing.Point(1409, 11);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 52);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "تعديــل";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(25, 20);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(202, 41);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "بحث في الأرشيف";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCard.Image = ((System.Drawing.Image)(resources.GetObject("btnCard.Image")));
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCard.Location = new System.Drawing.Point(1026, 11);
            this.btnCard.Margin = new System.Windows.Forms.Padding(4);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(172, 52);
            this.btnCard.TabIndex = 14;
            this.btnCard.Text = "بطاقة إجراءات";
            this.btnCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkOrange;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(1725, 14);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 52);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "جـــديد";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox3.Controls.Add(this.outbox);
            this.groupBox3.Controls.Add(this.Inbox);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(953, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(931, 84);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تصنيف البريد";
            // 
            // outbox
            // 
            this.outbox.AutoSize = true;
            this.outbox.Checked = true;
            this.outbox.Location = new System.Drawing.Point(708, 43);
            this.outbox.Margin = new System.Windows.Forms.Padding(4);
            this.outbox.Name = "outbox";
            this.outbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.outbox.Size = new System.Drawing.Size(275, 29);
            this.outbox.TabIndex = 0;
            this.outbox.TabStop = true;
            this.outbox.Text = "صادر من الشركة إلى جهة خارجية";
            this.outbox.UseVisualStyleBackColor = true;
            this.outbox.CheckedChanged += new System.EventHandler(this.outbox_CheckedChanged);
            // 
            // Inbox
            // 
            this.Inbox.AutoSize = true;
            this.Inbox.Location = new System.Drawing.Point(397, 43);
            this.Inbox.Margin = new System.Windows.Forms.Padding(4);
            this.Inbox.Name = "Inbox";
            this.Inbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Inbox.Size = new System.Drawing.Size(264, 29);
            this.Inbox.TabIndex = 1;
            this.Inbox.Text = "وارد إلى الشركة من جهة خارجية";
            this.Inbox.UseVisualStyleBackColor = true;
            this.Inbox.CheckedChanged += new System.EventHandler(this.Inbox_CheckedChanged);
            // 
            // MessageList
            // 
            this.MessageList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.MessageList.AllowColumnReorder = true;
            this.MessageList.BackColor = System.Drawing.Color.White;
            this.MessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMessageId,
            this.clmMessageNumber,
            this.clmMessageTitel,
            this.clmSentDate,
            this.clmComesFrom,
            this.clmSentTo});
            this.MessageList.ContextMenuStrip = this.DeleteMessageMenu;
            this.MessageList.FullRowSelect = true;
            this.MessageList.GridLines = true;
            this.MessageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MessageList.HideSelection = false;
            this.MessageList.HoverSelection = true;
            this.MessageList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.MessageList.Location = new System.Drawing.Point(953, 465);
            this.MessageList.Margin = new System.Windows.Forms.Padding(4);
            this.MessageList.MultiSelect = false;
            this.MessageList.Name = "MessageList";
            this.MessageList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MessageList.RightToLeftLayout = true;
            this.MessageList.ShowItemToolTips = true;
            this.MessageList.Size = new System.Drawing.Size(931, 539);
            this.MessageList.TabIndex = 4;
            this.MessageList.UseCompatibleStateImageBehavior = false;
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
            this.clmMessageNumber.Width = 175;
            // 
            // clmMessageTitel
            // 
            this.clmMessageTitel.DisplayIndex = 1;
            this.clmMessageTitel.Text = "موضوع الرسالة";
            this.clmMessageTitel.Width = 240;
            // 
            // clmSentDate
            // 
            this.clmSentDate.DisplayIndex = 2;
            this.clmSentDate.Text = "تاريخ الإرسال";
            this.clmSentDate.Width = 165;
            // 
            // clmComesFrom
            // 
            this.clmComesFrom.DisplayIndex = 3;
            this.clmComesFrom.Text = "واردة من";
            this.clmComesFrom.Width = 225;
            // 
            // clmSentTo
            // 
            this.clmSentTo.DisplayIndex = 4;
            this.clmSentTo.Text = "موجها إلى";
            this.clmSentTo.Width = 230;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.btnCloseCopyList);
            this.groupBox1.Controls.Add(this.CopyList);
            this.groupBox1.Controls.Add(this.txtFindCopy);
            this.groupBox1.Controls.Add(this.btnCopyTo);
            this.groupBox1.Controls.Add(this.copyToList);
            this.groupBox1.Controls.Add(this.txtMessageId);
            this.groupBox1.Controls.Add(this.txtOrg);
            this.groupBox1.Controls.Add(this.MessageSubject);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.MessageSender);
            this.groupBox1.Controls.Add(this.SendDate);
            this.groupBox1.Controls.Add(this.MessageSerialNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labComeFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(953, 215);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(931, 242);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات الرسالة";
            // 
            // btnCloseCopyList
            // 
            this.btnCloseCopyList.BackColor = System.Drawing.Color.Red;
            this.btnCloseCopyList.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseCopyList.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseCopyList.Image")));
            this.btnCloseCopyList.Location = new System.Drawing.Point(508, 194);
            this.btnCloseCopyList.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseCopyList.Name = "btnCloseCopyList";
            this.btnCloseCopyList.Size = new System.Drawing.Size(34, 31);
            this.btnCloseCopyList.TabIndex = 56;
            this.btnCloseCopyList.UseVisualStyleBackColor = false;
            this.btnCloseCopyList.Click += new System.EventHandler(this.btnCloseCopyList_Click);
            // 
            // CopyList
            // 
            this.CopyList.BackColor = System.Drawing.Color.White;
            this.CopyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.columnHeader5,
            this.columnHeader6});
            this.CopyList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CopyList.FullRowSelect = true;
            this.CopyList.HideSelection = false;
            this.CopyList.Location = new System.Drawing.Point(508, 221);
            this.CopyList.Margin = new System.Windows.Forms.Padding(4);
            this.CopyList.MultiSelect = false;
            this.CopyList.Name = "CopyList";
            this.CopyList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CopyList.RightToLeftLayout = true;
            this.CopyList.Size = new System.Drawing.Size(368, 31);
            this.CopyList.TabIndex = 55;
            this.CopyList.UseCompatibleStateImageBehavior = false;
            // 
            // id
            // 
            this.id.DisplayIndex = 1;
            this.id.Width = 0;
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
            this.columnHeader6.Width = 200;
            // 
            // txtFindCopy
            // 
            this.txtFindCopy.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFindCopy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFindCopy.Location = new System.Drawing.Point(539, 194);
            this.txtFindCopy.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindCopy.Name = "txtFindCopy";
            this.txtFindCopy.PlaceholderText = "اكتب هنا للبحث عن مستخدم";
            this.txtFindCopy.Size = new System.Drawing.Size(337, 30);
            this.txtFindCopy.TabIndex = 54;
            this.txtFindCopy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFindCopy.TextChanged += new System.EventHandler(this.txtFindCopy_TextChanged);
            // 
            // btnCopyTo
            // 
            this.btnCopyTo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCopyTo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCopyTo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyTo.Image")));
            this.btnCopyTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopyTo.Location = new System.Drawing.Point(755, 125);
            this.btnCopyTo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyTo.Name = "btnCopyTo";
            this.btnCopyTo.Size = new System.Drawing.Size(100, 72);
            this.btnCopyTo.TabIndex = 53;
            this.btnCopyTo.Text = "صورة إلى";
            this.btnCopyTo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyTo.UseVisualStyleBackColor = false;
            this.btnCopyTo.Click += new System.EventHandler(this.btnCopyTo_Click);
            // 
            // copyToList
            // 
            this.copyToList.BackColor = System.Drawing.Color.White;
            this.copyToList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.copyToList.ContextMenuStrip = this.deleteCopyMenu;
            this.copyToList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copyToList.FullRowSelect = true;
            this.copyToList.HideSelection = false;
            this.copyToList.Location = new System.Drawing.Point(508, 147);
            this.copyToList.Margin = new System.Windows.Forms.Padding(4);
            this.copyToList.MultiSelect = false;
            this.copyToList.Name = "copyToList";
            this.copyToList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.copyToList.RightToLeftLayout = true;
            this.copyToList.Size = new System.Drawing.Size(248, 50);
            this.copyToList.TabIndex = 52;
            this.copyToList.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 0;
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 300;
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
            // txtMessageId
            // 
            this.txtMessageId.Location = new System.Drawing.Point(8, 8);
            this.txtMessageId.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageId.MaxLength = 50;
            this.txtMessageId.Name = "txtMessageId";
            this.txtMessageId.Size = new System.Drawing.Size(143, 31);
            this.txtMessageId.TabIndex = 12;
            this.txtMessageId.Visible = false;
            // 
            // txtOrg
            // 
            this.txtOrg.Location = new System.Drawing.Point(7, 92);
            this.txtOrg.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrg.Multiline = true;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(370, 47);
            this.txtOrg.TabIndex = 5;
            // 
            // MessageSubject
            // 
            this.MessageSubject.Location = new System.Drawing.Point(508, 95);
            this.MessageSubject.Margin = new System.Windows.Forms.Padding(4);
            this.MessageSubject.Multiline = true;
            this.MessageSubject.Name = "MessageSubject";
            this.MessageSubject.Size = new System.Drawing.Size(347, 44);
            this.MessageSubject.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "تاريخ الإحالة";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MessageSender
            // 
            this.MessageSender.FormattingEnabled = true;
            this.MessageSender.Location = new System.Drawing.Point(7, 44);
            this.MessageSender.Margin = new System.Windows.Forms.Padding(4);
            this.MessageSender.Name = "MessageSender";
            this.MessageSender.Size = new System.Drawing.Size(370, 33);
            this.MessageSender.TabIndex = 4;
            this.MessageSender.TextUpdate += new System.EventHandler(this.MessageSender_TextUpdate);
            // 
            // SendDate
            // 
            this.SendDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SendDate.Location = new System.Drawing.Point(7, 162);
            this.SendDate.Margin = new System.Windows.Forms.Padding(4);
            this.SendDate.Name = "SendDate";
            this.SendDate.Size = new System.Drawing.Size(370, 31);
            this.SendDate.TabIndex = 6;
            // 
            // MessageSerialNumber
            // 
            this.MessageSerialNumber.Location = new System.Drawing.Point(508, 47);
            this.MessageSerialNumber.Margin = new System.Windows.Forms.Padding(4);
            this.MessageSerialNumber.MaxLength = 50;
            this.MessageSerialNumber.Name = "MessageSerialNumber";
            this.MessageSerialNumber.Size = new System.Drawing.Size(347, 31);
            this.MessageSerialNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "جهة الرسالة";
            // 
            // labComeFrom
            // 
            this.labComeFrom.AutoSize = true;
            this.labComeFrom.Location = new System.Drawing.Point(398, 48);
            this.labComeFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labComeFrom.Name = "labComeFrom";
            this.labComeFrom.Size = new System.Drawing.Size(80, 25);
            this.labComeFrom.TabIndex = 2;
            this.labComeFrom.Text = "صادر من";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(857, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "موضوع الرسالة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(860, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم الرسالة";
            // 
            // clmId
            // 
            this.clmId.DisplayIndex = 4;
            this.clmId.Width = 0;
            // 
            // clmFileName
            // 
            this.clmFileName.DisplayIndex = 0;
            this.clmFileName.Text = "اسم الملف";
            this.clmFileName.Width = 250;
            // 
            // clmFileExtention
            // 
            this.clmFileExtention.DisplayIndex = 1;
            this.clmFileExtention.Text = "الامتداد";
            this.clmFileExtention.Width = 100;
            // 
            // clmFileSize
            // 
            this.clmFileSize.DisplayIndex = 2;
            this.clmFileSize.Text = "حجم الملف";
            this.clmFileSize.Width = 120;
            // 
            // clmFilePath
            // 
            this.clmFilePath.DisplayIndex = 3;
            this.clmFilePath.Width = 0;
            // 
            // DocList
            // 
            this.DocList.BackColor = System.Drawing.Color.White;
            this.DocList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmFileName,
            this.clmFileExtention,
            this.clmFileSize,
            this.clmFilePath});
            this.DocList.ContextMenuStrip = this.DeleteDocMenu;
            this.DocList.FullRowSelect = true;
            this.DocList.GridLines = true;
            this.DocList.HideSelection = false;
            this.DocList.Location = new System.Drawing.Point(66, 768);
            this.DocList.Margin = new System.Windows.Forms.Padding(4);
            this.DocList.Name = "DocList";
            this.DocList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DocList.RightToLeftLayout = true;
            this.DocList.Size = new System.Drawing.Size(848, 208);
            this.DocList.TabIndex = 7;
            this.DocList.UseCompatibleStateImageBehavior = false;
            // 
            // lbDevices
            // 
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.ItemHeight = 25;
            this.lbDevices.Location = new System.Drawing.Point(94, 140);
            this.lbDevices.Margin = new System.Windows.Forms.Padding(4);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(193, 4);
            this.lbDevices.TabIndex = 10;
            this.lbDevices.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.pdfViewerControl1);
            this.groupBox2.Controls.Add(this.picBox);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.btnScanFile);
            this.groupBox2.Controls.Add(this.btnSelectFile);
            this.groupBox2.Location = new System.Drawing.Point(62, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(870, 556);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "إضافة مرفقات";
            // 
            // pdfViewerControl1
            // 
            this.pdfViewerControl1.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool;
            this.pdfViewerControl1.EnableContextMenu = true;
            this.pdfViewerControl1.EnableNotificationBar = true;
            this.pdfViewerControl1.HorizontalScrollOffset = 0;
            this.pdfViewerControl1.IsBookmarkEnabled = true;
            this.pdfViewerControl1.IsTextSearchEnabled = true;
            this.pdfViewerControl1.IsTextSelectionEnabled = true;
            this.pdfViewerControl1.Location = new System.Drawing.Point(35, 92);
            messageBoxSettings1.EnableNotification = true;
            this.pdfViewerControl1.MessageBoxSettings = messageBoxSettings1;
            this.pdfViewerControl1.MinimumZoomPercentage = 50;
            this.pdfViewerControl1.Name = "pdfViewerControl1";
            this.pdfViewerControl1.PageBorderThickness = 1;
            pdfViewerPrinterSettings1.Copies = 1;
            pdfViewerPrinterSettings1.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.Auto;
            pdfViewerPrinterSettings1.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize;
            pdfViewerPrinterSettings1.PrintLocation = ((System.Drawing.PointF)(resources.GetObject("pdfViewerPrinterSettings1.PrintLocation")));
            pdfViewerPrinterSettings1.ShowPrintStatusDialog = true;
            this.pdfViewerControl1.PrinterSettings = pdfViewerPrinterSettings1;
            this.pdfViewerControl1.ReferencePath = null;
            this.pdfViewerControl1.ScrollDisplacementValue = 0;
            this.pdfViewerControl1.ShowHorizontalScrollBar = true;
            this.pdfViewerControl1.ShowToolBar = true;
            this.pdfViewerControl1.ShowVerticalScrollBar = true;
            this.pdfViewerControl1.Size = new System.Drawing.Size(802, 464);
            this.pdfViewerControl1.SpaceBetweenPages = 8;
            this.pdfViewerControl1.TabIndex = 16;
            this.pdfViewerControl1.Text = "pdfViewerControl1";
            textSearchSettings1.CurrentInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(64)))));
            textSearchSettings1.HighlightAllInstance = true;
            textSearchSettings1.OtherInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfViewerControl1.TextSearchSettings = textSearchSettings1;
            this.pdfViewerControl1.ThemeName = "Default";
            this.pdfViewerControl1.VerticalScrollOffset = 0;
            this.pdfViewerControl1.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.Default;
            this.pdfViewerControl1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.Default;
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(19, 77);
            this.picBox.Margin = new System.Windows.Forms.Padding(4);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(833, 479);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 12;
            this.picBox.TabStop = false;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(261, 28);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileName.MaxLength = 25;
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(146, 41);
            this.txtFileName.TabIndex = 18;
            this.txtFileName.Visible = false;
            // 
            // btnScanFile
            // 
            this.btnScanFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnScanFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScanFile.Image = ((System.Drawing.Image)(resources.GetObject("btnScanFile.Image")));
            this.btnScanFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScanFile.Location = new System.Drawing.Point(424, 28);
            this.btnScanFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnScanFile.Name = "btnScanFile";
            this.btnScanFile.Size = new System.Drawing.Size(201, 41);
            this.btnScanFile.TabIndex = 17;
            this.btnScanFile.Text = "استخدام الماسحة";
            this.btnScanFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanFile.UseVisualStyleBackColor = false;
            this.btnScanFile.Click += new System.EventHandler(this.btnScanFile_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.Image")));
            this.btnSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectFile.Location = new System.Drawing.Point(633, 28);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(214, 41);
            this.btnSelectFile.TabIndex = 16;
            this.btnSelectFile.Text = "استعراض الملفات";
            this.btnSelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // mainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 1014);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbDevices);
            this.Controls.Add(this.DocList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "mainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام المراسلات الخارجية";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mainScreen_Load);
            this.DeleteMessageMenu.ResumeLayout(false);
            this.DeleteDocMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.deleteCopyMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip DeleteMessageMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMessage;
        private System.Windows.Forms.ContextMenuStrip DeleteDocMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteDoc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton outbox;
        private System.Windows.Forms.RadioButton Inbox;
        private System.Windows.Forms.ListView MessageList;
        private System.Windows.Forms.ColumnHeader clmMessageId;
        private System.Windows.Forms.ColumnHeader clmMessageNumber;
        private System.Windows.Forms.ColumnHeader clmMessageTitel;
        private System.Windows.Forms.ColumnHeader clmSentDate;
        private System.Windows.Forms.ColumnHeader clmComesFrom;
        private System.Windows.Forms.ColumnHeader clmSentTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMessageId;
        private System.Windows.Forms.TextBox txtOrg;
        private System.Windows.Forms.TextBox MessageSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox MessageSender;
        private System.Windows.Forms.DateTimePicker SendDate;
        private System.Windows.Forms.TextBox MessageSerialNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labComeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.ColumnHeader clmFileExtention;
        private System.Windows.Forms.ColumnHeader clmFileSize;
        private System.Windows.Forms.ColumnHeader clmFilePath;
        private System.Windows.Forms.ListView DocList;
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.GroupBox groupBox2;
        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnScanFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnCard;
        private Syncfusion.Windows.Forms.Tools.ComboDropDown comboDropDown1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView CopyList;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtFindCopy;
        private System.Windows.Forms.Button btnCopyTo;
        private System.Windows.Forms.ListView copyToList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnCloseCopyList;
        private System.Windows.Forms.ContextMenuStrip deleteCopyMenu;
        private System.Windows.Forms.ToolStripMenuItem حدفToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
    }
}

