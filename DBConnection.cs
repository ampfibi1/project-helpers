/*using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ConsoleDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                                      "(CONNECT_DATA=(SERVICE_NAME=XE)));" +
                                      "User Id=test;Password=test;";


            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select user_name from test where password='1234'";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();

            Console.WriteLine($"user name is : {dr.GetString(0)}");

            Console.ReadKey();
        }
    }
}
*/
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ConsoleDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                                      "(CONNECT_DATA=(SERVICE_NAME=XE)));" +
                                      "User Id=test;Password=test;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    //string username = "john_doe";
                    //string password = "1234";

                    string insertQuery = "INSERT INTO test (user_name, password) VALUES (:username, :password)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        //cmd.Parameters.Add(new OracleParameter("username", username));
                        //cmd.Parameters.Add(new OracleParameter("password", password));

                        int rowsInserted = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rowsInserted} row(s) inserted.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.ReadKey();
            }
        }
    }
}
/*
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ConsoleDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                                      "(CONNECT_DATA=(SERVICE_NAME=XE)));" +
                                      "User Id=test;Password=test;";

            OracleConnection conn = new OracleConnection(connectionString);
            conn.Open();

            string query = "insert into test (user_name, password) values ('johnny_doe', '1234')";
            OracleCommand cmd = new OracleCommand(query,conn);
           

            int rowsAffected = cmd.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) inserted.");

            Console.ReadKey();
        }
    }
}
*/
