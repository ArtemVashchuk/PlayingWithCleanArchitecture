﻿using System.Security.Claims;

namespace Bookify.Infrastructure.Authentication
{
    internal static class ClaimsPrincipleExtensions
    {
        public static string GetIdentityId(this ClaimsPrincipal? principal)
        {
            return principal?.FindFirstValue(ClaimTypes.NameIdentifier) ??
                   throw new ApplicationException("User identity is unavailable");
        }
    }
}
