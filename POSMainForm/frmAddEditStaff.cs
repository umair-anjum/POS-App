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
    public partial class frmAddEditStaff : Form
    {
        int LSStaffID;
        public frmAddEditStaff(int staffID)
        {
            
            InitializeComponent();
            LSStaffID = staffID;
        }

     
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtLastname.Text == "") {

                Interaction.MsgBox("Please enter FirstName.", MsgBoxStyle.Information, "FirstName");
                return;
            }
            else if (txtFirstname.Text == "")
            {

                Interaction.MsgBox("Please enter LastName.", MsgBoxStyle.Information, "LastName");
                return;
            }
            else if (txtStreet.Text == "")
            {

                Interaction.MsgBox("Please enter Street no.", MsgBoxStyle.Information, "Street No");
                return;
            }
            else if (txtCity.Text == "")
            {

                Interaction.MsgBox("Please enter City.", MsgBoxStyle.Information, "City");
                return;
            }
            else if (txtProvince.Text == "")
            {

                Interaction.MsgBox("Please enter Province.", MsgBoxStyle.Information, "Province");
                return;
            }
            else if (txtContractNo.Text == "")
            {

                Interaction.MsgBox("Please enter Contact no.", MsgBoxStyle.Information, "Contact No");
                return;
            }
            else if (txtUsername.Text == "")
            {

                Interaction.MsgBox("Please enter Username ", MsgBoxStyle.Information, "Username");
                return;
            }
            else if (txtPassword.Text == "")
            {

                Interaction.MsgBox("Please enter Password.", MsgBoxStyle.Information, "Password");
                return;
            }
            else if (txtRole.Text == "")
            {

                Interaction.MsgBox("Please enter Roll of staff00.", MsgBoxStyle.Information, "Roll");
                return;
            }
            else if (txtConfirmPWD.Text == "")
            {

                Interaction.MsgBox("Please enter Confirm password.", MsgBoxStyle.Information, "Confirm Password");
                return;
            }
            else if (SQLConn.adding == true)
            {
                AddStaff();
            }
            else
            {
                UpdateStaff();
            }

            if (System.Windows.Forms.Application.OpenForms["frmListStaff"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmListStaff"] as frmListStaff).LoadStaffs("");
            }

            this.Close();
        }

        private void GetStaffID()
        {
            try
            {
                SQLConn.sqL = "SELECT StaffID FROM STAFF ORDER BY StaffID DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblProductNo.Text = (Convert.ToInt32(SQLConn.dr["StaffID"]) + 1).ToString();
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

        private void AddStaff()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO STAFF(Lastname, Firstname, Street, City, Province, ContactNo, Username, Role, Password) VALUES('" + txtLastname.Text + "', '" + txtFirstname.Text + "', '" + txtStreet.Text + "', '" + txtCity.Text + "', '" + txtProvince.Text + "', '" + txtContractNo.Text + "', '" + txtUsername.Text + "', '" + txtRole.Text + "', '" + txtPassword.Text + "')";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("New staff successfully added.", MsgBoxStyle.Information, "Add Staff");
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

        private void UpdateStaff()
        {
            try
            {
                SQLConn.sqL = "Update STAFF SET Lastname = '" + txtLastname.Text + "', Firstname = '" + txtFirstname.Text + "', Street= '" + txtStreet.Text + "', City = '" + txtCity.Text + "', Province = '" + txtProvince.Text + "', ContactNo = '" + txtContractNo.Text + "', Username ='" + txtUsername.Text + "', Role = '" + txtRole.Text + "', Password = '" + txtPassword.Text + "' WHERE StaffID = '" + LSStaffID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("Staff record successfully updated", MsgBoxStyle.Information, "Update Staff");

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

        private void LoadUpdateStaff()
        {
            try
            {
                SQLConn.sqL = "SELECT * FROM STAFF WHERE StaffID = '" + LSStaffID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblProductNo.Text = SQLConn.dr["StaffID"].ToString();
                    txtLastname.Text = SQLConn.dr["lastname"].ToString();
                    txtFirstname.Text = SQLConn.dr["Firstname"].ToString();
                    txtStreet.Text = SQLConn.dr["Street"].ToString();
                    txtCity.Text = SQLConn.dr["City"].ToString();
                    txtProvince.Text = SQLConn.dr["Province"].ToString();
                    txtContractNo.Text = SQLConn.dr["ContactNo"].ToString();
                    txtUsername.Text = SQLConn.dr["username"].ToString();
                    txtRole.Text = SQLConn.dr["Role"].ToString();
                    txtPassword.Text = SQLConn.dr["Password"].ToString();
                    txtConfirmPWD.Text = SQLConn.dr["Password"].ToString();

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

        private void ClearFields()
        {
            lblProductNo.Text = "";
            txtLastname.Text = "";
            txtFirstname.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtContractNo.Text = "";
            txtUsername.Text = "";
            txtRole.Text = "";
            txtPassword.Text = "";
            txtConfirmPWD.Text = "";
        }

        private void frmAddEditStaff_Load(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                lblTitle.Text = "Adding New Staff";
                ClearFields();
                GetStaffID();
            }
            else
            {
                lblTitle.Text = "Updating Staff";
                LoadUpdateStaff();

            }
        }

        private void txtRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
