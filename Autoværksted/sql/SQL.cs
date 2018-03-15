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
        private static string ConnectionString = "Data Source=SKAB5-PC-07\\HOLD21011801P;initial Catalog=AutoVaerksted;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //Opretter kunde/bil
        public static void Create(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    //Åben forbindelse
                    con.Open();
                    //Lav en ny Kommando
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //Exectue kommando
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("Opretted!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl! : " + e.Message);
            }
        }

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
