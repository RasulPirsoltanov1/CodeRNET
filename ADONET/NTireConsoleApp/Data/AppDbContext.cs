using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext
    {
        public SqlConnection sqlConnection {  get; set; }
        public SqlCommand sqlCommand{  get; set; }
        const string con_string = "Server=DESKTOP-NG2G057;Database=Northwind;Trusted_Connection=True;";
        public AppDbContext()
        {
            sqlConnection = new SqlConnection(con_string);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }
        public SqlConnection SqlConnection()
        {
              SqlConnection sqlConnection=new SqlConnection(con_string);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
