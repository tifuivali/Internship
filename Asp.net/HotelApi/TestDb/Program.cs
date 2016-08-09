using System;
using System.Data.SqlClient;

namespace TestDb
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source =IASI-H5BP4G7;Initial Catalog=Bookings;User ID=sa;Password=1234%asd");
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Hotels",conn);
                reader = cmd.ExecuteReader();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i)} | ");
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]} || ");
                    }
                    Console.WriteLine();
                }
               

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.ReadKey();
        }
    }
}
