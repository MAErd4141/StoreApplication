using Microsoft.AspNetCore.Mvc;
using Entities.Models; 

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Simple product list in English
        var products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Computer", Price = 1700, ImageUrl = "/images/default.jpg" },
            new Product { ProductId = 2, ProductName = "Keyboard", Price = 50, ImageUrl = "/images/keyboard.jpg" },
            new Product { ProductId = 3, ProductName = "Mouse", Price = 20, ImageUrl = "/images/mouse.jpg" },
            new Product { ProductId = 4, ProductName = "Hamlet", Price = 15, ImageUrl = "/images/hamlet.jpg" },
        };

        return View(products);
    }
}
