using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SalesPhoneManagement_
{
    public partial class frmSanPham : Form
    {
        PhoneDAL phoneDAL = new PhoneDAL(); 
        BrandDAL brandDAL = new BrandDAL();
        CommentDAL commentDAL = new CommentDAL();
        DetailsPhoneDAL detailsPhoneDAL = new DetailsPhoneDAL();
        public frmSanPham()
        {
            InitializeComponent();
        }
        String[] loaipin = { "Li-Ion", "Li-Po" };
        private void loadData_SP()
        {
            dgvSanPham.DataSource = phoneDAL.loadDaTaSP();
            dgvSanPham.Columns["PhysicalHeight"].Visible = false;
            dgvSanPham.Columns["Brand"].Visible = false;
        }
        private void load_cbo_LoaiPin()
        {
            var data = loaipin.ToArray();
            cbLoaiPin.DataSource = data;
        }
        private void load_Cb_Hang()
        {
            cbHang.DataSource = brandDAL.loadDaTaHang();
            cbHang.DisplayMember = "BrandName";
            cbHang.ValueMember = "BrandID";
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadData_SP();
            load_Cb_Hang();
            load_cbo_LoaiPin();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvSanPham.CurrentRow.Cells["PhoneID"].Value.ToString();
            txtTen.Text = dgvSanPham.CurrentRow.Cells["PhoneName"].Value.ToString();
            txtAnh.Text = dgvSanPham.CurrentRow.Cells["MainImage"].Value.ToString();
            txtScreen.Text = dgvSanPham.CurrentRow.Cells["ScreenTeachnology"].Value.ToString();
            txtWidth.Text = dgvSanPham.CurrentRow.Cells["PhysicalWidth"].Value.ToString();
            txtHeight.Text = dgvSanPham.CurrentRow.Cells["PhysicalHeight"].Value.ToString();
            txtMCheo.Text = dgvSanPham.CurrentRow.Cells["ScreenDiagonal"].Value.ToString();
            txtHieuNang.Text = dgvSanPham.CurrentRow.Cells["Chip"].Value.ToString();
            txtHDH.Text = dgvSanPham.CurrentRow.Cells["OperatingSystem"].Value.ToString();
            txtSim.Text = dgvSanPham.CurrentRow.Cells["Sim"].Value.ToString();
            txtWF.Text = dgvSanPham.CurrentRow.Cells["Wifi"].Value.ToString();
            txtBLT.Text = dgvSanPham.CurrentRow.Cells["Bluetooth"].Value.ToString();
            txtDLPin.Text = dgvSanPham.CurrentRow.Cells["BatteryCapacity"].Value.ToString();
            cbLoaiPin.Text = dgvSanPham.CurrentRow.Cells["TypeOfPin"].Value.ToString();
            cbHang.Text = dgvSanPham.CurrentRow.Cells["BrandID"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "" || txtTen.Text == "" || txtAnh.Text == "" || txtScreen.Text=="" || txtWidth.Text==""|| txtHeight.Text==""|| txtMCheo.Text==""|| txtHieuNang.Text==""|| txtHDH.Text==""|| txtSim.Text=="" || txtWF.Text==""|| txtBLT.Text==""|| txtDLPin.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }
            String ma = txtMa.Text;
            bool existSP = phoneDAL.checkPhoneID(ma);
            if (existSP)
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại");
                return;
            }
            else
            {
                PHONE sp = new PHONE();
                sp.PhoneID = txtMa.Text;
                sp.PhoneName = txtTen.Text;
                sp.MainImage = txtAnh.Text;
                sp.ScreenTeachnology = txtScreen.Text;
                sp.PhysicalWidth = Int32.Parse(txtWidth.Text);
                sp.PhysicalHeight = Int32.Parse(txtHeight.Text);
                sp.ScreenDiagonal = Decimal.Parse(txtMCheo.Text);
                sp.Chip = txtHieuNang.Text;
                sp.OperatingSystem = txtHDH.Text;
                sp.Sim = txtSim.Text;
                sp.Wifi = txtWF.Text;
                sp.Bluetooth = txtBLT.Text;
                sp.BatteryCapacity = Int32.Parse(txtDLPin.Text);
                sp.TypeOfPin = cbLoaiPin.SelectedValue.ToString();
                sp.BrandID = cbHang.SelectedValue.ToString();
                phoneDAL.themSanPham(sp);
                loadData_SP();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool existSP = phoneDAL.checkPhoneID(txtMa.Text);
            if (!existSP)
            {
                MessageBox.Show("Không có thông tin sản phẩm này!");
                return;
            }
            else
            {
                bool sp = commentDAL.existsComment_PhoneID(txtMa.Text);
                bool sp1 = detailsPhoneDAL.existsDetail_PhoneID(txtMa.Text);  
                if (sp == true || sp1 ==true)
                {
                    MessageBox.Show("Không thể xóa sản phẩm này!");
                    return;
                }
                else
                {
                    phoneDAL.xoaPhone(txtMa.Text);
                    loadData_SP();
                }
            }
        }
    }
}
