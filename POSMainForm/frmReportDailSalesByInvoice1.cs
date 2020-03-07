using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POSMainForm
{
    public partial class frmReportDailSalesByInvoice1 : Form
    {

        string total = "";
        int totalpurchase;
        int totalselling;

        int expenseVal;
        //calculating purchase price
        //List<int> data = new List<int>();
        //List<int> data1 = new List<int>();
        public frmReportDailSalesByInvoice1(string expense)
        {
            try {
                this.expenseVal = int.Parse(expense);
            }
            catch (Exception ex) { }
                InitializeComponent();
        }

        private void frmReportDailSalesByInvoice1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_daily_duration.transactions' table. You can move, or remove it, as needed.
            // this.transactionsTableAdapter.Fill(this.report_daily_duration.transactions);
            // TODO: This line of code loads data into the 'report_daily_duration.transactions' table. You can move, or remove it, as needed.
            //this.transactionsTableAdapter.Fill(this.report_daily_duration.transactions);

            //this.reportV.RefreshReport();

            
          //  MessageBox.Show("" + data[0]+ " "+data.Count);

        }

        private void reportV_Load(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            priftLoss();
            totalAmount();
           
           this.transactionsTableAdapter.Fill(this.report_daily_duration.transactions, "" + fromdate.Value.ToShortDateString(), "" + todate.Value.ToShortDateString());
          
            ReportParameter startDate = new ReportParameter("FromDate", fromdate.Value.ToLongDateString());
            ReportParameter ToDate = new ReportParameter("ToDate", todate.Value.ToLongDateString());

            ReportParameter sum = new ReportParameter("total", total);
            ReportParameter selling = new ReportParameter("sellingPrice", "" + totalselling);
            ReportParameter purchase = new ReportParameter("purchasePrice", "" + totalpurchase);
            ReportParameter totalprofitRS = new ReportParameter("totalprofitRS", "" + (totalselling - totalpurchase));
            ReportParameter totalprofitPercentage = new ReportParameter("totalprofitPercentage", "" + ProfitPrenctage(totalselling,totalpurchase));
            this.reportV.LocalReport.SetParameters(new ReportParameter[] { startDate, ToDate, sum, selling, purchase, totalprofitRS, totalprofitPercentage });
            this.reportV.RefreshReport();
        }
        public void report()
        {
            //productPurchasePrices();
            //producQuantity();

            priftLoss();

           totalAmount();
            
            this.transactionsTableAdapter.Fill(this.report_daily_duration.transactions, "" + fromdate.Value.ToShortDateString(), "" + todate.Value.ToShortDateString());

            ReportParameter startDate = new ReportParameter("FromDate", fromdate.Value.ToLongDateString());
            ReportParameter ToDate = new ReportParameter("ToDate", todate.Value.ToLongDateString());

            ReportParameter sum = new ReportParameter("total", total);
            ReportParameter selling = new ReportParameter("sellingPrice", "Rs "+totalselling);
            ReportParameter purchase = new ReportParameter("purchasePrice","Rs "+totalpurchase);
            ReportParameter totalprofitRS = new ReportParameter("totalprofitRS", "Rs " + (totalselling - totalpurchase));
            ReportParameter totalprofitPercentage = new ReportParameter("totalprofitPercentage", "" + ProfitPrenctage(totalselling, totalpurchase)+"%");
            ReportParameter netprofit = new ReportParameter("NetProfit", "Rs " + ((totalselling - totalpurchase)-expenseVal));
            this.reportV.LocalReport.SetParameters(new ReportParameter[] { startDate, ToDate, sum, selling, purchase,totalprofitRS,totalprofitPercentage,netprofit });
            this.reportV.RefreshReport();
                fromdate.Hide();
                todate.Hide();
                btnload.Hide();
                label1.Hide();
                label2.Hide();

           // }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void totalAmount()
        {


            try
            {
                SQLConn.sqL = "SELECT sum(TotalAmount) FROM transactions WHERE TDate BETWEEN '" +fromdate.Value.ToShortDateString()+ "' AND '" +todate.Value.ToShortDateString()+ "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();


                if (SQLConn.dr.Read())
                {
                    //txtName = SQLConn.dr[0].ToString();
                    //txtName.Text = SQLConn.dr[1].ToString();
                    total = SQLConn.dr[0].ToString();

                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }

        }

      
        public void priftLoss()
        {


            try
            {
                SQLConn.sqL = "select SUM(Total),sum(PurchasePrice * Quantity) from transactiondetails INNER JOIN transactions ON transactiondetails.InvoiceNo = transactions.InvoiceNo where TDate like '7/9/2019' ";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();


                if (SQLConn.dr.Read())
                {
            
                //txtName = SQLConn.dr[0].ToString();
                //txtName.Text = SQLConn.dr[1].ToString();
                 
                    totalselling  = int.Parse(SQLConn.dr[0].ToString());
                    totalpurchase = int.Parse(SQLConn.dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }

        }


        public double ProfitPrenctage(int s,int p)
        {

            double per;
            double z=0;
            per = (s - p);
            z = (per / s)*100;
            return z;
        }

        //public void  productPurchasePrices()
        //{
        //    ListViewItem x = null;
         

        //    try
        //        {
        //            SQLConn.sqL = "select PurchasePrice from product INNER JOIN transactiondetails ON product.Description like transactiondetails.ProductDesc";
        //            SQLConn.ConnDB();
        //            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
        //            SQLConn.dr = SQLConn.cmd.ExecuteReader();

                   
        //          //  ListView1.Items.Clear();


        //            while (SQLConn.dr.Read() == true)
        //            {
        //                x = new ListViewItem();
        //               data.Add(int.Parse(SQLConn.dr["PurchasePrice"].ToString()));
        //                //x.SubItems.Add(SQLConn.dr["Description"].ToString());
        //                //x.SubItems.Add(SQLConn.dr["Barcode"].ToString());
        //                //x.SubItems.Add(SQLConn.dr["CategoryName"].ToString());
        //                //x.SubItems.Add(SQLConn.dr["StocksOnHand"].ToString());
        //                //x.SubItems.Add(SQLConn.dr["PurchasePrice"].ToString());
        //                //x.SubItems.Add(Strings.Format(SQLConn.dr["SellingPrice"], "#,##0.00"));

        //               // ListView1.Items.Add(x);
        //            }
               
        //        }
        //        catch (Exception ex)
        //        {
        //            Interaction.MsgBox(ex.ToString());
        //        }
        //        finally
        //        {

        //       // MessageBox.Show("" + x[0]);
        //            SQLConn.cmd.Dispose();
        //            SQLConn.conn.Close();
        //        }
        //    }

        //public void producQuantity()
        //{
        //    //ListViewItem x = null;
           

        //    try
        //    {
        //        SQLConn.sqL = "select Quantity from transactiondetails INNER JOIN product ON product.Description like transactiondetails.ProductDesc";
        //        SQLConn.ConnDB();
        //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
        //        SQLConn.dr = SQLConn.cmd.ExecuteReader();


        //        //  ListView1.Items.Clear();


        //        while (SQLConn.dr.Read() == true)
        //        {
        //           // x = new ListViewItem();
        //            data1.Add(int.Parse(SQLConn.dr["Quantity"].ToString()));
        //            //x.SubItems.Add(SQLConn.dr["Description"].ToString());
        //            //x.SubItems.Add(SQLConn.dr["Barcode"].ToString());
        //            //x.SubItems.Add(SQLConn.dr["CategoryName"].ToString());
        //            //x.SubItems.Add(SQLConn.dr["StocksOnHand"].ToString());
        //            //x.SubItems.Add(SQLConn.dr["PurchasePrice"].ToString());
        //            //x.SubItems.Add(Strings.Format(SQLConn.dr["SellingPrice"], "#,##0.00"));

        //            // ListView1.Items.Add(x);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox(ex.ToString());
        //    }
        //    finally
        //    {

        //        // MessageBox.Show("" + x[0]);
        //        SQLConn.cmd.Dispose();
        //        SQLConn.conn.Close();
        //    }
        //}

        //public int calculate() {
        //    int n = data.Count;
        //    int sum = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        sum += data[i] * data1[i];
        //    }

        //    return sum;
        //}

    }
}
