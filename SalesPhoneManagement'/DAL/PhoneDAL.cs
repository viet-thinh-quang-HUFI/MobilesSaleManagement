using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhoneDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();

        public List<PHONE> loadDaTaSP()
        {
            return db.PHONEs.Select(t => t).ToList();
        }
        public bool checkPhoneID(string id)
        {
            return db.PHONEs.Where(c => c.PhoneID.Equals(id)).Count() > 0;
        }
        public void themSanPham(PHONE id)
        {
            bool existSP = db.PHONEs.Where(k => k.PhoneID == id.PhoneID).Count() > 0;
            if (existSP)
            {
                throw new Exception("Sản phẩm này đã tồn tại");
            }
            else
            {
                PHONE newSP = new PHONE();
                newSP.PhoneID = id.PhoneID;
                newSP.PhoneName = id.PhoneName;
                newSP.MainImage = id.MainImage;
                newSP.ScreenTeachnology = id.ScreenTeachnology;
                newSP.PhysicalWidth = id.PhysicalWidth;
                newSP.PhysicalHeight = id.PhysicalHeight;
                newSP.ScreenDiagonal = id.ScreenDiagonal;
                newSP.Chip = id.Chip;
                newSP.OperatingSystem = id.OperatingSystem;
                newSP.Sim = id.Sim;
                newSP.Wifi = id.Wifi;
                newSP.Bluetooth = id.Bluetooth;
                newSP.BatteryCapacity = id.BatteryCapacity;
                newSP.TypeOfPin = id.TypeOfPin;
                newSP.BrandID = id.BrandID;
                db.PHONEs.InsertOnSubmit(newSP);
                db.SubmitChanges();
            }
        }
        public void xoaPhone(string id)
        {
            PHONE existSP = db.PHONEs.Where(k => k.PhoneID.Equals(id)).FirstOrDefault();
            if (existSP == null)
            {
                throw new Exception("Không có thông tin sản phẩm này!");
            }
            else
            {
                COMMENT cm = db.COMMENTs.Where(v => v.PhoneID.Equals(id)).FirstOrDefault();
                DETAILSPHONE dt = db.DETAILSPHONEs.Where(v => v.PhoneID.Equals(id)).FirstOrDefault();
                if (cm != null || dt != null)
                {
                    throw new Exception("Không thể xóa sản phẩm này!");
                }
                else
                {
                    db.PHONEs.DeleteOnSubmit(existSP);
                    db.SubmitChanges();
                }
            }
        }
    }
}
