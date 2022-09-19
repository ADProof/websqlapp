using websqlapp.Models;

namespace websqlapp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}