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
using System.Data.SqlClient;

namespace POSMainForm
{
    public partial class frmPayment : Form
    {
        int InvoiceNo;
        double TotalAmount;
        public string Usphone;
        public frmPayment(int invoiceNo, double totalAmount)
        {
            InitializeComponent();
            this.InvoiceNo = invoiceNo;
            this.TotalAmount = totalAmount;
        }

        private void AddPayment()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO payment(InvoiceNo, Cash, PChange) VALUES('" + InvoiceNo + "', '" + txtCash.Text.Replace(",", "") + "', '" + txtChange.Text.Replace(",", "") + "')";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
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

        private void frmPayment_Load(System.Object sender, System.EventArgs e)
        {
            //this.Location = new Point(515, 470);
            txtTA.Text = Strings.FormatNumber(TotalAmount).ToString();
            txtCash.Text = "";
        }

        private void txtCash_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == ControlChars.Cr)
            {

                if (userPhonrNo.Text == "" || userPhonrNo.Text.Length >=12)
                {
                    Interaction.MsgBox("Enter User Mobile No./ Renter Mobile No.", MsgBoxStyle.Information, "Mobile No");
                    userPhonrNo.Text = "";
                    userPhonrNo.Focus();
                    return;
                }
               else if (txtCash.Text == "")
                {
                    Interaction.MsgBox("Enter Cash", MsgBoxStyle.Information, "Cash");
                    return;
                }
                else if (Convert.ToDouble(txtTA.Text.Replace(",", "")) > Convert.ToDouble(txtCash.Text.Replace(",", "")))
                {
                    Interaction.MsgBox("Insuficient cash to paid the total amount", MsgBoxStyle.Exclamation, "payment");
                    txtCash.Focus();
                }
                else
                {
                   
                    AddPayment();
                    if (System.Windows.Forms.Application.OpenForms["frmPOS"] != null)
                    {
                        frmPOS p = (System.Windows.Forms.Application.OpenForms["frmPOS"] as frmPOS);
                        p.AddTransaction(userPhonrNo.Text);
                        p.AddTransactionDetails(p.InvoiceNo);
                        p.UpdateProductQuantity();
                       
                        //  frmPrintReceipt pr = new frmPrintReceipt(InvoiceNo);
                        //  pr.Show();

                        Interaction.MsgBox("Transaction completed. Press OK for a new transaction.", MsgBoxStyle.Information, "Transaction");
                        //p.NewTransaction();
                    }

                    // My.MyProject.Forms.frmPrintReceipt.Show();
                    Usphone = userPhonrNo.Text;

                    ViewReceipt v = new ViewReceipt();
                    v.Show();
                    this.Close();
                }
            }
        }


        private void frmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void frmPayment_Load_1(object sender, EventArgs e)
        {
            this.Location = new Point(515, 470);
            txtTA.Text = Strings.FormatNumber(TotalAmount);
            txtCash.Text = "";
           
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            txtChange.Text = Strings.Format(Conversion.Val(txtCash.Text.Replace(",", "")) - Conversion.Val(txtTA.Text.Replace(",", "")), "#,##0.00");
        }

        private void txtCash_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtTA_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
            userPhonrNo.Focus();
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {

        }

        private void userPhonrNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
