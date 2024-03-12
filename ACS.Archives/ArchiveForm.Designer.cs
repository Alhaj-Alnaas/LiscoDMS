
namespace ACS.Archives
{
    partial class ArchiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveForm));
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings1 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings1 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.clmMessageNumber = new System.Windows.Forms.ColumnHeader();
            this.clmSentdate = new System.Windows.Forms.ColumnHeader();
            this.ExportMessages = new System.Windows.Forms.CheckBox();
            this.ImportMessages = new System.Windows.Forms.CheckBox();
            this.rdNewSys = new System.Windows.Forms.RadioButton();
            this.rdOldSys = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.clmComesFrom = new System.Windows.Forms.ColumnHeader();
            this.txtMessageNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMessageSubject = new System.Windows.Forms.TextBox();
            this.clmMessageTitel = new System.Windows.Forms.ColumnHeader();
            this.clmMsgType = new System.Windows.Forms.ColumnHeader();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.clmMessageId = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MessageYear = new System.Windows.Forms.ColumnHeader();
            this.MessageList = new System.Windows.Forms.ListView();
            this.CancelArchivedMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.إلغاءالأرشفةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.CancelArchivedMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // clmMessageNumber
            // 
            this.clmMessageNumber.Text = "رقم الرسالة";
            this.clmMessageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmMessageNumber.Width = 150;
            // 
            // clmSentdate
            // 
            this.clmSentdate.Text = "تاريخ الإرسال";
            this.clmSentdate.Width = 100;
            // 
            // ExportMessages
            // 
            this.ExportMessages.AutoSize = true;
            this.ExportMessages.Checked = true;
            this.ExportMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExportMessages.Location = new System.Drawing.Point(819, 84);
            this.ExportMessages.Name = "ExportMessages";
            this.ExportMessages.Size = new System.Drawing.Size(85, 29);
            this.ExportMessages.TabIndex = 16;
            this.ExportMessages.Text = "الصادر";
            this.ExportMessages.UseVisualStyleBackColor = true;
            this.ExportMessages.CheckedChanged += new System.EventHandler(this.ExportMessages_CheckedChanged);
            // 
            // ImportMessages
            // 
            this.ImportMessages.AutoSize = true;
            this.ImportMessages.Checked = true;
            this.ImportMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ImportMessages.Location = new System.Drawing.Point(1033, 84);
            this.ImportMessages.Name = "ImportMessages";
            this.ImportMessages.Size = new System.Drawing.Size(74, 29);
            this.ImportMessages.TabIndex = 15;
            this.ImportMessages.Text = "الوارد";
            this.ImportMessages.UseVisualStyleBackColor = true;
            this.ImportMessages.CheckedChanged += new System.EventHandler(this.ImportMessages_CheckedChanged);
            // 
            // rdNewSys
            // 
            this.rdNewSys.AutoSize = true;
            this.rdNewSys.Checked = true;
            this.rdNewSys.Location = new System.Drawing.Point(1220, 33);
            this.rdNewSys.Margin = new System.Windows.Forms.Padding(4);
            this.rdNewSys.Name = "rdNewSys";
            this.rdNewSys.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdNewSys.Size = new System.Drawing.Size(202, 29);
            this.rdNewSys.TabIndex = 13;
            this.rdNewSys.TabStop = true;
            this.rdNewSys.Text = "بحث في النظام الحالي";
            this.rdNewSys.UseVisualStyleBackColor = true;
            this.rdNewSys.CheckedChanged += new System.EventHandler(this.rdNewSys_CheckedChanged);
            // 
            // rdOldSys
            // 
            this.rdOldSys.AutoSize = true;
            this.rdOldSys.Location = new System.Drawing.Point(1222, 70);
            this.rdOldSys.Margin = new System.Windows.Forms.Padding(4);
            this.rdOldSys.Name = "rdOldSys";
            this.rdOldSys.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdOldSys.Size = new System.Drawing.Size(200, 29);
            this.rdOldSys.TabIndex = 14;
            this.rdOldSys.Text = "بحث في النظام القديم";
            this.rdOldSys.UseVisualStyleBackColor = true;
            this.rdOldSys.CheckedChanged += new System.EventHandler(this.rdOldSys_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(8, 85);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 43);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "بحث";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // clmComesFrom
            // 
            this.clmComesFrom.Text = "جهة الرسالة";
            this.clmComesFrom.Width = 230;
            // 
            // txtMessageNo
            // 
            this.txtMessageNo.Location = new System.Drawing.Point(752, 29);
            this.txtMessageNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageNo.MaxLength = 50;
            this.txtMessageNo.Name = "txtMessageNo";
            this.txtMessageNo.Size = new System.Drawing.Size(164, 31);
            this.txtMessageNo.TabIndex = 1;
            this.txtMessageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(913, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "رقم الرسالة";
            // 
            // txtMessageSubject
            // 
            this.txtMessageSubject.Location = new System.Drawing.Point(384, 29);
            this.txtMessageSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageSubject.Name = "txtMessageSubject";
            this.txtMessageSubject.Size = new System.Drawing.Size(233, 31);
            this.txtMessageSubject.TabIndex = 2;
            // 
            // clmMessageTitel
            // 
            this.clmMessageTitel.Text = "موضوع الرسالة";
            this.clmMessageTitel.Width = 200;
            // 
            // clmMsgType
            // 
            this.clmMsgType.Text = "نوع الرسالة";
            this.clmMsgType.Width = 100;
            // 
            // txtOrg
            // 
            this.txtOrg.Location = new System.Drawing.Point(7, 29);
            this.txtOrg.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(249, 31);
            this.txtOrg.TabIndex = 3;
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
            this.pdfViewerControl1.Location = new System.Drawing.Point(-77, 140);
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
            this.pdfViewerControl1.Size = new System.Drawing.Size(557, 568);
            this.pdfViewerControl1.SpaceBetweenPages = 8;
            this.pdfViewerControl1.TabIndex = 13;
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
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(1028, 29);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtYear.MaxLength = 50;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(79, 31);
            this.txtYear.TabIndex = 0;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clmMessageId
            // 
            this.clmMessageId.Text = "message id";
            this.clmMessageId.Width = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "جهة الرسالة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(619, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "موضوع الرسالة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1116, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "السنة";
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(-77, 141);
            this.picBox.Margin = new System.Windows.Forms.Padding(4);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(557, 583);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 12;
            this.picBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.ExportMessages);
            this.groupBox1.Controls.Add(this.ImportMessages);
            this.groupBox1.Controls.Add(this.rdNewSys);
            this.groupBox1.Controls.Add(this.rdOldSys);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtMessageNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOrg);
            this.groupBox1.Controls.Add(this.txtMessageSubject);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(-77, -3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1479, 136);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "عناصر البحث";
            // 
            // MessageYear
            // 
            this.MessageYear.Text = "السنة";
            this.MessageYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageList
            // 
            this.MessageList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.MessageList.AllowColumnReorder = true;
            this.MessageList.BackColor = System.Drawing.Color.White;
            this.MessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMessageId,
            this.MessageYear,
            this.clmMessageNumber,
            this.clmMessageTitel,
            this.clmSentdate,
            this.clmComesFrom,
            this.clmMsgType});
            this.MessageList.ContextMenuStrip = this.CancelArchivedMenu;
            this.MessageList.FullRowSelect = true;
            this.MessageList.GridLines = true;
            this.MessageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MessageList.HideSelection = false;
            this.MessageList.HoverSelection = true;
            this.MessageList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.MessageList.Location = new System.Drawing.Point(486, 140);
            this.MessageList.Margin = new System.Windows.Forms.Padding(4);
            this.MessageList.MultiSelect = false;
            this.MessageList.Name = "MessageList";
            this.MessageList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MessageList.RightToLeftLayout = true;
            this.MessageList.ShowItemToolTips = true;
            this.MessageList.Size = new System.Drawing.Size(915, 583);
            this.MessageList.TabIndex = 11;
            this.MessageList.UseCompatibleStateImageBehavior = false;
            this.MessageList.View = System.Windows.Forms.View.Details;
            // 
            // CancelArchivedMenu
            // 
            this.CancelArchivedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CancelArchivedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إلغاءالأرشفةToolStripMenuItem});
            this.CancelArchivedMenu.Name = "MultiCommentMenu";
            this.CancelArchivedMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CancelArchivedMenu.Size = new System.Drawing.Size(158, 28);
            this.CancelArchivedMenu.Click += new System.EventHandler(this.CancelArchivedMenu_Click);
            // 
            // إلغاءالأرشفةToolStripMenuItem
            // 
            this.إلغاءالأرشفةToolStripMenuItem.Name = "إلغاءالأرشفةToolStripMenuItem";
            this.إلغاءالأرشفةToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.إلغاءالأرشفةToolStripMenuItem.Text = "إلغاء الأرشفة";
            this.إلغاءالأرشفةToolStripMenuItem.Click += new System.EventHandler(this.إلغاءالأرشفةToolStripMenuItem_Click);
            // 
            // ArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1334, 720);
            this.Controls.Add(this.pdfViewerControl1);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MessageList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArchiveForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "شاشة الأرشيف";
            this.Load += new System.EventHandler(this.ArchiveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CancelArchivedMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmMessageNumber;
        private System.Windows.Forms.ColumnHeader clmSentdate;
        private System.Windows.Forms.CheckBox ExportMessages;
        private System.Windows.Forms.CheckBox ImportMessages;
        private System.Windows.Forms.RadioButton rdNewSys;
        private System.Windows.Forms.RadioButton rdOldSys;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColumnHeader clmComesFrom;
        private System.Windows.Forms.TextBox txtMessageNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMessageSubject;
        private System.Windows.Forms.ColumnHeader clmMessageTitel;
        private System.Windows.Forms.ColumnHeader clmMsgType;
        private System.Windows.Forms.TextBox txtOrg;
        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ColumnHeader clmMessageId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader MessageYear;
        private System.Windows.Forms.ListView MessageList;
        private System.Windows.Forms.ContextMenuStrip CancelArchivedMenu;
        private System.Windows.Forms.ToolStripMenuItem إلغاءالأرشفةToolStripMenuItem;
    }
}