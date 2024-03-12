using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ACS.Archives
{
    public partial class ShowReportsForm : Form
    {
        protected readonly string _filePath;
        public ShowReportsForm(
            string FilePath)
        {
            _filePath = FilePath;
            InitializeComponent();
        }

        private void ShowReportsForm_Load(object sender, EventArgs e)
        {
            pdfViewerControl1.ZoomTo(75);
            pdfViewerControl1.Load(_filePath);

        }
    }
}
