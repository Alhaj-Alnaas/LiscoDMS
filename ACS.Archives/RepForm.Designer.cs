
namespace ACS.Archives
{
    partial class RepForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepForm));
            this.sendTo = new System.Windows.Forms.ComboBox();
            this.labComeFrom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Fromdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.btnShowRep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendTo
            // 
            this.sendTo.FormattingEnabled = true;
            this.sendTo.Location = new System.Drawing.Point(51, 46);
            this.sendTo.Margin = new System.Windows.Forms.Padding(6);
            this.sendTo.Name = "sendTo";
            this.sendTo.Size = new System.Drawing.Size(619, 36);
            this.sendTo.TabIndex = 6;
            // 
            // labComeFrom
            // 
            this.labComeFrom.AutoSize = true;
            this.labComeFrom.Location = new System.Drawing.Point(722, 54);
            this.labComeFrom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labComeFrom.Name = "labComeFrom";
            this.labComeFrom.Size = new System.Drawing.Size(101, 28);
            this.labComeFrom.TabIndex = 5;
            this.labComeFrom.Text = "جهة الإحالة";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(698, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 28);
            this.label5.TabIndex = 13;
            this.label5.Text = "من تاريخ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Fromdate
            // 
            this.Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fromdate.Location = new System.Drawing.Point(472, 130);
            this.Fromdate.Margin = new System.Windows.Forms.Padding(6);
            this.Fromdate.Name = "Fromdate";
            this.Fromdate.Size = new System.Drawing.Size(198, 34);
            this.Fromdate.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "إلى تاريخ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ToDate
            // 
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDate.Location = new System.Drawing.Point(51, 130);
            this.ToDate.Margin = new System.Windows.Forms.Padding(6);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(214, 34);
            this.ToDate.TabIndex = 14;
            // 
            // btnShowRep
            // 
            this.btnShowRep.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowRep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowRep.Image = ((System.Drawing.Image)(resources.GetObject("btnShowRep.Image")));
            this.btnShowRep.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowRep.Location = new System.Drawing.Point(250, 224);
            this.btnShowRep.Margin = new System.Windows.Forms.Padding(6);
            this.btnShowRep.Name = "btnShowRep";
            this.btnShowRep.Size = new System.Drawing.Size(276, 57);
            this.btnShowRep.TabIndex = 18;
            this.btnShowRep.Text = "عــــرض النمودج";
            this.btnShowRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowRep.UseVisualStyleBackColor = false;
            this.btnShowRep.Click += new System.EventHandler(this.btnShowRep_Click);
            // 
            // RepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(823, 300);
            this.Controls.Add(this.btnShowRep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Fromdate);
            this.Controls.Add(this.sendTo);
            this.Controls.Add(this.labComeFrom);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمودج إحــالة";
            this.Load += new System.EventHandler(this.RepForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sendTo;
        private System.Windows.Forms.Label labComeFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker Fromdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.Button btnShowRep;
    }
}