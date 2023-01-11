using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Common.Core.Helpers
{
    public static class ClaimsHelpers
    {
        public static bool IsInRole(string claimType, string claimValue)
        {
            //var result = User.HasClaim(p => p.Type == "role" && p.Value.Contains("admin"));

            return false;
        }
    }
}
