using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();
        public List<CUSTOMER> loadDaTaKH()
        {
            return db.CUSTOMERs.Select(t => t).ToList();
        }
        public IEnumerable<dynamic> timKH_Email(string email)
        {
            return db.CUSTOMERs.Where(t => t.Email.StartsWith(email) || t.Email.Equals(email))
                    .Select(t => new
                    {
                        Email = t.Email,
                        CustomerName = t.CustomerName,
                        Password = t.Password,
                        PhoneNO = t.PhoneNO
                    });
        }
        public IEnumerable<dynamic> timKH_Ten(string ten)
        {
            return db.CUSTOMERs.Where(t => t.CustomerName.StartsWith(ten) || t.CustomerName.Equals(ten))
                    .Select(t => new
                    {
                        Email = t.Email,
                        CustomerName = t.CustomerName,
                        Password = t.Password,
                        PhoneNO = t.PhoneNO
                    });
        }
        public IEnumerable<dynamic> timKH_SDT(string sdt)
        {
            return db.CUSTOMERs.Where(t => t.PhoneNO.StartsWith(sdt) || t.PhoneNO.Equals(sdt))
                     .Select(t => new
                    {
                        Email = t.Email,
                        CustomerName = t.CustomerName,
                        Password = t.Password,
                        PhoneNO = t.PhoneNO
                    });
        }
        public bool checkEmail(string email)
        {
            return db.CUSTOMERs.Where(c => c.Email.Equals(email)).Count() > 0;
        }
        public void themKH(CUSTOMER email)
        {
            bool exist = db.CUSTOMERs.Where(k => k.Email == email.Email).Count() > 0;
            if (exist)
            {
                throw new Exception("Khách hàng này đã tồn tại");
            }
            else
            {
                CUSTOMER newSP = new CUSTOMER();
                newSP.Email = email.Email;
                newSP.CustomerName = email.CustomerName;
                newSP.Password = email.Password;
                newSP.PhoneNO = email.PhoneNO;
                db.CUSTOMERs.InsertOnSubmit(newSP);
                db.SubmitChanges();
            }
        }
        public void suaKH(CUSTOMER customer)
        {
            CUSTOMER pn = db.CUSTOMERs.FirstOrDefault(k => k.Email == customer.Email);
            if (pn == null)
            {
                throw new Exception("Không có thông tin khách hàng này!");
            }
            else
            {
                pn.Email = customer.Email;
                pn.CustomerName = customer.CustomerName;
                pn.Password = customer.Password;
                pn.PhoneNO = customer.PhoneNO;
                db.SubmitChanges();
            }
        }
        public void xoaKH(string email)
        {
            CUSTOMER existSP = db.CUSTOMERs.Where(k => k.Email.Equals(email)).FirstOrDefault();
            if (existSP == null)
            {
                throw new Exception("Không có thông tin khách hàng này!");
            }
            else
            {
                ADDRESSOFCUSTOMER cm = db.ADDRESSOFCUSTOMERs.Where(v => v.Email.Equals(email)).FirstOrDefault();
                if (cm != null)
                {
                    throw new Exception("Không thể xóa khách hàng này!");
                }
                else
                {
                    db.CUSTOMERs.DeleteOnSubmit(existSP);
                    db.SubmitChanges();
                }
            }
        }
    }
}
