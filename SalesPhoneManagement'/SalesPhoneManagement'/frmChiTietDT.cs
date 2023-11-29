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
    public partial class frmChiTietDT : Form
    {
        DetailsPhoneDAL detail = new DetailsPhoneDAL();
        PhoneDAL phoneDAL = new PhoneDAL();
        ColorDAL colorDAL = new ColorDAL();
        CapicityDAL capicityDAL = new CapicityDAL();
        DetailsBillDAL detailsBill = new DetailsBillDAL();
        DetailSwareHousereCeiptDAL detailSware = new DetailSwareHousereCeiptDAL();
        int idCount = 80;
        public frmChiTietDT()
        {
            InitializeComponent();
        }
        private void loadData_DetailPhone()
        {
            dgvSanPham.DataSource = detail.loadDaTaDSP();
            dgvSanPham.Columns["CAPACITY"].Visible = false;
            dgvSanPham.Columns["COLOR"].Visible = false;
            dgvSanPham.Columns["PHONE"].Visible = false;
        }
        private void load_cbo_Phone()
        {
            cbMaPhone.DataSource = phoneDAL.loadDaTaSP();
            cbMaPhone.DisplayMember = "PhoneName";
            cbMaPhone.ValueMember = "PhoneID";
        }
        private void load_cbo_MaMau()
        {
            cbMaMau.DataSource = colorDAL.loadDaTaMau();
            cbMaMau.DisplayMember = "ColorName";
            cbMaMau.ValueMember = "ColorID";
        }
        private void load_cbo_MaDL()
        {
            cbMaDL.DataSource = capicityDAL.loadDaTaDL();
            cbMaDL.DisplayMember = "Capacity1";
            cbMaDL.ValueMember = "CapacityID";
        }
        private void frmChiTietDT_Load(object sender, EventArgs e)
        {
            loadData_DetailPhone();
            load_cbo_Phone();
            load_cbo_MaMau();
            load_cbo_MaDL();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (PHONE item in cbMaPhone.Items)
            {
                if (item.PhoneID == dgvSanPham.CurrentRow.Cells["PhoneID"].Value.ToString())
                {
                    cbMaPhone.Text = item.PhoneName;
                }
            }

            txtPhoneDetail.Text = dgvSanPham.CurrentRow.Cells["DetailsPhoneID"].Value.ToString();
            txtAnh.Text = dgvSanPham.CurrentRow.Cells["DetailImage"].Value.ToString();

            foreach (COLOR item in cbMaMau.Items)
            {
                if (item.ColorID == dgvSanPham.CurrentRow.Cells["ColorID"].Value.ToString())
                {
                    cbMaMau.Text = item.ColorName;
                }
            }

            txtGia.Text = dgvSanPham.CurrentRow.Cells["Price"].Value.ToString();
            txtSoLuong.Text = dgvSanPham.CurrentRow.Cells["Quantity"].Value.ToString();
            cbMaDL.Text = dgvSanPham.CurrentRow.Cells["CapacityID"].Value.ToString();
            foreach (CAPACITY item in cbMaDL.Items)
            {
                if (item.CapacityID == dgvSanPham.CurrentRow.Cells["CapacityID"].Value.ToString())
                {
                    cbMaDL.Text = item.Capacity1.ToString();
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmSanPham sp = new frmSanPham();
            sp.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string productID = "DP" + idCount.ToString("D");
            idCount++;
            txtPhoneDetail.Text = productID;
            if (txtPhoneDetail.Text == "" || cbMaPhone.Text == "" || txtAnh.Text == "" || cbMaMau.Text == "" || txtGia.Text == "" || txtSoLuong.Text == "" || cbMaDL.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }
            String ma = txtPhoneDetail.Text;
            bool existSP = detail.checkDetailPhoneID(ma);
            if (existSP)
            {
                MessageBox.Show("Mã chi tiết này đã tồn tại");
                return;
            }
            else
            {
                DETAILSPHONE sp = new DETAILSPHONE();
                sp.PhoneID = cbMaPhone.SelectedValue.ToString();
                sp.DetailsPhoneID = txtPhoneDetail.Text;
                sp.DetailImage = txtAnh.Text;
                sp.ColorID = cbMaMau.SelectedValue.ToString();
                sp.CapacityID = cbMaDL.SelectedValue.ToString();
                sp.Price = Int32.Parse(txtGia.Text);
                sp.Quantity = Int32.Parse(txtSoLuong.Text);
                detail.themChiTietSP(sp);
                loadData_DetailPhone();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool existSP = detail.checkDetailPhoneID(txtPhoneDetail.Text);
            if (!existSP)
            {
                MessageBox.Show("Không có thông tin chi tiết này!");
                return;
            }
            else
            {
                bool sp = detailsBill.existsDTBill_DTPhoneID(txtPhoneDetail.Text);
                bool sp1 = detailSware.existsDTSware_DTPhoneID(txtPhoneDetail.Text);
                if (sp == true || sp1 == true)
                {
                    MessageBox.Show("Không thể xóa chi tiết này!");
                    return;
                }
                else
                {
                    detail.xoaCTPhone(txtPhoneDetail.Text);
                    loadData_DetailPhone();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtPhoneDetail.Text == "" || cbMaPhone.Text == "" || txtAnh.Text == "" || cbMaMau.Text == "" || txtGia.Text == "" || txtSoLuong.Text == "" || cbMaDL.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }

            if (txtPhoneDetail.Text == null)
            {
                MessageBox.Show("Bạn chưa nhập mã chi tiết!");
                return;
            }
            else
            {
                DETAILSPHONE sp = new DETAILSPHONE();
                sp.PhoneID = cbMaPhone.SelectedValue.ToString();
                sp.DetailsPhoneID = txtPhoneDetail.Text;
                sp.DetailImage = txtAnh.Text;
                sp.ColorID = cbMaMau.SelectedValue.ToString();
                sp.CapacityID = cbMaDL.SelectedValue.ToString();
                sp.Price = Int32.Parse(txtGia.Text);
                sp.Quantity = Int32.Parse(txtSoLuong.Text);
                detail.suaCTPhone(sp);
                loadData_DetailPhone();
            }
        }
    }
}
