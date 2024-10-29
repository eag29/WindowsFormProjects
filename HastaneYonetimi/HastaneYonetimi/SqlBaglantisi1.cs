using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneYonetimi
{
    class SqlBaglantisi1
    {
        public SqlConnection Connection()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-TMVO8N4\\SQLEXPRESS;Initial Catalog=HastaneProje;Integrated Security=True;");
            connect.Open();
            return connect;

        }
    }
}
