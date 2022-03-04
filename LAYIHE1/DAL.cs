using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAYIHE1
{
    class DAL
    {
        public static string GetConnectionString()
        {
            string constring = "Data Source=DESKTOP-THJMVC0\\SQLEXPRESS; Initial Catalog=DBnewsql; Integrated Security=true";
            return constring;
        }

    }
}
