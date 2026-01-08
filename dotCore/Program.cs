using System.Web.Mvc;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        string message = "Bienvenue sur mon site !";
        return View((object)message);
    }
}

