using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch5_day1
{
    public class AdoDotNetExample
    {
        string _connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Batch5;User ID=admin;password=root123";
        public void Read()
        {
           
            SqlConnection connection = new SqlConnection(_connectionstring);
            string query = @"Select * from Tbl_blog";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
           
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["Id"]);
                Console.WriteLine(dr["Author"]);
                Console.WriteLine(dr["Title"]);
            }
        }
        public void Create()
        {
            Console.WriteLine("Enter Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Author:");
            string author = Console.ReadLine();

            Console.WriteLine("Enter Article:");
            string article = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();
            string query_intert = @"INSERT INTO [dbo].[Tbl_blog]
                                           ([Title]
                                           ,[Author]
                                           ,[Article]
                                           ,[Delete_Flag])
                                     VALUES
                                           (@title
                                           ,@author
                                           ,@article
                                           ,0)";
            SqlCommand command = new SqlCommand(query_intert, connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@article",article);
            
            var res= command.ExecuteNonQuery();
            Console.WriteLine(res); 

        }

        public void Update()
        {
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Author:");
            string author = Console.ReadLine();

            Console.WriteLine("Enter Article:");
            string article = Console.ReadLine();




            SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();
            string query_intert = @"UPDATE [dbo].[Tbl_blog]
                                       SET [Title] = @Title
                                          ,[Author] = @Author
                                          ,[Article] = @Article
                                          
                                     WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query_intert, connection);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Author", author);
            command.Parameters.AddWithValue("@Article", article);
            command.Parameters.AddWithValue("@Id", id);
            var res = command.ExecuteNonQuery();
            Console.WriteLine(res);
        }

        public void Delete()
        {
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection( _connectionstring);
            connection.Open();

            string query_delete = @"Delete from [dbo].[Tbl_blog] where Id=@Id ";

            SqlCommand cmd = new SqlCommand(query_delete, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            var res = cmd.ExecuteNonQuery();
            Console.WriteLine(res);

            
            

        }
    }
}
