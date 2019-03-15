using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dao
{
    public class DapperHelper
    {
        private static string conn_str = ConfigurationManager.ConnectionStrings["conn"].ToString();
        public static SqlConnection Conn
        {
            get
            {
                return new SqlConnection(conn_str);
            }
        }
        
    }
}
