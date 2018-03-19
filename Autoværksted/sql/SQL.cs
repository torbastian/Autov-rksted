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
                    int oprettet = cmd.ExecuteNonQuery();

                    Console.WriteLine("Oprettet!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl! : " + e.Message);
            }
        }
        public static void Read(string sql)
        {
            try
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
                                if (i < (reader.FieldCount - 1))
                                    Console.Write(string.Format("{0}, ", reader.GetValue(i)));
                                else
                                {
                                    Console.Write(reader.GetValue(i));
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl! : " + e.Message);
            }
        }

        public static void Delete(string sql)
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
                    int slettet = cmd.ExecuteNonQuery();

                    if (slettet > 0)
                        Console.WriteLine("Slettet!");
                    else
                        Console.WriteLine("Ikke fundet!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl! : " + e.Message);
            }
        }

        public static void Update(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    //Åben forbindelse
                    con.Open();
                    //Lav en ny kommando
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //Execute kommando
                    int updated = cmd.ExecuteNonQuery();

                    if (updated > 0)
                        Console.WriteLine("Opdateret!");
                    else
                        Console.WriteLine("Ikke fundet!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl! : " + e.Message);
            }
        }
    }
}
