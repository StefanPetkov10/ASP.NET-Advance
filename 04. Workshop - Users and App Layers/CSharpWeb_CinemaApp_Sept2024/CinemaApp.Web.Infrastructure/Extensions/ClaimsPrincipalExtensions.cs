﻿using System.Security.Claims;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUserId(this ClaimsPrincipal userClaimsPrincipal)
            => userClaimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;
    }
}
