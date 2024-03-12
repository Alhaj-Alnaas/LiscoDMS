
namespace ACS.Archives
{
    partial class AddComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddComments));
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings1 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings1 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.DocList = new System.Windows.Forms.ListView();
            this.clmId = new System.Windows.Forms.ColumnHeader();
            this.clmFileName = new System.Windows.Forms.ColumnHeader();
            this.clmFileExtention = new System.Windows.Forms.ColumnHeader();
            this.clmFileSize = new System.Windows.Forms.ColumnHeader();
            this.clmFilePath = new System.Windows.Forms.ColumnHeader();
            this.isTemp = new System.Windows.Forms.ColumnHeader();
            this.DeleteDocMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addAttchFile = new System.Windows.Forms.LinkLabel();
            this.rdDocComment = new System.Windows.Forms.RadioButton();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.rdTextComment = new System.Windows.Forms.RadioButton();
            this.btnScanFile = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtMessageId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMessageSubject = new System.Windows.Forms.TextBox();
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
            this.labMesNo = new System.Windows.Forms.Label();
            this.txtMessageNo = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.DeleteDocMenu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.deleteCopyMenu.SuspendLayout();
            this.DeleteReciptMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDevices
            // 
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.ItemHeight = 20;
            this.lbDevices.Location = new System.Drawing.Point(9, 25);
            this.lbDevices.Margin = new System.Windows.Forms.Padding(4);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(96, 44);
            this.lbDevices.TabIndex = 44;
            this.lbDevices.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox4.Controls.Add(this.sendMessage);
            this.groupBox4.Location = new System.Drawing.Point(29, 560);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(469, 103);
            this.groupBox4.TabIndex = 43;
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
            this.sendMessage.Size = new System.Drawing.Size(231, 41);
            this.sendMessage.TabIndex = 27;
            this.sendMessage.Text = "إرســـال";
            this.sendMessage.UseVisualStyleBackColor = false;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.AliceBlue;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(37, 15);
            this.picBox.Margin = new System.Windows.Forms.Padding(4);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(452, 262);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 38;
            this.picBox.TabStop = false;
            // 
            // pdfViewerControl1
            // 
            this.pdfViewerControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.pdfViewerControl1.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool;
            this.pdfViewerControl1.EnableContextMenu = true;
            this.pdfViewerControl1.EnableNotificationBar = true;
            this.pdfViewerControl1.HorizontalScrollOffset = 0;
            this.pdfViewerControl1.IsBookmarkEnabled = true;
            this.pdfViewerControl1.IsTextSearchEnabled = true;
            this.pdfViewerControl1.IsTextSelectionEnabled = true;
            this.pdfViewerControl1.Location = new System.Drawing.Point(37, 295);
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
            this.pdfViewerControl1.Size = new System.Drawing.Size(452, 242);
            this.pdfViewerControl1.SpaceBetweenPages = 8;
            this.pdfViewerControl1.TabIndex = 39;
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
            // DocList
            // 
            this.DocList.BackColor = System.Drawing.Color.White;
            this.DocList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmFileName,
            this.clmFileExtention,
            this.clmFileSize,
            this.clmFilePath,
            this.isTemp});
            this.DocList.ContextMenuStrip = this.DeleteDocMenu;
            this.DocList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DocList.FullRowSelect = true;
            this.DocList.GridLines = true;
            this.DocList.HideSelection = false;
            this.DocList.Location = new System.Drawing.Point(518, 533);
            this.DocList.Margin = new System.Windows.Forms.Padding(4);
            this.DocList.MultiSelect = false;
            this.DocList.Name = "DocList";
            this.DocList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DocList.RightToLeftLayout = true;
            this.DocList.Size = new System.Drawing.Size(770, 174);
            this.DocList.TabIndex = 42;
            this.DocList.UseCompatibleStateImageBehavior = false;
            this.DocList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DocList_MouseClick);
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
            // isTemp
            // 
            this.isTemp.Width = 0;
            // 
            // DeleteDocMenu
            // 
            this.DeleteDocMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteDocMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteDoc});
            this.DeleteDocMenu.Name = "DeleteDocMenu";
            this.DeleteDocMenu.Size = new System.Drawing.Size(117, 28);
            this.DeleteDocMenu.Text = "حذف";
            this.DeleteDocMenu.Click += new System.EventHandler(this.DeleteDocMenu_Click);
            // 
            // DeleteDoc
            // 
            this.DeleteDoc.Name = "DeleteDoc";
            this.DeleteDoc.Size = new System.Drawing.Size(116, 24);
            this.DeleteDoc.Text = "حــذف";
            this.DeleteDoc.ToolTipText = "حـــذف";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox3.Controls.Add(this.addAttchFile);
            this.groupBox3.Controls.Add(this.rdDocComment);
            this.groupBox3.Controls.Add(this.txtComment);
            this.groupBox3.Controls.Add(this.rdTextComment);
            this.groupBox3.Controls.Add(this.btnScanFile);
            this.groupBox3.Controls.Add(this.btnSelectFile);
            this.groupBox3.Controls.Add(this.lbDevices);
            this.groupBox3.Controls.Add(this.txtMessageId);
            this.groupBox3.Location = new System.Drawing.Point(518, 310);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(769, 215);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "إضافة تأشيرة";
            // 
            // addAttchFile
            // 
            this.addAttchFile.AutoSize = true;
            this.addAttchFile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addAttchFile.Location = new System.Drawing.Point(613, 179);
            this.addAttchFile.Name = "addAttchFile";
            this.addAttchFile.Size = new System.Drawing.Size(96, 23);
            this.addAttchFile.TabIndex = 47;
            this.addAttchFile.TabStop = true;
            this.addAttchFile.Text = "إضافة مرفق";
            this.addAttchFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addAttchFile_LinkClicked);
            // 
            // rdDocComment
            // 
            this.rdDocComment.AutoSize = true;
            this.rdDocComment.BackColor = System.Drawing.Color.AntiqueWhite;
            this.rdDocComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdDocComment.ForeColor = System.Drawing.Color.Black;
            this.rdDocComment.Location = new System.Drawing.Point(337, 27);
            this.rdDocComment.Name = "rdDocComment";
            this.rdDocComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdDocComment.Size = new System.Drawing.Size(133, 32);
            this.rdDocComment.TabIndex = 3;
            this.rdDocComment.Text = "تأشيرة ورقية";
            this.rdDocComment.UseVisualStyleBackColor = false;
            this.rdDocComment.CheckedChanged += new System.EventHandler(this.rdDocComment_CheckedChanged);
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtComment.Location = new System.Drawing.Point(177, 77);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.PlaceholderText = "نص التأشيرة";
            this.txtComment.Size = new System.Drawing.Size(481, 29);
            this.txtComment.TabIndex = 46;
            this.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdTextComment
            // 
            this.rdTextComment.AutoSize = true;
            this.rdTextComment.BackColor = System.Drawing.Color.AntiqueWhite;
            this.rdTextComment.Checked = true;
            this.rdTextComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdTextComment.ForeColor = System.Drawing.Color.Black;
            this.rdTextComment.Location = new System.Drawing.Point(524, 27);
            this.rdTextComment.Name = "rdTextComment";
            this.rdTextComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdTextComment.Size = new System.Drawing.Size(134, 32);
            this.rdTextComment.TabIndex = 0;
            this.rdTextComment.TabStop = true;
            this.rdTextComment.Text = "تأشيرة نصية";
            this.rdTextComment.UseVisualStyleBackColor = false;
            this.rdTextComment.CheckedChanged += new System.EventHandler(this.rdTextComment_CheckedChanged);
            // 
            // btnScanFile
            // 
            this.btnScanFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnScanFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScanFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnScanFile.Image = ((System.Drawing.Image)(resources.GetObject("btnScanFile.Image")));
            this.btnScanFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScanFile.Location = new System.Drawing.Point(177, 114);
            this.btnScanFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnScanFile.Name = "btnScanFile";
            this.btnScanFile.Size = new System.Drawing.Size(201, 41);
            this.btnScanFile.TabIndex = 27;
            this.btnScanFile.Text = "استخدام الماسحة";
            this.btnScanFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanFile.UseVisualStyleBackColor = false;
            this.btnScanFile.Visible = false;
            this.btnScanFile.Click += new System.EventHandler(this.btnScanFile_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.Image")));
            this.btnSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectFile.Location = new System.Drawing.Point(433, 114);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(214, 41);
            this.btnSelectFile.TabIndex = 26;
            this.btnSelectFile.Text = "استعراض الملفات";
            this.btnSelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Visible = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtMessageId
            // 
            this.txtMessageId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMessageId.Location = new System.Drawing.Point(8, 77);
            this.txtMessageId.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageId.MaxLength = 50;
            this.txtMessageId.Name = "txtMessageId";
            this.txtMessageId.Size = new System.Drawing.Size(116, 34);
            this.txtMessageId.TabIndex = 12;
            this.txtMessageId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.txtMessageSubject);
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
            this.groupBox1.Controls.Add(this.labMesNo);
            this.groupBox1.Controls.Add(this.txtMessageNo);
            this.groupBox1.Location = new System.Drawing.Point(522, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(769, 293);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات المراسلة";
            // 
            // txtMessageSubject
            // 
            this.txtMessageSubject.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMessageSubject.Location = new System.Drawing.Point(6, 238);
            this.txtMessageSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageSubject.Name = "txtMessageSubject";
            this.txtMessageSubject.ReadOnly = true;
            this.txtMessageSubject.Size = new System.Drawing.Size(346, 30);
            this.txtMessageSubject.TabIndex = 58;
            this.txtMessageSubject.Visible = false;
            // 
            // btnCloseCopyList
            // 
            this.btnCloseCopyList.BackColor = System.Drawing.Color.Red;
            this.btnCloseCopyList.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCloseCopyList.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseCopyList.Image")));
            this.btnCloseCopyList.Location = new System.Drawing.Point(5, 155);
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
            this.CopyList.Location = new System.Drawing.Point(6, 182);
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
            this.txtFindCopy.Location = new System.Drawing.Point(37, 155);
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
            this.btnCopyTo.Location = new System.Drawing.Point(262, 94);
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
            this.copyToList.Location = new System.Drawing.Point(6, 108);
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
            this.columnHeader8.Width = 300;
            // 
            // deleteCopyMenu
            // 
            this.deleteCopyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.deleteCopyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حدفToolStripMenuItem});
            this.deleteCopyMenu.Name = "deleteCopyMenu";
            this.deleteCopyMenu.Size = new System.Drawing.Size(111, 28);
            this.deleteCopyMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteCopyMenu_MouseClick);
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
            this.labSendAs.Location = new System.Drawing.Point(273, 44);
            this.labSendAs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSendAs.Name = "labSendAs";
            this.labSendAs.Size = new System.Drawing.Size(101, 23);
            this.labSendAs.TabIndex = 51;
            this.labSendAs.Text = "صفة المرسل";
            // 
            // SendAs
            // 
            this.SendAs.FormattingEnabled = true;
            this.SendAs.Location = new System.Drawing.Point(6, 44);
            this.SendAs.Margin = new System.Windows.Forms.Padding(4);
            this.SendAs.Name = "SendAs";
            this.SendAs.Size = new System.Drawing.Size(259, 28);
            this.SendAs.TabIndex = 50;
            this.SendAs.SelectionChangeCommitted += new System.EventHandler(this.SendAs_SelectionChangeCommitted);
            // 
            // btnAddUsers
            // 
            this.btnAddUsers.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddUsers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUsers.Image")));
            this.btnAddUsers.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddUsers.Location = new System.Drawing.Point(615, 94);
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
            this.btnClose.Location = new System.Drawing.Point(368, 178);
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
            this.UsersList.Location = new System.Drawing.Point(368, 217);
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
            this.txtSearch.Location = new System.Drawing.Point(396, 178);
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
            this.Reciptes.Location = new System.Drawing.Point(368, 108);
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
            this.columDesc.Width = 300;
            // 
            // DeleteReciptMenu
            // 
            this.DeleteReciptMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteReciptMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حــدفToolStripMenuItem});
            this.DeleteReciptMenu.Name = "DeleteReciptMenu";
            this.DeleteReciptMenu.Size = new System.Drawing.Size(117, 28);
            this.DeleteReciptMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteReciptMenu_MouseClick);
            // 
            // حــدفToolStripMenuItem
            // 
            this.حــدفToolStripMenuItem.Name = "حــدفToolStripMenuItem";
            this.حــدفToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.حــدفToolStripMenuItem.Text = "حــدف";
            // 
            // labMesNo
            // 
            this.labMesNo.AutoSize = true;
            this.labMesNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labMesNo.Location = new System.Drawing.Point(666, 55);
            this.labMesNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMesNo.Name = "labMesNo";
            this.labMesNo.Size = new System.Drawing.Size(101, 23);
            this.labMesNo.TabIndex = 25;
            this.labMesNo.Text = "الرقم الإشاري";
            // 
            // txtMessageNo
            // 
            this.txtMessageNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMessageNo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMessageNo.Location = new System.Drawing.Point(425, 44);
            this.txtMessageNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageNo.MaxLength = 50;
            this.txtMessageNo.Name = "txtMessageNo";
            this.txtMessageNo.ReadOnly = true;
            this.txtMessageNo.Size = new System.Drawing.Size(218, 39);
            this.txtMessageNo.TabIndex = 17;
            this.txtMessageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1301, 711);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.pdfViewerControl1);
            this.Controls.Add(this.DocList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddComments";
            this.Text = "إضافة تأشيرة";
            this.Load += new System.EventHandler(this.AddComments_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.DeleteDocMenu.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.deleteCopyMenu.ResumeLayout(false);
            this.DeleteReciptMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.PictureBox picBox;
        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.ListView DocList;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.ColumnHeader clmFileExtention;
        private System.Windows.Forms.ColumnHeader clmFileSize;
        private System.Windows.Forms.ColumnHeader clmFilePath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnScanFile;
        private System.Windows.Forms.Button btnSelectFile;
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
        private System.Windows.Forms.Label labMesNo;
        private System.Windows.Forms.TextBox txtMessageNo;
        private System.Windows.Forms.TextBox txtMessageId;
        private System.Windows.Forms.ContextMenuStrip DeleteReciptMenu;
        private System.Windows.Forms.ToolStripMenuItem حــدفToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip deleteCopyMenu;
        private System.Windows.Forms.ToolStripMenuItem حدفToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdDocComment;
        private System.Windows.Forms.RadioButton rdTextComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.LinkLabel addAttchFile;
        private System.Windows.Forms.ColumnHeader isTemp;
        private System.Windows.Forms.ContextMenuStrip DeleteDocMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteDoc;
        private System.Windows.Forms.TextBox txtMessageSubject;
    }
}