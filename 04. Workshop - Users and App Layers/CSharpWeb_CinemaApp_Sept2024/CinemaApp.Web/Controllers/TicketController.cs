using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.CinemaMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class TicketController : BaseController
    {
        public TicketController(IManagerService managerService)
            : base(managerService)
        {
        }
        [HttpPost]
        [Authorize]
        public IActionResult BuyTickets(AvailableTicketsViewModel viewModel)
        {
            // TODO: Implement logic for buying tickets by the user
            return View();
        }
    }
}
