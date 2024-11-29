using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Web.Areas.Admin.Controllers
{
    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
