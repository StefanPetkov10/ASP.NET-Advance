using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IManagerService managerService;

        public BaseController(IManagerService managerService)
        {
            this.managerService = managerService;
        }

        protected bool IsGuidIdValid(string? id, ref Guid parsedGuidId)
        {
            // Non-existing parameter in the URL
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuidId);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }

        protected async Task<bool> IsUserManagerAsync()
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.managerService.IsUserManagerAsync(userId);

            return isUserManager;
        }

        protected async Task AppendUserCookieAsync()
        {
            bool isManager = await this.IsUserManagerAsync();
            this.HttpContext.Response.Cookies.Append(IsManagerCookieName, isManager.ToString());
        }
    }
}
