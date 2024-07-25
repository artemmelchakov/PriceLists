using Microsoft.AspNetCore.Mvc;

namespace PriceLists.WebApp.Controllers;

public class PriceListController : Controller
{
    private readonly ILogger<PriceListController> _logger;

    public PriceListController(ILogger<PriceListController> logger) => _logger = logger;

    /// <summary> Получить представление со списком всех прайс-листов. </summary>
    public IActionResult GetAll() => View();

    /// <summary> Получить представление прайс-листа с информацией о его товарах. </summary>
    public IActionResult Get(uint id) => View(id);

    /// <summary> Получить представление создания нового прайс-листа. </summary>
    public IActionResult Add() => View();
}
