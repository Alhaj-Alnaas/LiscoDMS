using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.DataAccess;
using Microsoft.EntityFrameworkCore;
using SearchInOldSystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;

namespace ACS.Archives
{
    public partial class RepForm : Form
    {
        protected readonly DataContext _dataContext;
        protected readonly OldSysDBContext _OldDataContext;
        private readonly string _messageId;
        private readonly string _messageType;
        public string networkPath = @"\\10.10.102.16\AttachDoc";
        NetworkCredential credentials = new NetworkCredential(@"DMSUser", "Lisco@2022");

        public BaseUser MainUser;
        public BaseUser Sender;

        //public List<SystemUser> SystemUsersList;
       // public List<SystemUser> ReciptesUsers;
        public List<BaseUser> users;
        public List<Core.Entities.Message> messages;

        public string myNetworkPath = string.Empty;
    
        public RepForm(
            DataContext dataContext
            )
        {
            _dataContext = dataContext;
            InitializeComponent();
        }

        public string ExportPDF()
        {
          

        // creating data table and adding dummy data  
        DataTable dt = new DataTable();
            dt.Columns.Add("ر.ت");
            dt.Columns.Add("رقم المراسلة");
            dt.Columns.Add("الموضوع");
            dt.Columns.Add("جهة الإصدار");
            dt.Columns.Add("اسم المستلم والتوقيع");

            
            
            //---------------------بريد المحفوظات---------------------
            if (StaticParametrs.CurrentUser.IsArchiveUser == true)
            {
                 messages = _dataContext.Messages.Where(m => m.Sent == true && m.IsForeign==true && m.Packages.Any(p => p.ResponsibilityCode == sendTo.SelectedValue.ToString()) &&  m.CreatedOn.Date >= Fromdate.Value.Date && m.CreatedOn.Date <= ToDate.Value.Date).Include("Packages").Include("Sender").OrderBy(o => o.CreatedOn).ToList();
            }
            //---------------------بريد القطاع---------------------
            else if (StaticParametrs.CurrentUser.IsArchiveUser == false && sendTo.SelectedValue.ToString().Substring(2, 3)=="000")
            {
                messages = _dataContext.Messages.Where(m => m.Sent == true && m.Packages.Any(p => p.ResponsibilityCode.Substring(0, 2) == sendTo.SelectedValue.ToString().Substring(0, 2)) && m.ResponsibilityCode == MainUser.ResponsibilityCode && m.CreatedOn.Date >= Fromdate.Value.Date && m.CreatedOn.Date <= ToDate.Value.Date).Include("Packages").Include("Sender").OrderBy(o => o.CreatedOn).ToList();
            }
            //---------------------بريد الإدارة العامة ---------------------
            else if (StaticParametrs.CurrentUser.IsArchiveUser == false && sendTo.SelectedValue.ToString().Substring(2, 1) != "0" && sendTo.SelectedValue.ToString().Substring(3, 2) == "00")
            {
                messages = _dataContext.Messages.Where(m => m.Sent == true && m.Packages.Any(p => p.ResponsibilityCode.Substring(0, 3) == sendTo.SelectedValue.ToString().Substring(0, 3)) && m.ResponsibilityCode == MainUser.ResponsibilityCode && m.CreatedOn.Date >= Fromdate.Value.Date && m.CreatedOn.Date <= ToDate.Value.Date).Include("Packages").Include("Sender").OrderBy(o => o.CreatedOn).ToList();
            }
            //---------------------بريد الإدارة  ---------------------
            else if (StaticParametrs.CurrentUser.IsArchiveUser == false && sendTo.SelectedValue.ToString().Substring(2, 1) != "0" &&
                sendTo.SelectedValue.ToString().Substring(3, 1) != "0" && sendTo.SelectedValue.ToString().Substring(4, 1) == "0")
            {
                messages = _dataContext.Messages.Where(m => m.Sent == true && m.Packages.Any(p => p.ResponsibilityCode.Substring(0, 4) == sendTo.SelectedValue.ToString().Substring(0, 4)) && m.ResponsibilityCode == MainUser.ResponsibilityCode && m.CreatedOn.Date >= Fromdate.Value.Date && m.CreatedOn.Date <= ToDate.Value.Date).Include("Packages").Include("Sender").OrderBy(o => o.CreatedOn).ToList();
            }

            //---------------------بريد القسم  ---------------------
            else 
            {
                messages = _dataContext.Messages.Where(m => m.Sent == true && m.Packages.Any(p => p.ResponsibilityCode == sendTo.SelectedValue.ToString()) && m.ResponsibilityCode == MainUser.ResponsibilityCode && m.CreatedOn.Date >= Fromdate.Value.Date && m.CreatedOn.Date <= ToDate.Value.Date).Include("Packages").Include("Sender").OrderBy(o => o.CreatedOn).ToList();
            }

            var n = 0;
            foreach (var message in messages)
               
            {
                n = n + 1;
               
                dt.Rows.Add(new object[] { n, message.SerialNumber,message.Title,message.SenderDiscription,""
            });

            }


            byte[] filecontent = exportpdf(dt, sendTo.Text.ToString());

            Syncfusion.Pdf.PdfDocument FinalDoc = new Syncfusion.Pdf.PdfDocument();

            var TempName = $@"\[followPuCord][{ Guid.NewGuid() }]" + ".pdf";
            MemoryStream stream = new MemoryStream(0);
            stream.Write(filecontent, 0, filecontent.Length);

            using (var fileStream = new FileStream(@"D:\ASC Project\ACS.Archives\CommentTempFiles\" + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.Position = 0;
                stream.CopyTo(fileStream);
            }

            //pdfViewerControl1.Load(@"D:\ASC Project\ACS.Archives\TempFiles\" + TempName);
            var FilePath = @"D:\ASC Project\ACS.Archives\CommentTempFiles\" + TempName;
            return FilePath;

        }

        private byte[] exportpdf(DataTable dtCommets, string title)
        {

            // creating document object  
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A4);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
            Document doc = new Document(rec);
            doc.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            writer.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

            doc.Open();

            //Creating font ===============================================================
            string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";
            BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);

            var el = new Chunk();
            iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, el.Font.Size, el.Font.Style, el.Font.Color);
            el.Font = f2;
           
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(basefont, 12, el.Font.Style, BaseColor.BLACK);

            // =============== add header =================================== 
           
            PdfPTable HeaderTable = new PdfPTable(3);

            HeaderTable.HorizontalAlignment = 0;
            HeaderTable.TotalWidth = 520f;
            HeaderTable.LockedWidth = true;
            float[] widths1 = new float[] { 120f, 250f ,150f };
            HeaderTable.SetWidths(widths1);

            
            HeaderTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

            string cellText0 = "الشركة الليبية للحديد والصلب " ;
            PdfPCell cell0 = new PdfPCell(new Phrase(12, cellText0, fntHead));
            cell0.BackgroundColor = new BaseColor(System.Drawing.Color.Orange);
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            cell0.PaddingBottom = 10;
            HeaderTable.AddCell(cell0);


            string cellText1 = "قائمة بالبريد المحال إلى : " + sendTo.Text;
                PdfPCell cell1 = new PdfPCell(new Phrase(12, cellText1, fntHead));
            cell1.BackgroundColor = new BaseColor(System.Drawing.Color.Orange);
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.PaddingBottom = 10;
                HeaderTable.AddCell(cell1);

            string cellText2 = "بتاريخ: " + DateTime.Now.ToString("dd-MM-yyyy");
            PdfPCell cell2 = new PdfPCell(new Phrase(10, cellText2, fntHead));
            cell2.BackgroundColor = new BaseColor(System.Drawing.Color.Orange);
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.PaddingBottom = 10;
            HeaderTable.AddCell(cell2);

            doc.Add(HeaderTable);
//================================================================================
            //Adding a line  
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(p);

            //Adding line break  

            doc.Add(new Chunk("\n", fntHead));

            //Adding  PdfPTable  
            PdfPTable table = new PdfPTable(dtCommets.Columns.Count);

            table.HorizontalAlignment = 0;
            table.TotalWidth = 520f;
            table.LockedWidth = true;
            float[] widths = new float[] { 120f, 120f, 120f, 100f, 20f };
            table.SetWidths(widths);

            // new 
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

            for (int i = 0; i < dtCommets.Columns.Count; i++)
            {
                string cellText = dtCommets.Columns[i].ColumnName;

                PdfPCell cell = new PdfPCell(new Phrase(10, cellText, el.Font));

                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));

                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 10;
                table.AddCell(cell);

            }

            //writing table Data  
            for (int i = 0; i < dtCommets.Rows.Count; i++)
            {
                for (int j = 0; j < dtCommets.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(10, dtCommets.Rows[i][j].ToString(), el.Font));
                    table.AddCell(cell);
                }
            }

            doc.Add(table);
            doc.Close();

            byte[] result = ms.ToArray();
            return result;

        }

        private void btnShowRep_Click(object sender, EventArgs e)
        {
           
            ShowReportsForm ShowRep = new ShowReportsForm(ExportPDF());

            //ShowRep.Width = this.Width - 200;
            //ShowRep.Height = this.Height - 150;
            //ShowRep.StartPosition = FormStartPosition.CenterParent;

            // NewMessage.Show();
            ShowRep.ShowDialog(this);

        }

        private void RepForm_Load(object sender, EventArgs e)
        {
            //var x = sendTo.SelectedValue;
            users=_dataContext.Users.Where(c => c.JobCatId==1 && (
            (c.ResponsibilityCode.Substring(0,2)=="43" && c.ResponsibilityCode.Substring(4, 1) == "0")
            || (c.ResponsibilityCode.Substring(0, 2) == "44" && c.ResponsibilityCode.Substring(4, 1) == "0")
            || c.ResponsibilityCode.Substring(0, 5) == "47301")).OrderBy(u => u.ResponsibilityCode).ToList();

            sendTo.DataSource = users;
            sendTo.DisplayMember = "JobtypeName";
            sendTo.ValueMember = "ResponsibilityCode";

            MainUser = (ApplicationUser)_dataContext.Users.Where(x => x is ApplicationUser && x.JobCatId == 1 && x.JobStatus == "AE" && (x.ResponsibilityCode == StaticParametrs.CurrentUser.ResponsibilityCode)).OrderBy(x => x.ResponsibilityCode).FirstOrDefault();
        }
    }
}
