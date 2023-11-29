using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPhoneManagement_
{
    public partial class frmBrand : Form
    {
        BrandDAL brandDAL = new BrandDAL();
        PhoneDAL phoneDAL = new PhoneDAL();
        int idCount = 9;
        public frmBrand()
        {
            InitializeComponent();
        }
        private void loadData_Hang()
        {
            dgvHang.DataSource = brandDAL.loadDaTaHang();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            loadData_Hang();
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvHang.CurrentRow.Cells["BrandID"].Value.ToString();
            txtTen.Text = dgvHang.CurrentRow.Cells["BrandName"].Value.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string productID = "BR" + idCount.ToString("D");
            idCount++;
            txtMa.Text = productID;
            if (txtMa.Text == "" || txtTen.Text == "" )
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }
            String ma = txtMa.Text;
            bool existHang = brandDAL.checkBrandID(ma);
            if (existHang)
            {
                MessageBox.Show("Mã hãng này đã tồn tại");
                return;
            }
            else
            {
                BRAND sp = new BRAND();
                sp.BrandID = txtMa.Text;
                sp.BrandName = txtTen.Text;
                brandDAL.themHang(sp);
                loadData_Hang();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool existHang = brandDAL.checkBrandID(txtMa.Text);
            if (!existHang)
            {
                MessageBox.Show("Không có thông tin hãng này!");
                return;
            }
            else
            {
                bool sp = phoneDAL.existsPhone_BrandID(txtMa.Text);
                if (sp == true)
                {
                    MessageBox.Show("Không thể xóa hãng này!");
                    return;
                }
                else
                {
                    brandDAL.xoaBrand(txtMa.Text);
                    loadData_Hang();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "" || txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }

            if (txtMa.Text == null)
            {
                MessageBox.Show("Bạn chưa nhập mã hãng!");
                return;
            }
            else
            {
                BRAND sp = new BRAND();
                sp.BrandID = txtMa.Text;
                sp.BrandName = txtTen.Text;
                brandDAL.suaBrand(sp);
                loadData_Hang();
            }
        }
    }
}
