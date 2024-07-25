using Microsoft.AspNetCore.Mvc;
using PriceLists.WebApp.Models;

namespace PriceLists.WebApp.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger) => _logger = logger;

    /// <summary> Получить представление добавления нового товара в прайс-лист. </summary>
    public IActionResult Add(ProductAddViewModel model) => View(model);
}
