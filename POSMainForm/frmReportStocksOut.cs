using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace POSMainForm
{
    public partial class frmReportStocksOut : Form
    {
        DateTime StartDate;
        DateTime EndDate;

        public frmReportStocksOut(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            StartDate = startDate;
            EndDate = endDate;
        }

        private void frmReportStocksOut_Load(object sender, EventArgs e)
        {

            LoadReport();
        }

        private void LoadReport()
        {
            //try
            //{
            //    SQLConn.sqL = "SELECT ProductCode, P.Description, STR_TO_DATE(REPLACE(TDate, '-', '/'), '%m/%d/%Y') as DateOut, SUM(TD.Quantity) as Quantity, TD.ItemPrice as Price, (SUM(TD.Quantity) * TD.ItemPrice) as TotalAmount FROM Product as P, Transactions as T, TransactionDetails as TD WHERE P.ProductNo = TD.ProductNo AND TD.InvoiceNo = T.InvoiceNo AND STR_TO_DATE(REPLACE(TDate, '-', '/'), '%m/%d/%Y') BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' GROUP BY P.ProductNo, TDate ORDER By TDate, Description";
            //    SQLConn.ConnDB();
            //    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                
            //    SQLConn.da = new SqlDataAdapter(SQLConn.cmd);

            //    this.dsReportC.StocksOut.Clear();
            //    SQLConn.da.Fill(this.dsReportC.StocksOut);

            //    ReportParameter startDate = new ReportParameter("StartDate", StartDate.ToString());
            //    ReportParameter endDate = new ReportParameter("EndDate", EndDate.ToString());
            //    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { startDate, endDate });

            //    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //    this.reportViewer1.ZoomPercent = 90;
            //    this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;

            //    this.reportViewer1.RefreshReport();

            //}
            //catch (Exception ex)
            //{
            //    Interaction.MsgBox(ex.ToString());
            //}
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
