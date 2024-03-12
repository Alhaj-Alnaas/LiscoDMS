
namespace ACS.Archives
{
    partial class NewMessageForm
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
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMessageForm));
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings1 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings1 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labDateAg = new System.Windows.Forms.Label();
            this.txtReplyDays = new System.Windows.Forms.NumericUpDown();
            this.labReplyDays = new System.Windows.Forms.Label();
            this.labDateHij = new System.Windows.Forms.Label();
            this.txtDateHij = new System.Windows.Forms.TextBox();
            this.txtDateAgr = new System.Windows.Forms.TextBox();
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
            this.labSender = new System.Windows.Forms.Label();
            this.MessageSender = new System.Windows.Forms.ComboBox();
            this.labMesNo = new System.Windows.Forms.Label();
            this.txtMessageSubject = new System.Windows.Forms.TextBox();
            this.txtMessageNo = new System.Windows.Forms.TextBox();
            this.labMesgSub = new System.Windows.Forms.Label();
            this.txtMessageId = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addAttchFile = new System.Windows.Forms.LinkLabel();
            this.btnScanFile = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.DocList = new System.Windows.Forms.ListView();
            this.clmId = new System.Windows.Forms.ColumnHeader();
            this.clmFileName = new System.Windows.Forms.ColumnHeader();
            this.clmFileExtention = new System.Windows.Forms.ColumnHeader();
            this.clmFileSize = new System.Windows.Forms.ColumnHeader();
            this.clmFilePath = new System.Windows.Forms.ColumnHeader();
            this.isTemp = new System.Windows.Forms.ColumnHeader();
            this.DeleteDocMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendType = new System.Windows.Forms.GroupBox();
            this.rdForAll = new System.Windows.Forms.RadioButton();
            this.rdLowLevel = new System.Windows.Forms.RadioButton();
            this.rdSpecific = new System.Windows.Forms.RadioButton();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplyDays)).BeginInit();
            this.deleteCopyMenu.SuspendLayout();
            this.DeleteReciptMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.DeleteDocMenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.sendType.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "pdf";
            openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.ReadOnlyChecked = true;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.lbDevices);
            this.panel3.Name = "panel3";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbDevices
            // 
            resources.ApplyResources(this.lbDevices, "lbDevices");
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Name = "lbDevices";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.labDateAg);
            this.groupBox1.Controls.Add(this.txtReplyDays);
            this.groupBox1.Controls.Add(this.labReplyDays);
            this.groupBox1.Controls.Add(this.labDateHij);
            this.groupBox1.Controls.Add(this.txtDateHij);
            this.groupBox1.Controls.Add(this.txtDateAgr);
            this.groupBox1.Controls.Add(this.btnCloseCopyList);
            this.groupBox1.Controls.Add(this.CopyList);
            this.groupBox1.Controls.Add(this.txtFindCopy);
            this.groupBox1.Controls.Add(this.btnCopyTo);
            this.groupBox1.Controls.Add(this.copyToList);
            this.groupBox1.Controls.Add(this.btnAddUsers);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.UsersList);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.Reciptes);
            this.groupBox1.Controls.Add(this.labSender);
            this.groupBox1.Controls.Add(this.MessageSender);
            this.groupBox1.Controls.Add(this.labMesNo);
            this.groupBox1.Controls.Add(this.txtMessageSubject);
            this.groupBox1.Controls.Add(this.txtMessageNo);
            this.groupBox1.Controls.Add(this.labMesgSub);
            this.groupBox1.Controls.Add(this.txtMessageId);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // labDateAg
            // 
            resources.ApplyResources(this.labDateAg, "labDateAg");
            this.labDateAg.BackColor = System.Drawing.Color.AntiqueWhite;
            this.labDateAg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labDateAg.Name = "labDateAg";
            // 
            // txtReplyDays
            // 
            resources.ApplyResources(this.txtReplyDays, "txtReplyDays");
            this.txtReplyDays.Name = "txtReplyDays";
            // 
            // labReplyDays
            // 
            resources.ApplyResources(this.labReplyDays, "labReplyDays");
            this.labReplyDays.BackColor = System.Drawing.Color.Gold;
            this.labReplyDays.Name = "labReplyDays";
            // 
            // labDateHij
            // 
            resources.ApplyResources(this.labDateHij, "labDateHij");
            this.labDateHij.Name = "labDateHij";
            // 
            // txtDateHij
            // 
            resources.ApplyResources(this.txtDateHij, "txtDateHij");
            this.txtDateHij.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtDateHij.Name = "txtDateHij";
            this.txtDateHij.ReadOnly = true;
            // 
            // txtDateAgr
            // 
            resources.ApplyResources(this.txtDateAgr, "txtDateAgr");
            this.txtDateAgr.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtDateAgr.Name = "txtDateAgr";
            this.txtDateAgr.ReadOnly = true;
            // 
            // btnCloseCopyList
            // 
            resources.ApplyResources(this.btnCloseCopyList, "btnCloseCopyList");
            this.btnCloseCopyList.BackColor = System.Drawing.Color.Red;
            this.btnCloseCopyList.Name = "btnCloseCopyList";
            this.btnCloseCopyList.UseVisualStyleBackColor = false;
            this.btnCloseCopyList.Click += new System.EventHandler(this.btnCloseCopyList_Click);
            // 
            // CopyList
            // 
            resources.ApplyResources(this.CopyList, "CopyList");
            this.CopyList.BackColor = System.Drawing.Color.White;
            this.CopyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.columnHeader5,
            this.columnHeader6});
            this.CopyList.FullRowSelect = true;
            this.CopyList.HideSelection = false;
            this.CopyList.MultiSelect = false;
            this.CopyList.Name = "CopyList";
            this.CopyList.UseCompatibleStateImageBehavior = false;
            // 
            // id
            // 
            resources.ApplyResources(this.id, "id");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // txtFindCopy
            // 
            resources.ApplyResources(this.txtFindCopy, "txtFindCopy");
            this.txtFindCopy.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtFindCopy.Name = "txtFindCopy";
            this.txtFindCopy.TextChanged += new System.EventHandler(this.txtFindCopy_TextChanged);
            // 
            // btnCopyTo
            // 
            resources.ApplyResources(this.btnCopyTo, "btnCopyTo");
            this.btnCopyTo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCopyTo.Name = "btnCopyTo";
            this.btnCopyTo.UseVisualStyleBackColor = false;
            this.btnCopyTo.Click += new System.EventHandler(this.btnCopyTo_Click);
            // 
            // copyToList
            // 
            resources.ApplyResources(this.copyToList, "copyToList");
            this.copyToList.BackColor = System.Drawing.Color.White;
            this.copyToList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.copyToList.ContextMenuStrip = this.deleteCopyMenu;
            this.copyToList.FullRowSelect = true;
            this.copyToList.HideSelection = false;
            this.copyToList.MultiSelect = false;
            this.copyToList.Name = "copyToList";
            this.copyToList.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // deleteCopyMenu
            // 
            resources.ApplyResources(this.deleteCopyMenu, "deleteCopyMenu");
            this.deleteCopyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.deleteCopyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حدفToolStripMenuItem});
            this.deleteCopyMenu.Name = "deleteCopyMenu";
            this.deleteCopyMenu.Click += new System.EventHandler(this.deleteCopyMenu_Click);
            // 
            // حدفToolStripMenuItem
            // 
            resources.ApplyResources(this.حدفToolStripMenuItem, "حدفToolStripMenuItem");
            this.حدفToolStripMenuItem.Name = "حدفToolStripMenuItem";
            // 
            // btnAddUsers
            // 
            resources.ApplyResources(this.btnAddUsers, "btnAddUsers");
            this.btnAddUsers.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddUsers.Name = "btnAddUsers";
            this.btnAddUsers.UseVisualStyleBackColor = false;
            this.btnAddUsers.Click += new System.EventHandler(this.btnAddUsers_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UsersList
            // 
            resources.ApplyResources(this.UsersList, "UsersList");
            this.UsersList.BackColor = System.Drawing.Color.White;
            this.UsersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colUserName,
            this.colUserJob});
            this.UsersList.FullRowSelect = true;
            this.UsersList.HideSelection = false;
            this.UsersList.MultiSelect = false;
            this.UsersList.Name = "UsersList";
            this.UsersList.UseCompatibleStateImageBehavior = false;
            this.UsersList.SelectedIndexChanged += new System.EventHandler(this.UsersList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // colUserName
            // 
            resources.ApplyResources(this.colUserName, "colUserName");
            // 
            // colUserJob
            // 
            resources.ApplyResources(this.colUserJob, "colUserJob");
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Reciptes
            // 
            resources.ApplyResources(this.Reciptes, "Reciptes");
            this.Reciptes.BackColor = System.Drawing.Color.White;
            this.Reciptes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columId,
            this.columDesc});
            this.Reciptes.ContextMenuStrip = this.DeleteReciptMenu;
            this.Reciptes.FullRowSelect = true;
            this.Reciptes.HideSelection = false;
            this.Reciptes.MultiSelect = false;
            this.Reciptes.Name = "Reciptes";
            this.Reciptes.UseCompatibleStateImageBehavior = false;
            // 
            // columId
            // 
            resources.ApplyResources(this.columId, "columId");
            // 
            // columDesc
            // 
            resources.ApplyResources(this.columDesc, "columDesc");
            // 
            // DeleteReciptMenu
            // 
            resources.ApplyResources(this.DeleteReciptMenu, "DeleteReciptMenu");
            this.DeleteReciptMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteReciptMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حــدفToolStripMenuItem});
            this.DeleteReciptMenu.Name = "DeleteReciptMenu";
            this.DeleteReciptMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteReciptMenu_MouseClick_1);
            // 
            // حــدفToolStripMenuItem
            // 
            resources.ApplyResources(this.حــدفToolStripMenuItem, "حــدفToolStripMenuItem");
            this.حــدفToolStripMenuItem.Name = "حــدفToolStripMenuItem";
            // 
            // labSender
            // 
            resources.ApplyResources(this.labSender, "labSender");
            this.labSender.Name = "labSender";
            // 
            // MessageSender
            // 
            resources.ApplyResources(this.MessageSender, "MessageSender");
            this.MessageSender.FormattingEnabled = true;
            this.MessageSender.Name = "MessageSender";
            this.MessageSender.SelectedIndexChanged += new System.EventHandler(this.MessageSender_SelectedIndexChanged);
            this.MessageSender.SelectionChangeCommitted += new System.EventHandler(this.MessageSender_SelectionChangeCommitted);
            // 
            // labMesNo
            // 
            resources.ApplyResources(this.labMesNo, "labMesNo");
            this.labMesNo.Name = "labMesNo";
            // 
            // txtMessageSubject
            // 
            resources.ApplyResources(this.txtMessageSubject, "txtMessageSubject");
            this.txtMessageSubject.Name = "txtMessageSubject";
            // 
            // txtMessageNo
            // 
            resources.ApplyResources(this.txtMessageNo, "txtMessageNo");
            this.txtMessageNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtMessageNo.Name = "txtMessageNo";
            this.txtMessageNo.ReadOnly = true;
            // 
            // labMesgSub
            // 
            resources.ApplyResources(this.labMesgSub, "labMesgSub");
            this.labMesgSub.Name = "labMesgSub";
            // 
            // txtMessageId
            // 
            resources.ApplyResources(this.txtMessageId, "txtMessageId");
            this.txtMessageId.Name = "txtMessageId";
            // 
            // txtFileName
            // 
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.Name = "txtFileName";
            // 
            // picBox
            // 
            resources.ApplyResources(this.picBox, "picBox");
            this.picBox.BackColor = System.Drawing.Color.Silver;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Name = "picBox";
            this.picBox.TabStop = false;
            // 
            // pdfViewerControl1
            // 
            resources.ApplyResources(this.pdfViewerControl1, "pdfViewerControl1");
            this.pdfViewerControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.pdfViewerControl1.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool;
            this.pdfViewerControl1.EnableContextMenu = true;
            this.pdfViewerControl1.EnableNotificationBar = true;
            this.pdfViewerControl1.HorizontalScrollOffset = 0;
            this.pdfViewerControl1.IsBookmarkEnabled = true;
            this.pdfViewerControl1.IsTextSearchEnabled = true;
            this.pdfViewerControl1.IsTextSelectionEnabled = true;
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
            this.pdfViewerControl1.SpaceBetweenPages = 8;
            textSearchSettings1.CurrentInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(64)))));
            textSearchSettings1.HighlightAllInstance = true;
            textSearchSettings1.OtherInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfViewerControl1.TextSearchSettings = textSearchSettings1;
            this.pdfViewerControl1.ThemeName = "Default";
            this.pdfViewerControl1.VerticalScrollOffset = 0;
            this.pdfViewerControl1.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.Default;
            this.pdfViewerControl1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.Default;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox3.Controls.Add(this.addAttchFile);
            this.groupBox3.Controls.Add(this.btnScanFile);
            this.groupBox3.Controls.Add(this.btnSelectFile);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // addAttchFile
            // 
            resources.ApplyResources(this.addAttchFile, "addAttchFile");
            this.addAttchFile.Name = "addAttchFile";
            this.addAttchFile.TabStop = true;
            this.addAttchFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addAttchFile_LinkClicked);
            // 
            // btnScanFile
            // 
            resources.ApplyResources(this.btnScanFile, "btnScanFile");
            this.btnScanFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnScanFile.Name = "btnScanFile";
            this.btnScanFile.UseVisualStyleBackColor = false;
            this.btnScanFile.Click += new System.EventHandler(this.btnScanFile_Click);
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // DocList
            // 
            resources.ApplyResources(this.DocList, "DocList");
            this.DocList.BackColor = System.Drawing.Color.White;
            this.DocList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmFileName,
            this.clmFileExtention,
            this.clmFileSize,
            this.clmFilePath,
            this.isTemp});
            this.DocList.ContextMenuStrip = this.DeleteDocMenu;
            this.DocList.FullRowSelect = true;
            this.DocList.GridLines = true;
            this.DocList.HideSelection = false;
            this.DocList.MultiSelect = false;
            this.DocList.Name = "DocList";
            this.DocList.UseCompatibleStateImageBehavior = false;
            // 
            // clmId
            // 
            resources.ApplyResources(this.clmId, "clmId");
            // 
            // clmFileName
            // 
            resources.ApplyResources(this.clmFileName, "clmFileName");
            // 
            // clmFileExtention
            // 
            resources.ApplyResources(this.clmFileExtention, "clmFileExtention");
            // 
            // clmFileSize
            // 
            resources.ApplyResources(this.clmFileSize, "clmFileSize");
            // 
            // clmFilePath
            // 
            resources.ApplyResources(this.clmFilePath, "clmFilePath");
            // 
            // isTemp
            // 
            resources.ApplyResources(this.isTemp, "isTemp");
            // 
            // DeleteDocMenu
            // 
            resources.ApplyResources(this.DeleteDocMenu, "DeleteDocMenu");
            this.DeleteDocMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteDocMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteDoc});
            this.DeleteDocMenu.Name = "DeleteDocMenu";
            this.DeleteDocMenu.Click += new System.EventHandler(this.DeleteDocMenu_Click);
            // 
            // DeleteDoc
            // 
            resources.ApplyResources(this.DeleteDoc, "DeleteDoc");
            this.DeleteDoc.Name = "DeleteDoc";
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "DeleteReciptMenu";
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // sendType
            // 
            resources.ApplyResources(this.sendType, "sendType");
            this.sendType.BackColor = System.Drawing.Color.AntiqueWhite;
            this.sendType.Controls.Add(this.rdForAll);
            this.sendType.Controls.Add(this.rdLowLevel);
            this.sendType.Controls.Add(this.rdSpecific);
            this.sendType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendType.ForeColor = System.Drawing.Color.Black;
            this.sendType.Name = "sendType";
            this.sendType.TabStop = false;
            // 
            // rdForAll
            // 
            resources.ApplyResources(this.rdForAll, "rdForAll");
            this.rdForAll.BackColor = System.Drawing.Color.DarkOrange;
            this.rdForAll.Name = "rdForAll";
            this.rdForAll.UseVisualStyleBackColor = false;
            this.rdForAll.CheckedChanged += new System.EventHandler(this.rdForAll_CheckedChanged);
            // 
            // rdLowLevel
            // 
            resources.ApplyResources(this.rdLowLevel, "rdLowLevel");
            this.rdLowLevel.BackColor = System.Drawing.Color.DarkOrange;
            this.rdLowLevel.Name = "rdLowLevel";
            this.rdLowLevel.UseVisualStyleBackColor = false;
            this.rdLowLevel.CheckedChanged += new System.EventHandler(this.rdLowLevel_CheckedChanged);
            // 
            // rdSpecific
            // 
            resources.ApplyResources(this.rdSpecific, "rdSpecific");
            this.rdSpecific.BackColor = System.Drawing.Color.DarkOrange;
            this.rdSpecific.Checked = true;
            this.rdSpecific.Name = "rdSpecific";
            this.rdSpecific.TabStop = true;
            this.rdSpecific.UseVisualStyleBackColor = false;
            this.rdSpecific.CheckedChanged += new System.EventHandler(this.rdSpecific_CheckedChanged);
            // 
            // NewMessageForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.sendType);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.pdfViewerControl1);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.DocList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMessageForm";
            this.Load += new System.EventHandler(this.NewMessageForm_Load);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplyDays)).EndInit();
            this.deleteCopyMenu.ResumeLayout(false);
            this.DeleteReciptMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.DeleteDocMenu.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.sendType.ResumeLayout(false);
            this.sendType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labSender;
        private System.Windows.Forms.ComboBox MessageSender;
        private System.Windows.Forms.Label labMesNo;
        private System.Windows.Forms.TextBox txtMessageSubject;
        private System.Windows.Forms.TextBox txtMessageNo;
        private System.Windows.Forms.Label labMesgSub;
        private System.Windows.Forms.TextBox txtMessageId;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.PictureBox picBox;
        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnScanFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.ListView DocList;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.ColumnHeader clmFileExtention;
        private System.Windows.Forms.ColumnHeader clmFileSize;
        private System.Windows.Forms.ColumnHeader clmFilePath;
        private System.Windows.Forms.ContextMenuStrip DeleteDocMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteDoc;
        private System.Windows.Forms.ContextMenuStrip DeleteReciptMenu;
        private System.Windows.Forms.ToolStripMenuItem حــدفToolStripMenuItem;
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
        private System.Windows.Forms.Button btnCopyTo;
        private System.Windows.Forms.ListView copyToList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnCloseCopyList;
        private System.Windows.Forms.ListView CopyList;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtFindCopy;
        private System.Windows.Forms.ContextMenuStrip deleteCopyMenu;
        private System.Windows.Forms.ToolStripMenuItem حدفToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ColumnHeader isTemp;
        private System.Windows.Forms.LinkLabel addAttchFile;
        private System.Windows.Forms.GroupBox sendType;
        private System.Windows.Forms.RadioButton rdForAll;
        private System.Windows.Forms.RadioButton rdLowLevel;
        private System.Windows.Forms.RadioButton rdSpecific;
        private System.Windows.Forms.Label labDateHij;
        private System.Windows.Forms.TextBox txtDateHij;
        private System.Windows.Forms.TextBox txtDateAgr;
        private System.Windows.Forms.NumericUpDown txtReplyDays;
        private System.Windows.Forms.Label labReplyDays;
        private System.Windows.Forms.Label labDateAg;
    }
}