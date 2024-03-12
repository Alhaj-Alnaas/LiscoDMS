
namespace ACS.Archives
{
    partial class SearchInOldSystem
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
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings1 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchInOldSystem));
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings1 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.MessageList = new System.Windows.Forms.ListView();
            this.clmMessageId = new System.Windows.Forms.ColumnHeader();
            this.MessageYear = new System.Windows.Forms.ColumnHeader();
            this.clmMessageNumber = new System.Windows.Forms.ColumnHeader();
            this.clmMessageTitel = new System.Windows.Forms.ColumnHeader();
            this.clmSentdate = new System.Windows.Forms.ColumnHeader();
            this.clmComesFrom = new System.Windows.Forms.ColumnHeader();
            this.clmSentTo = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.messagCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ExportMessages = new System.Windows.Forms.CheckBox();
            this.ImportMessages = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.Button();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.pdfViewerControl1.Location = new System.Drawing.Point(12, 264);
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
            this.pdfViewerControl1.Size = new System.Drawing.Size(557, 416);
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
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(13, 157);
            this.picBox.Margin = new System.Windows.Forms.Padding(4);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(557, 583);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 12;
            this.picBox.TabStop = false;
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
            this.clmSentTo});
            this.MessageList.FullRowSelect = true;
            this.MessageList.GridLines = true;
            this.MessageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MessageList.HideSelection = false;
            this.MessageList.HoverSelection = true;
            this.MessageList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.MessageList.Location = new System.Drawing.Point(577, 156);
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
            // clmMessageId
            // 
            this.clmMessageId.Text = "message id";
            this.clmMessageId.Width = 0;
            // 
            // MessageYear
            // 
            this.MessageYear.Text = "السنة";
            this.MessageYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clmMessageNumber
            // 
            this.clmMessageNumber.Text = "رقم الرسالة";
            this.clmMessageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmMessageNumber.Width = 100;
            // 
            // clmMessageTitel
            // 
            this.clmMessageTitel.Text = "موضوع الرسالة";
            this.clmMessageTitel.Width = 200;
            // 
            // clmSentdate
            // 
            this.clmSentdate.Text = "تاريخ الإرسال";
            this.clmSentdate.Width = 100;
            // 
            // clmComesFrom
            // 
            this.clmComesFrom.Text = "واردة من";
            this.clmComesFrom.Width = 200;
            // 
            // clmSentTo
            // 
            this.clmSentTo.Text = "موجها إلى";
            this.clmSentTo.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.messagCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ExportMessages);
            this.groupBox1.Controls.Add(this.ImportMessages);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.txtSearchText);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1479, 136);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "عناصر البحث";
            // 
            // messagCount
            // 
            this.messagCount.AutoSize = true;
            this.messagCount.BackColor = System.Drawing.Color.DarkOrange;
            this.messagCount.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.messagCount.Location = new System.Drawing.Point(1328, 73);
            this.messagCount.Name = "messagCount";
            this.messagCount.Size = new System.Drawing.Size(22, 25);
            this.messagCount.TabIndex = 18;
            this.messagCount.Text = "0";
            this.messagCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(1362, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "عدد المراسلات";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // ExportMessages
            // 
            this.ExportMessages.AutoSize = true;
            this.ExportMessages.Checked = true;
            this.ExportMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExportMessages.Location = new System.Drawing.Point(1273, 32);
            this.ExportMessages.Name = "ExportMessages";
            this.ExportMessages.Size = new System.Drawing.Size(85, 29);
            this.ExportMessages.TabIndex = 16;
            this.ExportMessages.Text = "الصادر";
            this.ExportMessages.UseVisualStyleBackColor = true;
            // 
            // ImportMessages
            // 
            this.ImportMessages.AutoSize = true;
            this.ImportMessages.Checked = true;
            this.ImportMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ImportMessages.Location = new System.Drawing.Point(1177, 32);
            this.ImportMessages.Name = "ImportMessages";
            this.ImportMessages.Size = new System.Drawing.Size(74, 29);
            this.ImportMessages.TabIndex = 15;
            this.ImportMessages.Text = "الوارد";
            this.ImportMessages.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.txtSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Image = ((System.Drawing.Image)(resources.GetObject("txtSearch.Image")));
            this.txtSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSearch.Location = new System.Drawing.Point(44, 30);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(131, 31);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Text = "بحث";
            this.txtSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSearch.UseVisualStyleBackColor = false;
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(170, 30);
            this.txtSearchText.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.PlaceholderText = "البحث برقم الرسالة / الموضوع / الجهة";
            this.txtSearchText.Size = new System.Drawing.Size(325, 31);
            this.txtSearchText.TabIndex = 3;
            this.txtSearchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchText.TextChanged += new System.EventHandler(this.txtSearchText_TextChanged);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(912, 30);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtYear.MaxLength = 50;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(128, 31);
            this.txtYear.TabIndex = 0;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1049, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "السنة";
            // 
            // SearchInOldSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1508, 751);
            this.Controls.Add(this.pdfViewerControl1);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.MessageList);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchInOldSystem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نظام إدارة المراسلات ... شاشة البحث في الأرشيف";
            this.Load += new System.EventHandler(this.SearchInOldSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ListView MessageList;
        private System.Windows.Forms.ColumnHeader clmMessageId;
        private System.Windows.Forms.ColumnHeader MessageYear;
        private System.Windows.Forms.ColumnHeader clmMessageNumber;
        private System.Windows.Forms.ColumnHeader clmMessageTitel;
        private System.Windows.Forms.ColumnHeader clmSentdate;
        private System.Windows.Forms.ColumnHeader clmComesFrom;
        private System.Windows.Forms.ColumnHeader clmSentTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ExportMessages;
        private System.Windows.Forms.CheckBox ImportMessages;
        private System.Windows.Forms.Button txtSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label messagCount;
        private System.Windows.Forms.Label label5;
    }
}