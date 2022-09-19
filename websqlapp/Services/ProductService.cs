using System.Data.SqlClient;
using System.Text.Json;
using websqlapp.Models;
//using System.Data.SqlClient;

namespace websqlapp.Services;

public class ProductService : IProductService
{
    private readonly IConfiguration _configuration;

    public ProductService(IConfiguration configuration)
    {
        _configuration=configuration;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
    }
    public async Task<List<Product>> GetProducts()
    {
        string? functionUrl = "https://stratexappfn.azurewebsites.net/api/GetProducts?code=vBWxZLR-5MgNSRiouCr7HkL4Xk7Zo_s_orGaumrsTd3NAzFuK1jFhQ==";

        using (HttpClient? client = new())
        {
            HttpResponseMessage? response = await client.GetAsync(functionUrl);

            string? content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Product>>(content);
        }
        /*
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
        */
    }
}
