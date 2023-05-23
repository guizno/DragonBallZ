using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dragonballz.Models;
using Dragonballz.Services;

namespace Dragonballz.Controllers;

public class HomeController : Controller
{
     private readonly ILogger<HomeController> _logger;
     private readonly IDragonService _dragonService;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _dragonService = dragonService;
    }

    public IActionResult Index(string especie)
    {
        var especies = _dragonService.GetDragonballzDto();
        ViewData["filter"] = string.IsNullOrEmpty(especie) ? "all" : especie;
        return View(especie);
    }

    public IActionResult Details(int Numero)
    {
        var guerreiro = _dragonService.GetDetailedGuerreiro(Numero);
        return View(guerreiro);
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
