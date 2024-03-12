
namespace ACS.Archives
{
    partial class MessageDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageDetailsForm));
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings2 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings2 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings2 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSendingDate = new System.Windows.Forms.TextBox();
            this.labSendingDate = new System.Windows.Forms.Label();
            this.CCList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.MessageSender = new System.Windows.Forms.TextBox();
            this.ReciptesList = new System.Windows.Forms.ListView();
            this.Id = new System.Windows.Forms.ColumnHeader();
            this.RecipName = new System.Windows.Forms.ColumnHeader();
            this.labSender = new System.Windows.Forms.Label();
            this.labMesNo = new System.Windows.Forms.Label();
            this.txtMessageSubject = new System.Windows.Forms.TextBox();
            this.txtMessageNo = new System.Windows.Forms.TextBox();
            this.labMesgSub = new System.Windows.Forms.Label();
            this.txtMessageId = new System.Windows.Forms.TextBox();
            this.DeleteReciptMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.حــدفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.DeleteMessage = new System.Windows.Forms.Button();
            this.clmId = new System.Windows.Forms.ColumnHeader();
            this.clmFileName = new System.Windows.Forms.ColumnHeader();
            this.clmFileExtention = new System.Windows.Forms.ColumnHeader();
            this.clmFileSize = new System.Windows.Forms.ColumnHeader();
            this.DocList = new System.Windows.Forms.ListView();
            this.downloadFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.تنزيلمرفقToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حدفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCopyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.DeleteReciptMenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.downloadFileMenu.SuspendLayout();
            this.deleteCopyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.Silver;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.picBox, "picBox");
            this.picBox.Name = "picBox";
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
            resources.ApplyResources(this.pdfViewerControl1, "pdfViewerControl1");
            messageBoxSettings2.EnableNotification = true;
            this.pdfViewerControl1.MessageBoxSettings = messageBoxSettings2;
            this.pdfViewerControl1.MinimumZoomPercentage = 50;
            this.pdfViewerControl1.Name = "pdfViewerControl1";
            this.pdfViewerControl1.PageBorderThickness = 1;
            pdfViewerPrinterSettings2.Copies = 1;
            pdfViewerPrinterSettings2.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.Auto;
            pdfViewerPrinterSettings2.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize;
            pdfViewerPrinterSettings2.PrintLocation = ((System.Drawing.PointF)(resources.GetObject("pdfViewerPrinterSettings2.PrintLocation")));
            pdfViewerPrinterSettings2.ShowPrintStatusDialog = true;
            this.pdfViewerControl1.PrinterSettings = pdfViewerPrinterSettings2;
            this.pdfViewerControl1.ReferencePath = null;
            this.pdfViewerControl1.ScrollDisplacementValue = 0;
            this.pdfViewerControl1.ShowHorizontalScrollBar = true;
            this.pdfViewerControl1.ShowToolBar = true;
            this.pdfViewerControl1.ShowVerticalScrollBar = true;
            this.pdfViewerControl1.SpaceBetweenPages = 8;
            textSearchSettings2.CurrentInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(64)))));
            textSearchSettings2.HighlightAllInstance = true;
            textSearchSettings2.OtherInstanceColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfViewerControl1.TextSearchSettings = textSearchSettings2;
            this.pdfViewerControl1.ThemeName = "Default";
            this.pdfViewerControl1.VerticalScrollOffset = 0;
            this.pdfViewerControl1.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.Default;
            this.pdfViewerControl1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.Default;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.txtSendingDate);
            this.groupBox1.Controls.Add(this.labSendingDate);
            this.groupBox1.Controls.Add(this.CCList);
            this.groupBox1.Controls.Add(this.MessageSender);
            this.groupBox1.Controls.Add(this.ReciptesList);
            this.groupBox1.Controls.Add(this.labSender);
            this.groupBox1.Controls.Add(this.labMesNo);
            this.groupBox1.Controls.Add(this.txtMessageSubject);
            this.groupBox1.Controls.Add(this.txtMessageNo);
            this.groupBox1.Controls.Add(this.labMesgSub);
            this.groupBox1.Controls.Add(this.txtMessageId);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtSendingDate
            // 
            resources.ApplyResources(this.txtSendingDate, "txtSendingDate");
            this.txtSendingDate.Name = "txtSendingDate";
            this.txtSendingDate.ReadOnly = true;
            // 
            // labSendingDate
            // 
            resources.ApplyResources(this.labSendingDate, "labSendingDate");
            this.labSendingDate.Name = "labSendingDate";
            // 
            // CCList
            // 
            this.CCList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CCList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            resources.ApplyResources(this.CCList, "CCList");
            this.CCList.FullRowSelect = true;
            this.CCList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CCList.HideSelection = false;
            this.CCList.MultiSelect = false;
            this.CCList.Name = "CCList";
            this.CCList.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // MessageSender
            // 
            resources.ApplyResources(this.MessageSender, "MessageSender");
            this.MessageSender.Name = "MessageSender";
            this.MessageSender.ReadOnly = true;
            // 
            // ReciptesList
            // 
            this.ReciptesList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReciptesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.RecipName});
            resources.ApplyResources(this.ReciptesList, "ReciptesList");
            this.ReciptesList.FullRowSelect = true;
            this.ReciptesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ReciptesList.HideSelection = false;
            this.ReciptesList.MultiSelect = false;
            this.ReciptesList.Name = "ReciptesList";
            this.ReciptesList.UseCompatibleStateImageBehavior = false;
            // 
            // Id
            // 
            resources.ApplyResources(this.Id, "Id");
            // 
            // RecipName
            // 
            resources.ApplyResources(this.RecipName, "RecipName");
            // 
            // labSender
            // 
            resources.ApplyResources(this.labSender, "labSender");
            this.labSender.Name = "labSender";
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
            this.txtMessageSubject.ReadOnly = true;
            // 
            // txtMessageNo
            // 
            this.txtMessageNo.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.txtMessageNo, "txtMessageNo");
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
            // DeleteReciptMenu
            // 
            this.DeleteReciptMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeleteReciptMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حــدفToolStripMenuItem});
            this.DeleteReciptMenu.Name = "DeleteReciptMenu";
            resources.ApplyResources(this.DeleteReciptMenu, "DeleteReciptMenu");
            // 
            // حــدفToolStripMenuItem
            // 
            this.حــدفToolStripMenuItem.Name = "حــدفToolStripMenuItem";
            resources.ApplyResources(this.حــدفToolStripMenuItem, "حــدفToolStripMenuItem");
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox4.Controls.Add(this.sendMessage);
            this.groupBox4.Controls.Add(this.DeleteMessage);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // sendMessage
            // 
            this.sendMessage.BackColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this.sendMessage, "sendMessage");
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.UseVisualStyleBackColor = false;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // DeleteMessage
            // 
            this.DeleteMessage.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.DeleteMessage, "DeleteMessage");
            this.DeleteMessage.Name = "DeleteMessage";
            this.DeleteMessage.UseVisualStyleBackColor = false;
            this.DeleteMessage.Click += new System.EventHandler(this.DeleteMessage_Click);
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
            // DocList
            // 
            this.DocList.BackColor = System.Drawing.Color.White;
            this.DocList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmFileName,
            this.clmFileExtention,
            this.clmFileSize});
            this.DocList.ContextMenuStrip = this.downloadFileMenu;
            resources.ApplyResources(this.DocList, "DocList");
            this.DocList.FullRowSelect = true;
            this.DocList.GridLines = true;
            this.DocList.HideSelection = false;
            this.DocList.MultiSelect = false;
            this.DocList.Name = "DocList";
            this.DocList.UseCompatibleStateImageBehavior = false;
            // 
            // downloadFileMenu
            // 
            this.downloadFileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.downloadFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تنزيلمرفقToolStripMenuItem});
            this.downloadFileMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.downloadFileMenu, "downloadFileMenu");
            this.downloadFileMenu.Click += new System.EventHandler(this.downloadFileMenu_Click);
            // 
            // تنزيلمرفقToolStripMenuItem
            // 
            this.تنزيلمرفقToolStripMenuItem.Name = "تنزيلمرفقToolStripMenuItem";
            resources.ApplyResources(this.تنزيلمرفقToolStripMenuItem, "تنزيلمرفقToolStripMenuItem");
            // 
            // حدفToolStripMenuItem
            // 
            this.حدفToolStripMenuItem.Name = "حدفToolStripMenuItem";
            resources.ApplyResources(this.حدفToolStripMenuItem, "حدفToolStripMenuItem");
            // 
            // deleteCopyMenu
            // 
            this.deleteCopyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.deleteCopyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حدفToolStripMenuItem});
            this.deleteCopyMenu.Name = "deleteCopyMenu";
            resources.ApplyResources(this.deleteCopyMenu, "deleteCopyMenu");
            // 
            // MessageDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.DocList);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.pdfViewerControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageDetailsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.MessageDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DeleteReciptMenu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.downloadFileMenu.ResumeLayout(false);
            this.deleteCopyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBox;
        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labSender;
        private System.Windows.Forms.Label labMesNo;
        private System.Windows.Forms.TextBox txtMessageSubject;
        private System.Windows.Forms.TextBox txtMessageNo;
        private System.Windows.Forms.Label labMesgSub;
        private System.Windows.Forms.TextBox txtMessageId;
        private System.Windows.Forms.ListView ReciptesList;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader RecipName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.Button DeleteMessage;
        private System.Windows.Forms.TextBox MessageSender;
        private System.Windows.Forms.ContextMenuStrip DeleteReciptMenu;
        private System.Windows.Forms.ToolStripMenuItem حــدفToolStripMenuItem;
        private System.Windows.Forms.ListView CCList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmFileName;
        private System.Windows.Forms.ColumnHeader clmFileExtention;
        private System.Windows.Forms.ColumnHeader clmFileSize;
        private System.Windows.Forms.ListView DocList;
        private System.Windows.Forms.ToolStripMenuItem حدفToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip deleteCopyMenu;
        private System.Windows.Forms.ContextMenuStrip downloadFileMenu;
        private System.Windows.Forms.ToolStripMenuItem تنزيلمرفقToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSendingDate;
        private System.Windows.Forms.Label labSendingDate;
    }
}