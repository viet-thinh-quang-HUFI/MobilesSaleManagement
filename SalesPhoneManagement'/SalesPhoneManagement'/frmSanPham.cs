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
        int idCount = 15;
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void loadData_SP()
        {
            dgvSanPham.DataSource = phoneDAL.loadDaTaSP();
            dgvSanPham.Columns["PhysicalHeight"].Visible = false;
            dgvSanPham.Columns["Brand"].Visible = false;
        }

        public void load_cbo_CongNghe()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<string>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.ScreenTeachnology);
            }

            cbScreen.Items.Clear();

            foreach (string uniqueItem in uniqueValues)
            {
                cbScreen.Items.Add(uniqueItem);
            }

        }
        public void load_cbo_HieuNang()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<string>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.Chip);
            }

            cbHieuNang.Items.Clear();

            foreach (string uniqueItem in uniqueValues)
            {
                cbHieuNang.Items.Add(uniqueItem);
            }

        }
        public void load_cbo_Sim()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<string>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.Sim);
            }

            cbSim.Items.Clear();

            foreach (string uniqueItem in uniqueValues)
            {
                cbSim.Items.Add(uniqueItem);
            }

        }
        private void load_cbo_LoaiPin()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<string>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.TypeOfPin);
            }

            cbLoaiPin.Items.Clear();

            foreach (string uniqueItem in uniqueValues)
            {
                cbLoaiPin.Items.Add(uniqueItem);
            }
        }
        private void load_cbo_HDH()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<string>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.OperatingSystem);
            }

            cbHDH.Items.Clear();

            foreach (string uniqueItem in uniqueValues)
            {
                cbHDH.Items.Add(uniqueItem);
            }
        }
        private void load_cbo_KT()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<decimal>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.ScreenDiagonal.Value);
            }

            cbMCheo.Items.Clear();

            foreach (decimal uniqueItem in uniqueValues)
            {
                cbMCheo.Items.Add(uniqueItem);
            }
        }
        private void load_cbo_WF()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<string>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.Wifi);
            }

            cbWF.Items.Clear();

            foreach (string uniqueItem in uniqueValues)
            {
                cbWF.Items.Add(uniqueItem);
            }
        }
        private void load_cbo_BLT()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<string>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.Bluetooth);
            }

            cbBLT.Items.Clear();

            foreach (string uniqueItem in uniqueValues)
            {
                cbBLT.Items.Add(uniqueItem);
            }
        }
        private void load_cbo_DLP()
        {
            var originalData = phoneDAL.loadDaTaSP();
            var uniqueValues = new HashSet<int>();
            foreach (var item in originalData)
            {
                uniqueValues.Add(item.BatteryCapacity.Value);
            }

            cbDLPin.Items.Clear();

            foreach (int uniqueItem in uniqueValues)
            {
                cbDLPin.Items.Add(uniqueItem);
            }
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
            load_cbo_CongNghe();
            load_cbo_HieuNang();
            load_cbo_Sim();
            load_cbo_HDH();
            load_cbo_KT();
            load_cbo_DLP();
            load_cbo_WF();
            load_cbo_BLT();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvSanPham.CurrentRow.Cells["PhoneID"].Value.ToString();
            txtTen.Text = dgvSanPham.CurrentRow.Cells["PhoneName"].Value.ToString();
            txtAnh.Text = dgvSanPham.CurrentRow.Cells["MainImage"].Value.ToString();
            cbScreen.Text = dgvSanPham.CurrentRow.Cells["ScreenTeachnology"].Value.ToString();
            txtWidth.Text = dgvSanPham.CurrentRow.Cells["PhysicalWidth"].Value.ToString();
            txtHeight.Text = dgvSanPham.CurrentRow.Cells["PhysicalHeight"].Value.ToString();
            cbMCheo.Text = dgvSanPham.CurrentRow.Cells["ScreenDiagonal"].Value.ToString();
            cbHieuNang.Text = dgvSanPham.CurrentRow.Cells["Chip"].Value.ToString();
            cbHDH.Text = dgvSanPham.CurrentRow.Cells["OperatingSystem"].Value.ToString();
            cbSim.Text = dgvSanPham.CurrentRow.Cells["Sim"].Value.ToString();
            cbWF.Text = dgvSanPham.CurrentRow.Cells["Wifi"].Value.ToString();
            cbBLT.Text = dgvSanPham.CurrentRow.Cells["Bluetooth"].Value.ToString();
            cbDLPin.Text = dgvSanPham.CurrentRow.Cells["BatteryCapacity"].Value.ToString();
            cbLoaiPin.Text = dgvSanPham.CurrentRow.Cells["TypeOfPin"].Value.ToString();
            foreach (BRAND item in cbHang.Items)
            {
                if (item.BrandID == dgvSanPham.CurrentRow.Cells["BrandID"].Value.ToString())
                {
                    cbHang.Text = item.BrandName;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string productID = "PH" + idCount.ToString("D");
            idCount++;
            txtMa.Text = productID;
            if (txtMa.Text == "" || txtTen.Text == "" || txtAnh.Text == "" || cbScreen.Text=="" || txtWidth.Text==""|| txtHeight.Text==""|| cbMCheo.Text==""|| cbHieuNang.Text==""|| cbHDH.Text==""|| cbSim.Text=="" || cbWF.Text==""|| cbBLT.Text==""|| cbDLPin.Text=="")
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
                sp.ScreenTeachnology = cbScreen.Text;
                sp.PhysicalWidth = Int32.Parse(txtWidth.Text);
                sp.PhysicalHeight = Int32.Parse(txtHeight.Text);
                sp.ScreenDiagonal = Decimal.Parse(cbMCheo.Text);
                sp.Chip = cbHieuNang.Text;
                sp.OperatingSystem = cbHDH.Text;
                sp.Sim = cbSim.Text;
                sp.Wifi = cbWF.Text;
                sp.Bluetooth = cbBLT.Text;
                sp.BatteryCapacity = Int32.Parse(cbDLPin.Text);
                sp.TypeOfPin = cbLoaiPin.Text;
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

        private void cbHang_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmBrand hang = new frmBrand();
            hang.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "" || txtTen.Text == "" || txtAnh.Text == "" || cbScreen.Text == "" || txtWidth.Text == "" || txtHeight.Text == "" || cbMCheo.Text == "" || cbHieuNang.Text == "" || cbHDH.Text == "" || cbSim.Text == "" || cbWF.Text == "" || cbBLT.Text == "" || cbDLPin.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }

            if (txtMa.Text == null)
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm!");
                return;
            }
            else
            {
                PHONE sp = new PHONE();
                sp.PhoneID = txtMa.Text;
                sp.PhoneName = txtTen.Text;
                sp.MainImage = txtAnh.Text;
                sp.ScreenTeachnology = cbScreen.Text;
                sp.PhysicalWidth = Int32.Parse(txtWidth.Text);
                sp.PhysicalHeight = Int32.Parse(txtHeight.Text);
                sp.ScreenDiagonal = Decimal.Parse(cbMCheo.Text);
                sp.Chip = cbHieuNang.Text;
                sp.OperatingSystem = cbHDH.Text;
                sp.Sim = cbSim.Text;
                sp.Wifi = cbWF.Text;
                sp.Bluetooth = cbBLT.Text;
                sp.BatteryCapacity = Int32.Parse(cbDLPin.Text);
                sp.TypeOfPin = cbLoaiPin.Text;
                sp.BrandID = cbHang.SelectedValue.ToString();
                phoneDAL.suaPhone(sp);
                loadData_SP();
            }
        }
    }
}
