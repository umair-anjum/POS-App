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
	static class SQLConn
	{
		public static string ServerMySQL;
		public static string PortMySQL;
		public static string UserNameMySQL;
		public static string PwdMySQL;
		public static string DBNameMySQL;
		public static string sqL;
		public static DataSet ds = new DataSet();
		public static SqlCommand cmd;
		public static SqlDataReader dr;

        public static bool adding;
        public static bool updating;

        public static string strSearch = "";

		public static SqlDataAdapter da = new SqlDataAdapter();

		public static SqlConnection conn = new SqlConnection();
		public static void getData()
		{
			string AppName = Application.ProductName;

			try {
				DBNameMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_Name", "temp");
				ServerMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_IP", "temp");
				PortMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_Port", "temp");
				UserNameMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_User", "temp");
				PwdMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_Password", "temp");
			} catch {
				Interaction.MsgBox("System registry was not established, you can set/save " + "these settings by pressing F1", MsgBoxStyle.Information);
			}

		}

		public static void ConnDB()
		{
			conn.Close();
			try {
				conn.ConnectionString = @"Data Source=DESKTOP-I2HI38F\SQLEXPRESS;Initial Catalog=posisdb_cshar;Integrated Security=True";

				conn.Open();
			} catch  {
				Interaction.MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings");
			}

		}


		public static void DisconnMy()
		{
			conn.Close();
			conn.Dispose();

		}

		public static void SaveData()
		{
			string AppName = Application.ProductName;

			Interaction.SaveSetting(AppName, "DBSection", "DB_Name", DBNameMySQL);
			Interaction.SaveSetting(AppName, "DBSection", "DB_IP", ServerMySQL);
			Interaction.SaveSetting(AppName, "DBSection", "DB_Port", PortMySQL);
			Interaction.SaveSetting(AppName, "DBSection", "DB_User", UserNameMySQL);
			Interaction.SaveSetting(AppName, "DBSection", "DB_Password", PwdMySQL);

			Interaction.MsgBox("Database connection settings are saved.", MsgBoxStyle.Information);
		}



	}
}

