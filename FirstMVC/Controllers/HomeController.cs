using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVC.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Product> products = new();
        
        Product product1 = new();
        product1.Name = "Apple";
        product1.Description = "A fruit";
        product1.Price = 0.99m;
        product1.Quantity = 5;

        products.Add(product1);

        Product product2 = new()
        {
            Name = "Banana",
            Description = "A fruit",
            Price = 1.29m,
            Quantity = 3
        };

        products.Add(product2);


        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
