using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPhoneManagement_
{
    public partial class frmLogin : Form
    {
        EmployeeDAL employee = new EmployeeDAL();

        public static string isadmin;
        public frmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            tbAccountName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbAccountName.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu!");
                return;
            }
            else
            {
                if (employee.kiemTraDangNhap(tbAccountName.Text, tbPassword.Text))
                {
                    frmLoading f = new frmLoading();
                    f.Show();
                    this.Hide();
                    if(employee.TimChucVuTheoMaNhanVien(tbAccountName.Text)!=null)
                    {
                        isadmin = employee.TimChucVuTheoMaNhanVien(tbAccountName.Text);
                    }    
                    
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                    return;
                }
            }
        }
    }
}
