using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class TicketApiController : ControllerBase
    {

    }
}
