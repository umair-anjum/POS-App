using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace POSMainForm
{
    public partial class frmPOS : Form
    {
        DataGridViewCellEventArgs e = null;
        int count = 0;
        int staffID;
        string username;
        string type;
        public int InvoiceNo = 0;

        string Productname;
        //  double Tprice;
        public frmPOS()
        {
            InitializeComponent();

            //ScanResult result = CSBarcodeScanner.ScanOnlyBarcode(txtProductCode.Text);
            //Console.WriteLine(result.BarcodeType.ToString() + "--" + result.BarcodeData);
            //Console.ReadKey();

        }
        public frmPOS(string username, int staffID, string type)
        {
            this.staffID = staffID;
            this.username = username;
            this.type = type;

            InitializeComponent();
        }
        private void getInvoiceNo()
        {
            try
            {

                SQLConn.sqL = "SELECT TOP 1 InvoiceNo FROM transactions ORDER BY InvoiceNo DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    InvoiceNo = int.Parse(SQLConn.dr["InvoiceNo"].ToString()) + 1;
                    invoiceno.Text = "Invoice No: " + InvoiceNo.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }
        private void getData(string productN)
        {
            try
            {
                SQLConn.sqL = "SELECT ProductCode, Description, SellingPrice, StocksOnHand FROM product WHERE ProductCode = '" +productN+ "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {

                    if (int.Parse(SQLConn.dr["StocksOnHand"].ToString()) - 1 > 0)
                    {
                        count++;
                        textboxtotalitems.Text = count.ToString() + " items";
                        dataGridView1.Rows.Add(Productname, SQLConn.dr["ProductCode"].ToString(),
                            SQLConn.dr["Description"].ToString(),
                            SQLConn.dr["SellingPrice"].ToString(),
                            "1",
                            SQLConn.dr["SellingPrice"].ToString());
                    }
                    else
                    {
                        Interaction.MsgBox("Product Not Available", MsgBoxStyle.Exclamation, SQLConn.dr["ProductCode"].ToString());
                    }
                    // txtProductCode.Text = "";
                    calculateprice();

                }
                else
                {
                    MessageBox.Show("Invalid BarCode");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void getData1()
        {
            try
            {
                SQLConn.sqL = "SELECT ProductCode, Description, SellingPrice, StocksOnHand FROM product WHERE ProductCode = '" + Pcode.Text + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {

                    if (int.Parse(SQLConn.dr["StocksOnHand"].ToString()) - 1 > 0)
                    {
                        count++;
                        textboxtotalitems.Text = count.ToString() + " items";
                        dataGridView1.Rows.Add("", SQLConn.dr["ProductCode"].ToString(),
                            SQLConn.dr["Description"].ToString(),
                            SQLConn.dr["SellingPrice"].ToString(),
                            "1",
                            SQLConn.dr["SellingPrice"].ToString());
                    }
                    else
                    {
                        Interaction.MsgBox("Product Not Available", MsgBoxStyle.Exclamation, SQLConn.dr["ProductCode"].ToString());
                    }
                    // txtProductCode.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid Barcode");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {

                SQLConn.sqL = "select photo from product WHERE ProductCode = '" + Pcode.Text + "'";
                SQLConn.ConnDB();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)

                {

                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["photo"]);

                    pictureBox1.Image = new Bitmap(ms);

                }
            }
            catch (Exception ex) { }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (QuantityVal.Text == "")
            {

                MessageBox.Show("Please enter quantity");
            }
            else if (e == null) {

                MessageBox.Show("Please select the product from List");
            }
            else {
                if (checkQuantity(int.Parse(QuantityVal.Text))==true)
                {
                    randQuantity();
                    QuantityVal.Text = "";
                }
                else
                {
                    MessageBox.Show("Insuficient Quantity available!!!! ");
                }
               
            }

        }
        private double calculateprice()
        {
            double total_price = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int price = int.Parse(dataGridView1[5, i].Value.ToString());
                total_price = total_price + price;
            }
            textboxtotalprice.Text = Strings.FormatNumber(total_price.ToString());
            return total_price;
        }
        private bool isExists()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (row.Cells["code"].Value == null)
                    return false;
                //string a = row.Cells["Code"].Value.ToString();
                String v= row.Cells["code"].Value.ToString();
                if (row.Cells["Code"].Value.ToString() == Productname)
                {
                    string quantity = row.Cells["Quantity"].Value.ToString();
                    if (checkQuantity(int.Parse(quantity) + 1) == true)
                    {
                        count++;
                        textboxtotalitems.Text = count.ToString() + " items";
                        string price = row.Cells["Price"].Value.ToString();
                        row.Cells["Quantity"].Value = (int.Parse(quantity) + 1).ToString();
                        row.Cells["Subtotal"].Value = ((int.Parse(quantity) + 1) * int.Parse(price)).ToString();
                    }
                    else
                    {
                        Interaction.MsgBox(row.Cells["Name"].Value.ToString() + "Product Not Available", MsgBoxStyle.Critical, "Error");
                    }
                  //  txtProductCode.Text = "";
                    return true;
                }
            }
            return false;
        }
        private bool checkQuantity(int quantity)
        {
            try
            {

                SQLConn.sqL = "SELECT StocksOnHand FROM product WHERE ProductCode = '" +Productname+ "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    int dbquantity = int.Parse(SQLConn.dr["StocksOnHand"].ToString());
                    if (dbquantity - quantity > 0)
                        return true;
                    return false;

                }
                else
                {
                    //MessageBox.Show("Invalid Password. Please try again.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
            return false;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Enter data in Database too
        }

        private void picClose_Click(object sender, EventArgs e)
        {

            if (Interaction.MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit System") == MsgBoxResult.Yes)
            {
                Application.Exit();
            }
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.e = e;
          
        }
        public void UpdateProductQuantity()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    SQLConn.sqL = "select StocksOnHand from product where Barcode = '" + row.Cells["Code"].Value.ToString() + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();
                    if (SQLConn.dr.Read() == true)
                    {
                        int stocks = int.Parse(SQLConn.dr["StocksOnHand"].ToString());
                        SQLConn.sqL = "update product SET StocksOnHand = @stocks where Barcode = '" + row.Cells["Code"].Value.ToString() + "'";

                        SQLConn.ConnDB();
                        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                        SQLConn.cmd.Parameters.AddWithValue("@stocks", (stocks - int.Parse(row.Cells["Quantity"].Value.ToString())));
                        SQLConn.cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    SQLConn.cmd.Dispose();
                    SQLConn.conn.Close();
                }
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double total_price = calculateprice();
            //  int invoice = Convert.ToInt32(invoiceno.Text);

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please Add product");
            }
            else {
                frmPayment frmpayment = new frmPayment(InvoiceNo, total_price);
                frmpayment.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (Interaction.MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit System") == MsgBoxResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            textboxtotalprice.Text = Strings.FormatNumber(0);
            //  totalprice = textboxtotalprice.Text;
            getInvoiceNo();
            textbox_position.Text = type;
            textboxname.Text = username;
        }
        private void removeItem()
        {
            //this.e = e;
            try
            {
                if (e != null)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    int quantity = (int.Parse(row.Cells["quantity"].Value.ToString()));
                    if (quantity - 1 > 0)
                    {
                        row.Cells["Quantity"].Value = (quantity - 1).ToString();
                        row.Cells["SubTotal"].Value = (int.Parse(row.Cells["Price"].Value.ToString()) * (quantity - 1)).ToString();
                    }
                    else
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                    e = null;
                    count--;
                    if (count != 0)
                    {
                        textboxtotalitems.Text = count.ToString() + " items";
                    }
                    else
                    {
                        textboxtotalitems.Text = "";
                    }
                    calculateprice();
                }

            }
            catch (Exception ex) {

                MessageBox.Show(""+ex);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                // New Transactions
                button3.PerformClick();
                return true;    // indicate that you handled this keystroke
            }
            else if (keyData == Keys.F2)
            {
                // Remove Selected Item
                button4.PerformClick();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                // Settle Payment
                button6.PerformClick();
                return true;
            }
            else if (keyData == Keys.F4)
            {
                // Close
                button4.PerformClick();
                return true;
            }
            else if (keyData == Keys.F5)
            {
                // Reprint Invoice
                //button7.PerformClick();
                return true;
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count = 0;
            textboxtotalitems.Text = "";
            textboxtotalprice.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            getInvoiceNo();
        //    txtProductCode.Focus();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            removeItem();
        }

        public void AddTransaction(string phone)
        {
            //  string date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            string time = DateTime.Now.ToLongTimeString();
            try
            {
                SQLConn.sqL = "INSERT into transactions(TDate,TTime,TotalAmount,mobileno)values('" + DateTime.Now.ToShortDateString() + "','" + time + "' ,'" + double.Parse(textboxtotalprice.Text) + "','"+phone+"')";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {


            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length >= 13)
            {
             
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewReceipt v = new ViewReceipt();
            v.Show();
        }

        private void textboxtotalprice_TextChanged(object sender, EventArgs e)
        {

        }

        public void AddTransactionDetails(int invoiceId)
        {
            double purchaseprice = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                string quantity = row.Cells["Quantity"].Value.ToString();
                string price = row.Cells["Price"].Value.ToString();
                string Total = row.Cells["subtotal"].Value.ToString();
                string pdescription = row.Cells["name"].Value.ToString();




                try
                {

                    SQLConn.sqL = "SELECT PurchasePrice FROM product WHERE Description = '" + pdescription + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();

                    if (SQLConn.dr.Read() == true)
                    {
                        purchaseprice = double.Parse(SQLConn.dr["PurchasePrice"].ToString());

                    }
                    else
                    {
                        //MessageBox.Show("Invalid Password. Please try again.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    SQLConn.cmd.Dispose();
                    SQLConn.conn.Close();
                }







                try
                {
                    SQLConn.sqL = "INSERT into transactiondetails(InvoiceNo,ProductDesc,PurchasePrice,ItemPrice,Quantity,Total)values('" + invoiceId + "','" + pdescription + "','" + purchaseprice + "' ,'" + price + "','" + quantity + "','" + Total + "')";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                    SQLConn.dr = SQLConn.cmd.ExecuteReader();

                   // MessageBox.Show("Inserted succesfully");
                }
                catch (Exception ex)
                {

                }
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmSelectCategory flc = new frmSelectCategory(this);
            flc.ShowDialog();
        }

        private void QuantityVal_TextChanged(object sender, EventArgs e)
        {

        }
        public void randQuantity()
        {

            //this.e = e;
            
            if (e != null)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    int quantity = (int.Parse(row.Cells["quantity"].Value.ToString()));
                    if (quantity > 0)
                    {
                        row.Cells["Quantity"].Value = quantity + int.Parse(QuantityVal.Text);
                        row.Cells["SubTotal"].Value = (int.Parse(row.Cells["Price"].Value.ToString()) * (quantity + int.Parse(QuantityVal.Text)));
                        count = count + quantity;
                        textboxtotalitems.Text = count.ToString() + " items";
                    }
                    else
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                    e = null;

                    calculateprice();

                }
                catch (Exception ex) {


                }
            }
        }

        private void textboxtotalitems_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

            int i = 0;
            int top = 0;
            int left = 0;
           
            List<PictureBox> data = new List<PictureBox>();
          //  string query = "";
            int temp = 0;


            SQLConn.sqL = "select ProductCode ,photo from product";
            SQLConn.ConnDB();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SqlDataReader Reader;

            Reader = cmd.ExecuteReader();
            Reader.Read();
            if (Reader.HasRows)
            {

                do
                {
                    PictureBox pb = new PictureBox();

                    byte[] img = ((byte[])Reader[1]);
                   

                    pb.Size = new Size(this.Size.Width / 14, this.Size.Width / 12);  //I use this picturebox simply to debug and see if I can create a single picturebox, and that way I can tell if something goes wrong with my array of pictureboxes. Thus far however, neither are working.
                    pb.BackgroundImage = Properties.Resources.du1;
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    pb.Location = new Point(50, 50);
                    pb.Anchor = AnchorStyles.Left;
                    pb.Visible = true;
                    pb.Name = Reader[0].ToString();
                    // pb.ProductName = Reader[0].ToString();
                    //InitializeComponent();
                    this.Controls.Add(pb);
                    //  PictureBox[] pbName = new PictureBox[rowscount];
                    if (i % 2 == 0)
                    {
                        pb.Top = top;
                        pb.Left = 0;
                        left = left + 70;

                    }
                    else
                    {
                        pb.Top = top;
                        if (i % 2 != 0)
                            pb.Left = 70;
                        else
                            pb.Left = left;
                        top = Top + 70;
                    }

                    temp++;


                    pb.Size = new Size(150, 150);
                    MemoryStream mstream = new MemoryStream(img);

                    pb.Image = Image.FromStream(mstream); //change location according to ur pc
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    pb.Click += (sender2, e2) => Photoclickevent(sender, e, pb);
                 
                    data.Add(pb);
                   
                    flowLayoutPanel1.Controls.Add(pb);

                    
                    
                    //   MessageBox.Show("" + data.Count);
                    data.Add(pb);

                    i++;
                    available_Product.Text = "No of Available Products: " + i.ToString();
                    


                }
                while (Reader.Read());

              
                flowLayoutPanel1.AutoScroll = true;
            }

            Reader.Close();
        }
        private void Photoclickevent(object sender, EventArgs e, PictureBox pb)
        {

           
            Productname = pb.Name;
            // newbarcode.Text = textBox.Text;
            if (isExists() == false)
            {
                getData(pb.Name);
            }
            calculateprice();


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Pcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void downEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(isExists() == false){
                    getData1();
                }
                calculateprice();
                Pcode.Text = "";            }
        }

        private void btnchangeprice_Click(object sender, EventArgs e)
        {
            if (e == null)
            {

                MessageBox.Show("Please select the product from List");
            }
            else if (chagePrice.Text == "")
            {
                MessageBox.Show("Please Enter Price");
            }
            else {
                randPrice();
                chagePrice.Text = "";
            }
        }
        public void randPrice()
        {

            //this.e = e;

            if (e != null)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    int total = (int.Parse(row.Cells["SubTotal"].Value.ToString()));
                    if (total > 0)
                    {

                        row.Cells["SubTotal"].Value = int.Parse(chagePrice.Text);
                    }
                    else
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                    e = null;

                    calculateprice();

                }
                catch (Exception ex)
                {


                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
