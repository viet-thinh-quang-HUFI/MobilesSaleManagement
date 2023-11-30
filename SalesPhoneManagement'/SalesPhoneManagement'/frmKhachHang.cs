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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesPhoneManagement_
{
    public partial class frmKhachHang : Form
    {
        CustomerDAL customer = new CustomerDAL();
        AddressofcustomerDAL addressofcustomerDAL = new AddressofcustomerDAL();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void loadData_KH()
        {
            dgvKH.DataSource = customer.loadDaTaKH();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loadData_KH();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmail.Text = dgvKH.CurrentRow.Cells["Email"].Value.ToString();
            txtTen.Text = dgvKH.CurrentRow.Cells["CustomerName"].Value.ToString();
            txtPassword.Text = dgvKH.CurrentRow.Cells["Password"].Value.ToString();
            txtSDT.Text = dgvKH.CurrentRow.Cells["PhoneNO"].Value.ToString();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" || txtTen.Text != "" || txtSDT.Text != "")
            {
                if (rdoEmail.Checked)
                {
                    dgvKH.DataSource = customer.timKH_Email(txtEmail.Text);
                }
                if (rdoTen.Checked)
                {
                    dgvKH.DataSource = customer.timKH_Ten(txtTen.Text);
                }
                if(rdoSDT.Checked)
                {
                    dgvKH.DataSource = customer.timKH_SDT(txtSDT.Text);
                }
            }
            else
            {
                loadData_KH();
            }
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtTen.Text == "" || txtPassword.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }
            String ma = txtEmail.Text;
            bool existSP = customer.checkEmail(ma);
            if (existSP)
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại");
                return;
            }
            else
            {
                CUSTOMER sp = new CUSTOMER();
                sp.Email = txtEmail.Text;
                sp.CustomerName = txtTen.Text;
                sp.Password = txtPassword.Text;
                sp.PhoneNO = txtSDT.Text;
                customer.themKH(sp);
                loadData_KH();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtTen.Text == "" || txtPassword.Text==""||txtSDT.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }

            if (txtEmail.Text == null)
            {
                MessageBox.Show("Bạn chưa nhập email!");
                return;
            }
            else
            {
                CUSTOMER sp = new CUSTOMER();
                sp.Email = txtEmail.Text;
                sp.CustomerName = txtTen.Text;
                sp.Password = txtPassword.Text;
                sp.PhoneNO = txtSDT.Text;
                customer.suaKH(sp);
                loadData_KH();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool existKH = customer.checkEmail(txtEmail.Text);
            if (!existKH)
            {
                MessageBox.Show("Không có thông tin khách hàng này!");
                return;
            }
            else
            {
                bool sp = addressofcustomerDAL.existsAddress_Email(txtEmail.Text);
                if (sp == true)
                {
                    MessageBox.Show("Không thể xóa khách hàng này!");
                    return;
                }
                else
                {
                    customer.xoaKH(txtEmail.Text);
                    loadData_KH();
                }
            }
        }
    }
}
