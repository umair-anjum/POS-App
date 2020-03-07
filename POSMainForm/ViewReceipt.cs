using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace POSMainForm
{
    public partial class ViewReceipt : Form
    {


        //Company Setting
        //  txtName.Tag = "";
       // string txtName = "";
        string txtAddress = "";
        string txtPhoneNo = "xxxx-xxxxxxx";
        string txtEmail = "";
        string txtWebsite = "";
        //txtTINNumber.Text = "";

        public ViewReceipt()
        {
          
            InitializeComponent();
        }

        private void ViewReceipt_Load(object sender, EventArgs e)
        {
            
            GetCompanyInfo();
           // frmSystemSetting obj = (System.Windows.Forms.Application.OpenForms["frmSystemSetting"] as frmSystemSetting);
            frmPOS p = (System.Windows.Forms.Application.OpenForms["frmPOS"] as frmPOS);
            frmPayment p1 = (System.Windows.Forms.Application.OpenForms["frmPayment"] as frmPayment);
            try {
                txtPhoneNo = p1.Usphone;
            }
            catch (Exception ex)
            {


            }
            // TODO: This line of code loads data into the 'reciept.DataTable1' table. You can move, or remove it, as needed.

            this.DataTable1TableAdapter.Fill(this.reciept.DataTable1,""+p.InvoiceNo);

            DateTime now = DateTime.Now;
            ReportParameter startDate = new ReportParameter("Date", now.ToLongDateString());
        
            ReportParameter phone = new ReportParameter("phone", txtPhoneNo);
            ReportParameter email = new ReportParameter("email", txtEmail);
            ReportParameter address = new ReportParameter("address", txtAddress);
            ReportParameter website = new ReportParameter("website", txtWebsite);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { startDate,phone,email,address,website});
            this.reportViewer1.RefreshReport();
        }


      
        public void GetCompanyInfo()
        {
            try
            {
                SQLConn.sqL = "SELECT CompanyID, Name, Address, PhoneNo, Email, Website, TINNumber FROM Company";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();


                if (SQLConn.dr.Read())
                {
                    //txtName = SQLConn.dr[0].ToString();
                    //txtName.Text = SQLConn.dr[1].ToString();
                    txtAddress = SQLConn.dr[2].ToString();
                   // txtPhoneNo = SQLConn.dr[3].ToString();
                    txtEmail = SQLConn.dr[4].ToString();
                    txtWebsite = SQLConn.dr[5].ToString();
                    //txtTINNumber.Text = SQLConn.dr[6].ToString();
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

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
