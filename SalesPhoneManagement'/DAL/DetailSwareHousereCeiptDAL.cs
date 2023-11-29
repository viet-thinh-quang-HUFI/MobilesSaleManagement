using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetailSwareHousereCeiptDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();
        public bool existsDTSware_DTPhoneID(string id)
        {
            bool exists = db.DETAILSWAREHOUSERECEIPTs.Where(v => v.DetailsPhoneID.Equals(id)).Count() > 0;
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
