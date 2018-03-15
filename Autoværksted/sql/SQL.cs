using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Autoværksted
{
    public class SQL
    {
        private static string ConnectionString = "Data Source= SKAB5-PC-07\\HOLD21011801P:initialCatalog=AutoVaerksted; Integrated Security=True; ConectTimeout=50; Encrypt=False; TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFallover=false";

        //public static void insert(string sql)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //public static DataTable Select(string sql)
        //{
        //    //string sql = string.Format("select bil.* from bil where regnr = '{0}'", regnr)

        //    DataTable table = new DataTable();
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        con.Open();
        //        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
        //        adapter.Fill(table);
        //    }
        //    return table;
        //}

    }
}
