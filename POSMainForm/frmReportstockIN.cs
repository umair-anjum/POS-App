using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSMainForm
{
    public partial class frmReportstockIN : Form
    {
        DateTime stardate;
        DateTime Todate;
        public frmReportstockIN(DateTime stdate,DateTime todate)
        {
            this.stardate = stdate;
            this.Todate = todate;
            InitializeComponent();
        }

        private void frmReportstockIN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.stockin' table. You can move, or remove it, as needed.
            this.stockinTableAdapter.Fill(this.DataSet1.stockin,stardate.ToString("MM/dd/yyyy"),Todate.ToString("MM/dd/yyyy"));
            ReportParameter startDate = new ReportParameter("FromDate", stardate.ToLongDateString());
            ReportParameter ToDate = new ReportParameter("ToDate", Todate.ToLongDateString());

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { startDate, ToDate });
     
            this.reportViewer1.RefreshReport();
        }
    }
}
