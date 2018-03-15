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
                    //Laver en ny Kommando
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //Execute kommando
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
        public static void Read(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Åben forbindelse
                con.Open();
                //Laver en ny Kommando
                SqlCommand command = new SqlCommand(sql, con);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine("\n" + reader.GetValue(i));
                        }
                    }
                }
            }
        }
    }
}
