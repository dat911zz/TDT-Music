using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetToken(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(c => c.Type.Equals("token"))?.Value ?? "";
        }
        public static string GetValue(this ClaimsPrincipal principal, string key)
        {
            return principal.Claims.FirstOrDefault(c => c.Type.Equals(key))?.Value ?? "";
        }
    }
}
