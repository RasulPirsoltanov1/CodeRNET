using Data.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        AppDbContext _appDbContext = new AppDbContext();
        public void Add(Category category)
        {
            try
            {
                _appDbContext.sqlConnection.Open();
                Console.WriteLine("_appDbContext.sqlConnection opened.");
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.CommandText = "INSERT INTO Categories(CategoryName,Description)VALUES(@p1,@p2);";
                // _appDbContext.sqlCommand.Parameters.AddWithValue("@p1", category.CategoryName);
                // _appDbContext.sqlCommand.Parameters.AddWithValue("p2", category.Description);
                _appDbContext.sqlCommand.Parameters.Add("@p1", sqlDbType: System.Data.SqlDbType.NVarChar).Value = category.CategoryName;
                _appDbContext.sqlCommand.Parameters.Add("@p2", sqlDbType: System.Data.SqlDbType.Text).Value = category.Description;
                Console.WriteLine($"{_appDbContext.sqlCommand.ExecuteNonQuery()} setir elave edildi.");
                //crud
                _appDbContext.sqlConnection.Close();

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
                _appDbContext.sqlCommand.CommandText = "DELETE FROM Categories WHERE CategoryId=@p1";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.Parameters.Add("p1", System.Data.SqlDbType.Int).Value = id;
                Console.WriteLine($"{_appDbContext.sqlCommand.ExecuteNonQuery()} row deleted successfully.");
                _appDbContext.sqlConnection.Close();

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

        public Category Get(int id)
        {
            var category = new Category();
            try
            {
                _appDbContext.sqlConnection.Open();

                _appDbContext.sqlCommand.CommandText = "SELECT CategoryId,CategoryName,Description FROM Categories WHERE CategoryId=@p";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.Parameters.Add("@p", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader sqlDataReader = _appDbContext.sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    category.CategoryId = sqlDataReader.GetInt32(0);
                    category.CategoryName = sqlDataReader.GetString(1);
                    category.Description = sqlDataReader.GetString(2);
                }
                _appDbContext.sqlConnection.Close();

                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
                return new Category();
            }
        }

        public List<Category> GetAll()
        {
            try
            {
                _appDbContext.sqlConnection.Open();
                Console.WriteLine("_appDbContext.sqlConnection opened.");
                List<Category> categories = new List<Category>();

                //crud
                _appDbContext.sqlCommand.CommandText = "SELECT CategoryId,CategoryName,Description FROM Categories";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                SqlDataReader sqlDataReader = _appDbContext.sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    categories.Add(new Category()
                    {

                        CategoryId = Convert.ToInt32(sqlDataReader[0]),
                        CategoryName = sqlDataReader[1].ToString() ?? "",
                        Description = sqlDataReader[2].ToString() ?? ""
                    });

                }
                _appDbContext.sqlConnection.Close();

                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
                return null;
            }
        }

        public void Update(Category category)
        {
            try
            {
                _appDbContext.sqlConnection.Open();
                Console.WriteLine("_appDbContext.sqlConnection opened.");


                //crud
                _appDbContext.sqlCommand.CommandText = "UPDATE Categories SET CategoryName=@p22,Description=@p13 WHERE CategoryId=@p12";
                _appDbContext.sqlCommand.Connection = _appDbContext.sqlConnection;
                _appDbContext.sqlCommand.Parameters.Add("p12", System.Data.SqlDbType.Int).Value = category.CategoryId;
                _appDbContext.sqlCommand.Parameters.Add("p22", System.Data.SqlDbType.NVarChar).Value = category.CategoryName;
                _appDbContext.sqlCommand.Parameters.Add("p13", System.Data.SqlDbType.Text).Value = category.Description;
                Console.WriteLine($"{_appDbContext.sqlCommand.ExecuteNonQuery()} row updated successfully.");
                _appDbContext.sqlConnection.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }
    }
}