
//using Microsoft.Reporting.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ACS.Archives
{
    public partial class followCard : Form
    {
        public followCard()
        {
            InitializeComponent();

        }
        
        private void followCard_Load(object sender, EventArgs e)
        {
            pdfViewerControl1.ZoomTo (75);
            pdfViewerControl1.Load(@"D:\PDFCard.pdf");
        }
    }
}
