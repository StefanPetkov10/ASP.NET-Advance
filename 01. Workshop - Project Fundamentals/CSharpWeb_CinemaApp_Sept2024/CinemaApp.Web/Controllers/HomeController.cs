using Microsoft.AspNetCore.Mvc; // Internal project namespace

namespace CinemaApp.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            // Two ways of transmitting data from Controller to View
            // 1. Using ViewBag/ViewData
            // 2. Pass ViewModel to the View

            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to the Cinema Web App!";
            return View();
        }


    }
}
