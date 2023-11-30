using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetailsBillDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();
        public bool existsDTBill_DTPhoneID(string id)
        {
            bool exists = db.DETAILSBILLs.Where(v => v.DetailsPhoneID.Equals(id)).Count() > 0;
            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
