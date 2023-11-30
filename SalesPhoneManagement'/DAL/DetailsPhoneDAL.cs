using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetailsPhoneDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();
        public bool existsDetail_PhoneID(string id)
        {
            bool exists = db.DETAILSPHONEs.Where(v => v.PhoneID.Equals(id)).Count() > 0;
            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<DETAILSPHONE> loadDaTaDSP()
        {
            return db.DETAILSPHONEs.Select(t => t).ToList();
        }
        public bool checkDetailPhoneID(string id)
        {
            return db.DETAILSPHONEs.Where(c => c.DetailsPhoneID.Equals(id)).Count() > 0;
        }
        public void themChiTietSP(DETAILSPHONE id)
        {
            bool exist = db.DETAILSPHONEs.Where(k => k.DetailsPhoneID == id.DetailsPhoneID).Count() > 0;
            if (exist)
            {
                throw new Exception("Chi tiết này đã tồn tại");
            }
            else
            {
                DETAILSPHONE newSP = new DETAILSPHONE();
                newSP.PhoneID = id.PhoneID;
                newSP.DetailsPhoneID = id.DetailsPhoneID;
                newSP.ColorID = id.ColorID;
                newSP.CapacityID = id.CapacityID;
                newSP.Price = id.Price;
                newSP.DetailImage = id.DetailImage;
                newSP.Quantity = id.Quantity;
                db.DETAILSPHONEs.InsertOnSubmit(newSP);
                db.SubmitChanges();
            }
        }
        public void xoaCTPhone(string id)
        {
            DETAILSPHONE existSP = db.DETAILSPHONEs.Where(k => k.DetailsPhoneID.Equals(id)).FirstOrDefault();
            if (existSP == null)
            {
                throw new Exception("Không có thông tin chi tiết này!");
            }
            else
            {
                DETAILSBILL cm = db.DETAILSBILLs.Where(v => v.DetailsPhoneID.Equals(id)).FirstOrDefault();
                DETAILSWAREHOUSERECEIPT dt = db.DETAILSWAREHOUSERECEIPTs.Where(v => v.DetailsPhoneID.Equals(id)).FirstOrDefault();
                if (cm != null || dt != null)
                {
                    throw new Exception("Không thể xóa chi tiết này!");
                }
                else
                {
                    db.DETAILSPHONEs.DeleteOnSubmit(existSP);
                    db.SubmitChanges();
                }
            }
        }
        public void suaCTPhone(DETAILSPHONE phone)
        {
            DETAILSPHONE pn = db.DETAILSPHONEs.FirstOrDefault(k => k.DetailsPhoneID == phone.DetailsPhoneID);
            if (pn == null)
            {
                throw new Exception("Không có thông tin chi tiết này!");
            }
            else
            {
                pn.PhoneID = phone.PhoneID;
                pn.DetailsPhoneID = phone.DetailsPhoneID;
                pn.ColorID = phone.ColorID;
                pn.CapacityID = phone.CapacityID;
                pn.Price = phone.Price;
                pn.DetailImage = phone.DetailImage;
                pn.Quantity = phone.Quantity;
                db.SubmitChanges();
            }
        }
    }
}
