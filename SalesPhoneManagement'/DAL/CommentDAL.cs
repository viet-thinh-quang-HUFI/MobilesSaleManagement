using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentDAL
    {
        SalesPhoneManagementDataContext db = new SalesPhoneManagementDataContext();
        public bool existsComment_PhoneID(string id)
        {
            bool exists = db.COMMENTs.Where(v => v.PhoneID.Equals(id)).Count() > 0;
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
