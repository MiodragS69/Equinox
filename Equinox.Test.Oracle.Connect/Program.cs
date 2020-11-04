using System;
using Oracle.ManagedDataAccess.Client;

namespace Equinox.Test.Oracle.Connect
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder();
            builder.UserID = "OT";
            builder.Password = "Orcl1234";
            builder.DataSource = "localhost:1521/xe";            
            using(OracleConnection conn = new OracleConnection(builder.ConnectionString))
            {
                try
                { 
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                        Console.WriteLine($"Connected to Oracle");
                }
                catch(OracleException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch(Exception exc )
                {
                    Console.WriteLine(exc.Message);
                }

                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT FIRST_NAME, LAST_NAME FROM EMPLOYEES";
                OracleDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Console.WriteLine($"{dr["LAST_NAME"].ToString()}, {dr["FIRST_NAME"].ToString()}");
                }
            }
            Console.WriteLine("Press any key to exit ....");
            Console.ReadKey();
        }
    }
}
