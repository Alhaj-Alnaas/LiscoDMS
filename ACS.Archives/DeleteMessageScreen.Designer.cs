
namespace ACS.Archives
{
    partial class DeleteMessageScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteMessageScreen));
            this.DeleteMessage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMessageId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSendingDate = new System.Windows.Forms.TextBox();
            this.labSendingDate = new System.Windows.Forms.Label();
            this.MessageSender = new System.Windows.Forms.TextBox();
            this.labSender = new System.Windows.Forms.Label();
            this.labMesNo = new System.Windows.Forms.Label();
            this.txtMessageSubject = new System.Windows.Forms.TextBox();
            this.txtMessageNo = new System.Windows.Forms.TextBox();
            this.labMesgSub = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeleteMessage
            // 
            this.DeleteMessage.BackColor = System.Drawing.Color.OrangeRed;
            this.DeleteMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteMessage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeleteMessage.Image = ((System.Drawing.Image)(resources.GetObject("DeleteMessage.Image")));
            this.DeleteMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteMessage.Location = new System.Drawing.Point(200, 259);
            this.DeleteMessage.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteMessage.Name = "DeleteMessage";
            this.DeleteMessage.Size = new System.Drawing.Size(214, 41);
            this.DeleteMessage.TabIndex = 26;
            this.DeleteMessage.Text = "حـــدف مراسلة";
            this.DeleteMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteMessage.UseVisualStyleBackColor = false;
            this.DeleteMessage.Click += new System.EventHandler(this.DeleteMessage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.txtMessageId);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.DeleteMessage);
            this.groupBox1.Controls.Add(this.txtSendingDate);
            this.groupBox1.Controls.Add(this.labSendingDate);
            this.groupBox1.Controls.Add(this.MessageSender);
            this.groupBox1.Controls.Add(this.labSender);
            this.groupBox1.Controls.Add(this.labMesNo);
            this.groupBox1.Controls.Add(this.txtMessageSubject);
            this.groupBox1.Controls.Add(this.txtMessageNo);
            this.groupBox1.Controls.Add(this.labMesgSub);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(667, 316);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات المراسلة";
            // 
            // txtMessageId
            // 
            this.txtMessageId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMessageId.Location = new System.Drawing.Point(8, 236);
            this.txtMessageId.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageId.MaxLength = 50;
            this.txtMessageId.Name = "txtMessageId";
            this.txtMessageId.Size = new System.Drawing.Size(169, 34);
            this.txtMessageId.TabIndex = 56;
            this.txtMessageId.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(34, 41);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 39);
            this.btnSearch.TabIndex = 55;
            this.btnSearch.Text = "بحث";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSendingDate
            // 
            this.txtSendingDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSendingDate.Location = new System.Drawing.Point(135, 198);
            this.txtSendingDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendingDate.Name = "txtSendingDate";
            this.txtSendingDate.ReadOnly = true;
            this.txtSendingDate.Size = new System.Drawing.Size(360, 30);
            this.txtSendingDate.TabIndex = 54;
            this.txtSendingDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labSendingDate
            // 
            this.labSendingDate.AutoSize = true;
            this.labSendingDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labSendingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labSendingDate.Location = new System.Drawing.Point(511, 205);
            this.labSendingDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSendingDate.Name = "labSendingDate";
            this.labSendingDate.Size = new System.Drawing.Size(98, 23);
            this.labSendingDate.TabIndex = 53;
            this.labSendingDate.Text = "تاريخ الإرسال";
            // 
            // MessageSender
            // 
            this.MessageSender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MessageSender.Location = new System.Drawing.Point(135, 160);
            this.MessageSender.Margin = new System.Windows.Forms.Padding(4);
            this.MessageSender.Name = "MessageSender";
            this.MessageSender.ReadOnly = true;
            this.MessageSender.Size = new System.Drawing.Size(360, 30);
            this.MessageSender.TabIndex = 49;
            // 
            // labSender
            // 
            this.labSender.AutoSize = true;
            this.labSender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labSender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labSender.Location = new System.Drawing.Point(517, 167);
            this.labSender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSender.Name = "labSender";
            this.labSender.Size = new System.Drawing.Size(61, 23);
            this.labSender.TabIndex = 27;
            this.labSender.Text = "المرسل";
            // 
            // labMesNo
            // 
            this.labMesNo.AutoSize = true;
            this.labMesNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labMesNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labMesNo.Location = new System.Drawing.Point(517, 51);
            this.labMesNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMesNo.Name = "labMesNo";
            this.labMesNo.Size = new System.Drawing.Size(101, 23);
            this.labMesNo.TabIndex = 25;
            this.labMesNo.Text = "الرقم الإشاري";
            // 
            // txtMessageSubject
            // 
            this.txtMessageSubject.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMessageSubject.Location = new System.Drawing.Point(135, 93);
            this.txtMessageSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageSubject.Multiline = true;
            this.txtMessageSubject.Name = "txtMessageSubject";
            this.txtMessageSubject.ReadOnly = true;
            this.txtMessageSubject.Size = new System.Drawing.Size(360, 55);
            this.txtMessageSubject.TabIndex = 21;
            // 
            // txtMessageNo
            // 
            this.txtMessageNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMessageNo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMessageNo.Location = new System.Drawing.Point(135, 41);
            this.txtMessageNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageNo.MaxLength = 50;
            this.txtMessageNo.Name = "txtMessageNo";
            this.txtMessageNo.Size = new System.Drawing.Size(360, 39);
            this.txtMessageNo.TabIndex = 17;
            this.txtMessageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMessageNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessageNo_KeyPress);
            // 
            // labMesgSub
            // 
            this.labMesgSub.AutoSize = true;
            this.labMesgSub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labMesgSub.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labMesgSub.Location = new System.Drawing.Point(503, 93);
            this.labMesgSub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMesgSub.Name = "labMesgSub";
            this.labMesgSub.Size = new System.Drawing.Size(87, 23);
            this.labMesgSub.TabIndex = 20;
            this.labMesgSub.Text = "المـوضـــوع";
            // 
            // DeleteMessageScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 341);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteMessageScreen";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "شاشة حدف مراسلة";
           
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DeleteMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSendingDate;
        private System.Windows.Forms.Label labSendingDate;
        private System.Windows.Forms.TextBox MessageSender;
        private System.Windows.Forms.Label labSender;
        private System.Windows.Forms.Label labMesNo;
        private System.Windows.Forms.TextBox txtMessageSubject;
        private System.Windows.Forms.TextBox txtMessageNo;
        private System.Windows.Forms.Label labMesgSub;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMessageId;
    }
}