using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCProjet.Models;

namespace MVCProjet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult MAdepense()
    {
        return View();
    }

    public IActionResult MAdepenseForm(Depense model)
    {
        return RedirectToAction("Index");
    }

    public IActionResult Depense()
    {
        return View();
    }
    public IActionResult Afficher()
    {
        return View();
    }

    public IActionResult Suprimer()
    {
        return View();
    }
    public IActionResult Ajouter()
    {
        return View();
    }

    public IActionResult Depense()
    {
        return View();
    }

    public IActionResult VerifierStockFaible()
    {
        return View();
    }

    public IActionResult Chercher()
    {
        return View();
    }

    public IActionResult VerifierStockFaible()
    {
        return View();
    }

    public IActionResult AfficherStatistique()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
