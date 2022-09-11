using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using websqlapp.Models;
using websqlapp.Services;

namespace websqlapp.Pages;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    public List<Product>? Products;

    public IndexModel(IProductService productService)
    {
        _productService=productService;
    }
    public void OnGet()
    {
        Products = _productService.GetProducts();
    }
}