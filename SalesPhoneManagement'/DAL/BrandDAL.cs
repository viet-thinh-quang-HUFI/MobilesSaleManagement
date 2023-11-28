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
    }
}
