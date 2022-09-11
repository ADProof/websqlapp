using websqlapp.Models;

namespace websqlapp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}