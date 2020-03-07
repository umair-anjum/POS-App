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
using System.IO;
namespace POSMainForm
{
    public partial class frmAddEditProduct : Form
    {
        int productID;
        int categoryID;
        string imglocation = "";
        public frmAddEditProduct(int prodID)
        {
            InitializeComponent();
            productID = prodID;
        }

        private void GetProductNo()
        {
            try
            {
                SQLConn.sqL = "SELECT ProductNo FROM Product ORDER BY ProductNo DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblProductNo.Text = (Convert.ToInt32(SQLConn.dr["ProductNo"]) + 1).ToString();
                }
                else
                {
                    lblProductNo.Text = "1";
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


        private void LoadUpdateCategory()
        {
            try
            {
                SQLConn.sqL = "SELECT ProductNo, ProductCode, P.Description, Barcode, P.CategoryNo, CategoryName, SellingPrice, StocksOnHand, PurchasePrice FROM Product as P LEFT JOIN Category as C ON P.CategoryNo = C.CategoryNo WHERE ProductNo = '" + productID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblProductNo.Text = SQLConn.dr["ProductNo"].ToString();
                    txtProductCode.Text = SQLConn.dr["ProductCode"].ToString();
                    txtDescription.Text = SQLConn.dr["Description"].ToString();
                    txtBarcode.Text = SQLConn.dr["Barcode"].ToString();
                    txtCategory.Text = SQLConn.dr["CategoryName"].ToString();
                    txtCategory.Tag = SQLConn.dr["CategoryNo"];
                    txtSellingPrice.Text = Strings.Format(SQLConn.dr["SellingPrice"], "#,##0.00");
                    txtStocksOnHand.Text = SQLConn.dr["StocksOnHand"].ToString();
                    txtPurchasePrice.Text = SQLConn.dr["PurchasePrice"].ToString();
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


        private void AddProducts()
        {
            bool empty = false;
            //image tasks*********
            byte[] image = null;
            if (imglocation != "")
            {
                FileStream Stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(Stream);
                image = br.ReadBytes((int)Stream.Length);
            }
            else
            {
                //MessageBox.Show("Please Add Image");
                empty = true;
            }
            try
            {
                SQLConn.sqL = "INSERT INTO Product(ProductCode, Description, Barcode, SellingPrice, StocksOnHand, PurchasePrice, CategoryNo,photo) VALUES('" + txtProductCode.Text + "', '" + txtDescription.Text + "', '" + txtBarcode.Text.Trim() + "', '" + txtSellingPrice.Text.Replace(",", "") + "', '" + txtStocksOnHand.Text.Replace(",", "") + "', '" + txtPurchasePrice.Text + "', '" + categoryID + "',@image)";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.Add(new SqlParameter("@image", image));
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("Product successfully added.", MsgBoxStyle.Information, "Add Product");
                AddStockIn();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }
        private void AddStockIn()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO StockIn(ProductNo, Quantity, DateIn) Values('" + lblProductNo.Text + "', '" + txtStocksOnHand.Text + "', '" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')";
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
        private void UpdateProduct()
        {
            try
            {
                SQLConn.sqL = "UPDATE product SET ProductCode = '" + txtProductCode.Text + "', Description = '" + txtDescription.Text + "', Barcode = '" + txtBarcode.Text.Trim() + "', SellingPrice = '" + txtSellingPrice.Text.Replace(",", "") + "', StocksOnHand = '" + txtStocksOnHand.Text.Replace(",", "") + "', PurchasePrice = '" + txtPurchasePrice.Text + "', CategoryNo ='" + categoryID + "' WHERE ProductNo = '" + productID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();

                Interaction.MsgBox("Product successfully Updated.", MsgBoxStyle.Information, "Update Product");
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

        private void ClearFields()
        {
            lblProductNo.Text = "";
            txtProductCode.Text = "";
            txtDescription.Text = "";
            txtBarcode.Text = "";
            txtCategory.Text = "";
            txtSellingPrice.Text = "";
            txtStocksOnHand.Text = "";
            txtPurchasePrice.Text = "";
        }

        private void frmAddEditProduct_Load(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                lblTitle.Text = "Adding New Product";
                ClearFields();
                GetProductNo();
            }
            else
            {
                lblTitle.Text = "Updating Product";
                LoadUpdateCategory();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == "")
            {
                Interaction.MsgBox("Please select category.", MsgBoxStyle.Information, "Category");
                return;
            }
            else if (txtDescription.Text == "") {
                Interaction.MsgBox("Please enter description.", MsgBoxStyle.Information, "Description");
                return;
            }
            else if (txtProductCode.Text== "")
            {
                Interaction.MsgBox("Please enter product code.", MsgBoxStyle.Information, "Product Code");
                return;
            }
            else if (txtPurchasePrice.Text == "")
            {
                Interaction.MsgBox("Please enter product purchase price.", MsgBoxStyle.Information, "Purchase Price");
                return;
            }
            else if (txtSellingPrice.Text == "")
            {
                Interaction.MsgBox("Please enter product selling price.", MsgBoxStyle.Information, "Selling Price");
                return;
            }
            else if (txtStocksOnHand.Text == "")
            {
                Interaction.MsgBox("Please enter stockOnHand.", MsgBoxStyle.Information, "Stock On Hand");
                return;
            }
            else if (SQLConn.adding == true)
            {
                AddProducts();
            }
            else
            {
                UpdateProduct();
               
            }

            if (System.Windows.Forms.Application.OpenForms["frmListProduct"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmListProduct"] as frmListProduct).LoadProducts("");
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            frmSelectCategory flc = new frmSelectCategory(this);
            flc.ShowDialog();
        }

        public string Category
        {
            get { return txtCategory.Text; }
            set { txtCategory.Text = value; }
        }

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
