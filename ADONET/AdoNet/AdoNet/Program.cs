using AdoNet.Models;
using System;
using System.Data.SqlClient;

static class Program
{
    const string connectionString = "Data Source=(local);Initial Catalog=Northwind; Integrated Security=true";
    static void Main()
    {
        //CheckConnection();
        //AddCategory(new Category()
        //{
        //    CategoryName = "Test",
        //    Description = "lorem ipsum dolor sit amet",
        //});

        //UpdateCategory(new Category()
        //{
        //    CategoryId=2009,
        //    CategoryName="Test updated",
        //    Description=" updated this."
        //});
        //DeleteCategory(2009);

        //GetCategory(1);
        foreach (var item in GetCategories())
        {
            Console.WriteLine(item.CategoryName);
        }
    }

    public static void CheckConnection()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("connection opened.");

                connection.Close();
                Console.WriteLine("connection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }

    }
    public static void AddCategory(Category category)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("connection opened.");

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Categories(CategoryName,Description)VALUES(@p1,@p2);";
                    //command.Parameters.AddWithValue("@p1", category.CategoryName);
                    //command.Parameters.AddWithValue("p2", category.Description);
                    command.Parameters.Add("@p1", sqlDbType: System.Data.SqlDbType.NVarChar).Value = category.CategoryName;

                    command.Parameters.Add("@p2", sqlDbType: System.Data.SqlDbType.Text).Value = category.Description;
                    Console.WriteLine($"{command.ExecuteNonQuery()} setir elave edildi.");
                }
                //crud
                connection.Close();
                Console.WriteLine("connection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }
    }
    public static void DeleteCategory(int Id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("connection opened.");


                //crud
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Categories WHERE CategoryId=@p1";
                    command.Connection = connection;
                    command.Parameters.Add("p1", System.Data.SqlDbType.Int).Value = Id;
                    Console.WriteLine($"{command.ExecuteNonQuery()} row deleted successfully.");
                }


                connection.Close();
                Console.WriteLine("connection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }
    }
    public static void UpdateCategory(Category category)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("connection opened.");


                //crud
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "UPDATE Categories SET CategoryName=@p2,Description=@p3 WHERE CategoryId=@p1";
                    command.Connection = connection;
                    command.Parameters.Add("p1", System.Data.SqlDbType.Int).Value = category.CategoryId;
                    command.Parameters.Add("p2", System.Data.SqlDbType.NVarChar).Value = category.CategoryName;
                    command.Parameters.Add("p3", System.Data.SqlDbType.Text).Value = category.Description;
                    Console.WriteLine($"{command.ExecuteNonQuery()} row updated successfully.");
                }


                connection.Close();
                Console.WriteLine("connection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }
    }
    public static void GetCategory(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("connection opened.");


                //crud
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT CategoryId,CategoryName,Description FROM Categories WHERE CategoryId=@p1";
                    command.Connection = connection;
                    command.Parameters.Add("p1", System.Data.SqlDbType.Int).Value = id;
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(@$"id :{sqlDataReader[0]}
                                                Name :{sqlDataReader[1]}
                                                Desc :{sqlDataReader[2]}");



                        Console.WriteLine(@$"id :{sqlDataReader["CategoryId"]}
                                                Name :{sqlDataReader["CategoryName"]}
                                                Desc :{sqlDataReader["Description"]}");
                    }
                }


                connection.Close();
                Console.WriteLine("connection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
            }
        }
    }
    public static List<Category> GetCategories()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("connection opened.");
                List<Category> categories = new List<Category>();

                //crud
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT CategoryId,CategoryName,Description FROM Categories";
                    command.Connection = connection;
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        categories.Add(new Category()
                        {

                            CategoryId = Convert.ToInt32(sqlDataReader[0]),
                            CategoryName = sqlDataReader[1].ToString() ?? "",
                            Description = sqlDataReader[2].ToString() ?? ""
                        });
                        //Console.WriteLine(@$"id :{sqlDataReader[0]}
                        //                        Name :{sqlDataReader[1]}
                        //                        Desc :{sqlDataReader[2]}" );



                        //Console.WriteLine(@$"id :{sqlDataReader["CategoryId"]}
                        //                        Name :{sqlDataReader["CategoryName"]}
                        //                        Desc :{sqlDataReader["Description"]}" );
                    }
                    return categories;
                }


                connection.Close();
                Console.WriteLine("connection Closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("message:" + ex.Message);
                return null;
            }
        }
    }
}