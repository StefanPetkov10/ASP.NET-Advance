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

            return View();
        }


    }
}
