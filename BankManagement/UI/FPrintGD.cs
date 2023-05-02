using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.UI
{
    public partial class FPrintGD : Form
    {
        private List<GiaoDich> _data;
        public FPrintGD(List<GiaoDich> data)
        {
            InitializeComponent();
            _data = data;
        }

        private void FPrintTrans_Load(object sender, EventArgs e)
        {
            ReportDataSource datasource = new ReportDataSource("bankDataSet", _data);
            rpViewer.LocalReport.DataSources.Clear();
            rpViewer.LocalReport.DataSources.Add(datasource);
            rpViewer.LocalReport.ReportPath = "Report1.rdlc";
            rpViewer.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
            this.rpViewer.RefreshReport();
        }
    }
}
