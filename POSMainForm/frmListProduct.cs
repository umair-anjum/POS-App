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
    public partial class frmListProduct : Form
    {
        int productID;
        public frmListProduct()
        {
            InitializeComponent();
        }

        public void LoadProducts(string strSearch)
        {
            try
            {
                SQLConn.sqL = "SELECT ProductNo, ProductCode, P.Description, Barcode, SellingPrice, StocksOnHand, PurchasePrice, CategoryName FROM Product as P LEFT JOIN Category C ON P.CategoryNo = C.CategoryNo WHERE P.Description LIKE '" + strSearch + "%' ORDER BY Description";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                ListViewItem x = null;
                ListView1.Items.Clear();


                while (SQLConn.dr.Read() == true)
                {
                    x = new ListViewItem(SQLConn.dr["ProductNo"].ToString());
                    x.SubItems.Add(SQLConn.dr["ProductCode"].ToString());
                    x.SubItems.Add(SQLConn.dr["Description"].ToString());
                    x.SubItems.Add(SQLConn.dr["Barcode"].ToString());
                    x.SubItems.Add(SQLConn.dr["CategoryName"].ToString());
                    x.SubItems.Add(SQLConn.dr["StocksOnHand"].ToString());
                    x.SubItems.Add(SQLConn.dr["PurchasePrice"].ToString());
                    x.SubItems.Add(Strings.Format(SQLConn.dr["SellingPrice"], "#,##0.00"));

                    ListView1.Items.Add(x);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            SQLConn.adding = true;
            SQLConn.updating = false;
            int init = 0;
            frmAddEditProduct aeP = new frmAddEditProduct(init);
            aeP.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ListView1.Items.Count == 0)
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(ListView1.FocusedItem.Text))
                {

                }
                else
                {
                    SQLConn.adding = false;
                    SQLConn.updating = true;
                    productID = Convert.ToInt32(ListView1.FocusedItem.Text);
                    frmAddEditProduct aeP = new frmAddEditProduct(productID);
                    aeP.ShowDialog();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SQLConn.strSearch = Interaction.InputBox("ENTER PRODUCT Description.", "Search Product", "");

            if (SQLConn.strSearch.Length >= 1)
            {
                LoadProducts(SQLConn.strSearch.Trim());
            }
            else if (string.IsNullOrEmpty(SQLConn.strSearch))
            {
                return;
            }
        }

        private void frmListProduct_Load(object sender, EventArgs e)
        {
            LoadProducts("");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStocksIn_Click(object sender, EventArgs e)
        {
            if (ListView1.Items.Count == 0)
            {
                Interaction.MsgBox("Please select record to add stock", MsgBoxStyle.Exclamation, "StocksIn");
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(ListView1.FocusedItem.Text))
                {

                }
                else
                {
                    
                    productID = Convert.ToInt32(ListView1.FocusedItem.Text);
                    frmListProductStocksIn aeP = new frmListProductStocksIn(productID);
                    aeP.ShowDialog();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to add stock", MsgBoxStyle.Exclamation, "StocksIn");
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Interaction.MsgBox("Are you sure you want to Delete?", MsgBoxStyle.YesNo, "Delete Product") == MsgBoxResult.Yes)
            {
                try {
                    productID = Convert.ToInt32(ListView1.FocusedItem.Text);
                }
                catch (Exception ex) { }
                try
                {
                    SQLConn.sqL = "DELETE FROM product WHERE ProductNo = '" + productID + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.cmd.ExecuteNonQuery();
                   
                    MessageBox.Show("Deleted Successfully");
                    ListView1.Refresh();
                    LoadProducts("");
                }
                catch (Exception ex) {

                    MessageBox.Show("" + ex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadProducts("");
        }
    }
}
