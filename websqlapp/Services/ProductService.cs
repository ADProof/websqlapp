using System.Data.SqlClient;
using websqlapp.Models;
//using System.Data.SqlClient;

namespace websqlapp.Services;

public class ProductService
{
    public static string db_server { get; set; } = "stratexserver.database.windows.net";
    public static string db_user { get; set; } = "stratexadmin";
    public static string db_password { get; set; } = "Atrain@2022!";
    public static string db_catalog { get; set; } = "stratexdb";

    private SqlConnection GetConnection()
    {
        var _builder = new SqlConnectionStringBuilder();
        _builder.DataSource = db_server;
        _builder.UserID = db_user;
        _builder.Password = db_password;
        _builder.InitialCatalog = db_catalog;
        return new SqlConnection(_builder.ConnectionString);
    }
    public List<Product> GetProducts()
    {
        SqlConnection conn = GetConnection();
        List<Product> _products = new List<Product>();
        string statement = "SELECT ProductId, ProductName, Quantity FROM Products";

        conn.Open();

        SqlCommand cmd = new SqlCommand(statement, conn);

        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Product product = new Product()
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                };

                _products.Add(product);

            }
        }
        conn.Close();
        return _products;
    }
}
