using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CapicityDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();

        public List<CAPACITY> loadDaTaDL()
        {
            return db.CAPACITies.Select(t => t).ToList();
        }
    }
}
