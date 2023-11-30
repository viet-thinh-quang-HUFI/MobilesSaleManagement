using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();

        public List<EMPLOYEE> loadDaTaNV()
        {
            return db.EMPLOYEEs.Select(t => t).ToList();
        }
        public bool kiemTraDangNhap(string tk, string mk)
        {
            var DN = db.EMPLOYEEs.Where(nv => nv.EmployeeID == tk && nv.Password == mk).Select(nv => nv);

            if (DN.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string TimChucVuTheoMaNhanVien(string id)
        {
          
            List<EMPLOYEE> danhSachNhanVien = loadDaTaNV();
            var chucVu = (from nv in danhSachNhanVien
                          where nv.EmployeeID == id
                          select nv.ChucVu).FirstOrDefault();

            return chucVu != null ? chucVu : "Không tìm thấy chức vụ";
        }
    }
}
