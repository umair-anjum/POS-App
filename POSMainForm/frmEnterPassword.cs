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
    public partial class frmEnterPassword : Form
    {
      
        public frmEnterPassword()
        {
            InitializeComponent();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
            this.Close();
        }

        private bool IsPasswordCorrect()
        {
            bool ret = false;

            try
            {
                SQLConn.sqL = "SELECT * FROM Staff WHERE Role ='Admin' AND UPassword = '" + txtAdminPassword.Text + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    ret = true;
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

            return ret;
        }

        private void txtAdminPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOkay.PerformClick();
            }
        }

       
    }
}
