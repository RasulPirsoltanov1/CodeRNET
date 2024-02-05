using System.Data;
using System.Data.SqlClient;

namespace AdoNet2
{
    internal class Program
    {
        const string connectionString = "Data Source=(local);Initial Catalog=Northwind; Integrated Security=true";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new(connectionString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand("SELECT CategoryId,CategoryName,Description FROM Categories;SELECT * FROM Shippers;", sqlConnection);
            DataTable dataTable = new DataTable();
            DataSet dataSet = new();
            sqlDataAdapter.Fill(dataTable);

            sqlDataAdapter.Fill(dataSet);
            foreach (DataRow item in dataTable.Rows)
            {
                Console.WriteLine($"CategoryId : {item["CategoryID"]}");
                Console.WriteLine($"CategoryName : {item["CategoryName"]}");
                Console.WriteLine($"Description : {item["Description"]}");
            }
            Console.WriteLine("----------------------------Data set-----------------------------");
            foreach (DataRow item in dataSet.Tables[0].Rows)
            {
                Console.WriteLine($"CategoryId : {item["CategoryID"]}");
                Console.WriteLine($"CategoryName : {item["CategoryName"]}");
                Console.WriteLine($"Description : {item["Description"]}");
            }

            Console.WriteLine("----------------------------Data set 2-----------------------------");
            foreach (DataRow item in dataSet.Tables[1].Rows)
            {
                Console.WriteLine($"ShipperID : {item["ShipperID"]}");
                Console.WriteLine($"CompanyName : {item["CompanyName"]}");
                Console.WriteLine($"Phone : {item["Phone"]}");
            }
            InsertData(new Category
            {
                CategoryName = "Inser test",
                Description = "test insert"
            });
            UpdateData(new Category
            {
                CategoryId= 2033,
                CategoryName = "Update test",
                Description = "test Update"
            });
        }
        public static void InsertData(Category category)
        {
            SqlConnection connection = new(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = new SqlCommand("INsert Into Categories(CategoryName,Description)Values(@p0,@p1)", connection);
            dataAdapter.InsertCommand.Parameters.Add("p0", SqlDbType.NVarChar).Value = category.CategoryName;
            dataAdapter.InsertCommand.Parameters.Add("p1", SqlDbType.NText).Value = category.Description;
            connection.Open();
            var count = dataAdapter.InsertCommand.ExecuteNonQuery();
            Console.WriteLine($"{count} eded setir elave edildi.");
            connection.Close();
        }

        public static void UpdateData(Category category)
        {
            SqlConnection connection = new(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = new SqlCommand("Update Categories SET CategoryName=@p0,Description=@p1 WHERE CategoryId=@p3;", connection);
            dataAdapter.InsertCommand.Parameters.Add("p0", SqlDbType.NVarChar).Value = category.CategoryName;
            dataAdapter.InsertCommand.Parameters.Add("p1", SqlDbType.NText).Value = category.Description;
            dataAdapter.InsertCommand.Parameters.Add("p3", SqlDbType.Int).Value = category.CategoryId;
            connection.Open();
            var count = dataAdapter.InsertCommand.ExecuteNonQuery();
            Console.WriteLine($"{count} eded setir update edildi.");
            connection.Close();
        }

        public static void MultipleTransaction()
        {



        }
    }
}
