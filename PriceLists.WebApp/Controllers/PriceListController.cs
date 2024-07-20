using Microsoft.AspNetCore.Mvc;
using PriceLists.Data;

namespace PriceLists.WebApp.Controllers;

public class PriceListController : Controller
{
    private readonly ILogger<PriceListController> _logger;
    private readonly IRepository _repository;

    public PriceListController(ILogger<PriceListController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public IActionResult GetAll() => View();
}
