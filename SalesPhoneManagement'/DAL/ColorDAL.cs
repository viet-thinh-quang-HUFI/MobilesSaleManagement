using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ColorDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();
        public List<COLOR> loadDaTaMau()
        {
            return db.COLORs.Select(t => t).ToList();
        }
    }
}
