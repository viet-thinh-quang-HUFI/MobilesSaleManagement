using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
