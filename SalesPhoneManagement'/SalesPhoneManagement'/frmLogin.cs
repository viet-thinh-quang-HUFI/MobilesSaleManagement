using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPhoneManagement_
{
    public partial class frmLogin : Form
    {
        SqlConnection conn;
        public static string serverName = @"LAPTOP-QNEC04QL\VIET";
        public static string databaseName = "SalesPhoneManagement";
        public static string empId = "";
        public static string password = "";

        public frmLogin()
        {
            InitializeComponent();
            conn = new SqlConnection();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            empId = tbAccountName.Text;
            password = tbPassword.Text;
            string strConn = @"Data Source= " + serverName + "; " +
                "Initial Catalog = " + databaseName + ";" +
                "User ID = " + empId + "; " +
                "Password = " + password;

            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                frmLoading f = new frmLoading();
                f.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại");
            }
            finally { conn.Close(); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
