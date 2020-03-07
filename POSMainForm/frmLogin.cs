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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SQLConn.getData();
            
        }

        private void Login()
        {
            try
            {
                SQLConn.sqL = "SELECT * FROM staff WHERE Username = '" + txtusername.Text + "' AND Password = '" + txtPassword.Text + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {

                    if (SQLConn.dr["Role"].ToString().ToUpper() == "ADMIN")
                    {
                        // Show Admin Panel
                        frmMain m = new frmMain(SQLConn.dr["Username"].ToString(),Convert.ToInt32(SQLConn.dr["StaffID"]));
                        m.Show();
                        //this.Hide();
                    }
                    else 
                    {
                        // Show POS Panel
                        frmPOS m = new frmPOS(SQLConn.dr["Username"].ToString(), Convert.ToInt32(SQLConn.dr["StaffID"]), "Staff");
                        m.Show();
                        this.Hide();
                        //MessageBox.Show("Staff");
                    }
                }
                else
                {
                    Interaction.MsgBox("Invalid Password. Please try again.",MsgBoxStyle.Exclamation, "Login");
                }

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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                frmDatabaseConfig dc = new frmDatabaseConfig();
                dc.ShowDialog();
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "" && txtPassword.Text != "")
            {

                Login();
                //SQLConn.ConnDB();
                //try
                //{
                //    using (SqlCommand cmd = new SqlCommand("SELECT * from users where username = @username AND password = @password;", connection))
                //    {
                //        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                //        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                //        SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                //        SQLConn.dr = SQLConn.cmd.ExecuteReader();
                //        SQLConn.dr.Read();
                //        if (!SQLConn.dr.HasRows)
                //        {
                //            frmMain frmmain = new frmMain("Bilal");
                //            frmmain.Show();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Invalid Username of Password");
                //        }
                //    }
                //}
                //catch
                //{
                //}
            }
            else
            {
                if (txtusername.Text == "")
                {
                    MessageBox.Show("Enter Username");
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Enter Mobile Number");
                }

            }
        }
    }
}
