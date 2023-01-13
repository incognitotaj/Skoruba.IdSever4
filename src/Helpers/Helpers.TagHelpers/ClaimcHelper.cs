using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.TagHelpers
{
    public class ClaimcHelper
    {
        public static bool IsValid(HttpContext httpContext, string claimType, string claimValue)
        {
            //var accessToken = await _httpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            //httpContext.VerifyUserHasAnyAcceptedScope();
            return httpContext.User.HasClaim(c => c.Type == claimType && c.Value == claimValue);
        }
    }
}
