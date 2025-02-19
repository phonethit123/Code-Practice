using System;
using System.Data;
using System.Security.Cryptography;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace DatabaseView
{
    class Program
    {

        public static string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Novdb;User ID=admin;password=root123";
        public static void Main(string[] args)
        {
            string back = "Back";
             SelectDb:
            var db_list = ShowAllDatabases();
            int number = 1;
            foreach (var db in db_list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{number}.{db.PadRight(30)}");
                

                if (number % 3 == 0)
                {
                    Console.WriteLine();
                }
                number++;
            }
            Console.Write($"{number}.{back.PadRight(30)}");
            Console.ResetColor();
            Console.WriteLine("\nEnter database number:");
            int index_db = int.Parse(Console.ReadLine());
            string selecteddb = string.Empty;
            if (index_db > 0 && index_db <= db_list.Count)
            {
                selecteddb = db_list[index_db - 1];
            }
            else if (index_db == db_list.Count+1)
            {
                goto SelectDb;
            }
            else
            {
                Console.WriteLine("Enter correct number");
            }
            Selecttabels:
            Console.WriteLine($"This are the tables in {selecteddb} database ");
            var table_list = ShowAllTables(selecteddb);
            number=1;
            foreach (var table in table_list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{number}.{table.PadRight(30)}");
                

                if (number % 3 == 0)
                {
                    Console.WriteLine();
                }
                number++;
            }
            Console.Write($"{number}.{back.PadRight(30)}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Enter the table number you want to select all");
            int index_tabel = int.Parse(Console.ReadLine());
            string selectedtabel = string.Empty;
            if (index_tabel > 0 && index_tabel <= table_list.Count)
            {
                selectedtabel = table_list[index_tabel - 1];
            }
            else if (index_db == table_list.Count + 1)
            {
                goto Selecttabels;
            }
            else
            {
                Console.WriteLine("Enter correct number");
            }
            Read(selectedtabel,selecteddb);
            Console.WriteLine("Do you want to Try again Y/N?");
            string res = Console.ReadLine();
            if(res =="Y")
            {
                goto SelectDb;
            }


        }

        public static List<string> ShowAllDatabases()
        {
            List<string> db = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT name FROM sys.databases";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    db.Add(dr[0].ToString());
                }

            }
            return db;
        }
        static List<string> ShowAllTables(string dbName)
        {
            List<string> tabels = new List<string>();
            string _connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog={dbName};User ID=admin;password=root123";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT name FROM sys.tables";

                SqlCommand command = new SqlCommand(query,connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        tabels.Add(reader[0].ToString());

                    }
                    return tabels; 
                }
            }
        }
        static void Read(string tabel_name,string dbName)
            {
               string _connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog={dbName};User ID=admin;password=root123";
                using (SqlConnection connection = new SqlConnection(_connectionString)) 
                {
                    string query = $"Select * from {tabel_name}";
                    SqlCommand command = new SqlCommand(query,connection);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt) ;
                    foreach (DataRow dr in dt.Rows)
                    {
                        foreach (var item in dr.ItemArray)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(item);
                            Console.ResetColor();
                        }
                    
                    }

                }

            }

       

    }


}
