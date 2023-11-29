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
    public partial class frmKhachHang : Form
    {
        CustomerDAL customer = new CustomerDAL();
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
    }
}
