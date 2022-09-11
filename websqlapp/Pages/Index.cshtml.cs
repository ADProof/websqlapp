using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using websqlapp.Models;
using websqlapp.Services;

namespace websqlapp.Pages;

public class IndexModel : PageModel
{
    public List<Product>? Products;
    public void OnGet()
    {
        ProductService productService = new();
        Products = productService.GetProducts();
    }
}