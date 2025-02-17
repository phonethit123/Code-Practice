using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch5_day1
{
    public  class DapperExample
    {
        private readonly string _connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Batch5;User ID=admin;password=root123";
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_connectionstring))
            {
                string query = "SELECT * FROM tbl_blog where DeleteFlag = 0";
                var lst = db.Query(query);
            }
        }
    }
}
