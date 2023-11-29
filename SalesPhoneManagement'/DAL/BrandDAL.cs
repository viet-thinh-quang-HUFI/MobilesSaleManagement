using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BrandDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();
        public List<BRAND> loadDaTaHang()
        {
            return db.BRANDs.Select(t => t).ToList();
        }
        public bool checkBrandID(string id)
        {
            return db.BRANDs.Where(c => c.BrandID.Equals(id)).Count() > 0;
        }
        public void themHang(BRAND id)
        {
            bool existHang = db.BRANDs.Where(k => k.BrandID == id.BrandID).Count() > 0;
            if (existHang)
            {
                throw new Exception("Hãng này đã tồn tại");
            }
            else
            {
                BRAND newHang = new BRAND();
                newHang.BrandID = id.BrandID;
                newHang.BrandName = id.BrandName;
                db.BRANDs.InsertOnSubmit(newHang);
                db.SubmitChanges();
            }
        }
        public void suaBrand(BRAND brand)
        {
            BRAND pn = db.BRANDs.FirstOrDefault(k => k.BrandID == brand.BrandID);
            if (pn == null)
            {
                throw new Exception("Không có thông tin hãng này!");
            }
            else
            {
                pn.BrandName = brand.BrandName;
                db.SubmitChanges();
            }
        }
        public void xoaBrand(string id)
        {
            BRAND existHang = db.BRANDs.Where(k => k.BrandID.Equals(id)).FirstOrDefault();
            if (existHang == null)
            {
                throw new Exception("Không có thông tin hãng này!");
            }
            else
            {
                PHONE cm = db.PHONEs.Where(v => v.BrandID.Equals(id)).FirstOrDefault();
                if (cm != null)
                {
                    throw new Exception("Không thể xóa hãng này!");
                }
                else
                {
                    db.BRANDs.DeleteOnSubmit(existHang);
                    db.SubmitChanges();
                }
            }
        }
    }
}
