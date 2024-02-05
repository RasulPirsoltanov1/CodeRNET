using Data.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext _appDbContext = new AppDbContext();
        public void Add(Product product)
        {
            try
            {
                _appDbContext.sqlConnection.Open();
                Console.WriteLine("_appDbContext.sqlConnection opened.");
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.CommandText = "INSERT INTO Products(ProductName,Description)VALUES(@p1,@p2);";
                // _appDbContext.sqlCommand.Parameters.AddWithValue("@p1", product.ProductName);
                // _appDbContext.sqlCommand.Parameters.AddWithValue("p2", product.Description);
                _appDbContext.sqlCommand.Parameters.Add("@p1", sqlDbType: System.Data.SqlDbType.NVarChar).Value = product.ProductName;
                Console.WriteLine($"{_appDbContext.sqlCommand.ExecuteNonQuery()} setir elave edildi.");
                //crud
                _appDbContext.sqlConnection.Close();
                _appDbContext.sqlCommand.Dispose();
                Console.WriteLine("_appDbContext.sqlConnection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _appDbContext.sqlConnection.Open();

                _appDbContext.sqlCommand.CommandText = "DELETE FROM Products WHERE ProductId=@p1";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.Parameters.Add("p1", System.Data.SqlDbType.Int).Value = id;
                Console.WriteLine($"{_appDbContext.sqlCommand.ExecuteNonQuery()} row deleted successfully.");
                _appDbContext.sqlConnection.Close();
                _appDbContext.sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }

        public void Dispose()
        {
            _appDbContext.sqlConnection.Dispose();
        }

        public Product Get(int id)
        {
            var product = new Product();
            try
            {
                _appDbContext.sqlConnection.Open();

                _appDbContext.sqlCommand.CommandText = "SELECT ProductId,ProductName,Description FROM Products WHERE ProductId=@p1";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.Parameters.Add("p1", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader sqlDataReader = _appDbContext.sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    product.ProductID = sqlDataReader.GetInt32(0);
                    product.ProductName = sqlDataReader.GetString(1);
                    product.UnitPrice = sqlDataReader.GetInt32(2);
                }
                _appDbContext.sqlConnection.Close();
                _appDbContext.sqlCommand.Dispose();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
                return new Product();
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                _appDbContext.sqlConnection.Open();
                Console.WriteLine("_appDbContext.sqlConnection opened.");
                List<Product> categories = new List<Product>();

                //crud
                _appDbContext.sqlCommand.CommandText = "SELECT ProductId,ProductName,UnitPrice FROM Products";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                SqlDataReader sqlDataReader = _appDbContext.sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    categories.Add(new Product()
                    {

                        ProductID = Convert.ToInt32(sqlDataReader[0]),
                        ProductName = sqlDataReader[1].ToString() ?? "",
                        UnitPrice = sqlDataReader.GetDecimal(2)
                });

                }
                _appDbContext.SqlConnection().Close();
                _appDbContext.sqlCommand.Dispose();
                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
                return null;
            }
        }

        public void Update(Product product)
        {
            try
            {
                _appDbContext.sqlConnection.Open();
                Console.WriteLine("_appDbContext.sqlConnection opened.");


                //crud
                _appDbContext.sqlCommand.CommandText = "UPDATE Products SET ProductName=@p2,UnitPrice=@p3 WHERE ProductID=@p1";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.Parameters.Add("p1", System.Data.SqlDbType.Int).Value = product.ProductID;
                _appDbContext.sqlCommand.Parameters.Add("p2", System.Data.SqlDbType.NVarChar).Value = product.ProductName;
                _appDbContext.sqlCommand.Parameters.Add("p3", System.Data.SqlDbType.Decimal).Value = product.UnitPrice;
                Console.WriteLine($"{_appDbContext.sqlCommand.ExecuteNonQuery()} row updated successfully.");

                _appDbContext.sqlConnection.Close();
                _appDbContext.sqlCommand.Dispose();
                Console.WriteLine("_appDbContext.sqlConnection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }
    }
}
