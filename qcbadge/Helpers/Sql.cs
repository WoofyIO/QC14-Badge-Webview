using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;

namespace qcbadge.Helpers
{
    public class Sql
    {
        private static string DataSource = Startup.dburi;
        private static string UserID = Startup.dbuser;
        private static string Password = Startup.dbpass;
        private static string db = Startup.dbname;
        private static string table = "qcbdage";

        public bool[] selectGlobalView()
        {
            bool[] rtn = new bool[50];

            return rtn;
        }

        public bool[] selectIndervidualView(int badgeid)
        {
            bool[] rtn = new bool[50];

            return rtn;
        }

    }
}
