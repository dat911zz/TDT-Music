using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TDT.IdentityCore.Utils;

namespace TDT.CAdmin.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RBACAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IEnumerable<Claim> _claims;
        private readonly IConfiguration _cfg;
        public RBACAttribute(IHttpContextAccessor httpContextAccessor, IConfiguration cfg)
        {
            
        }
        public void OnAuthorization(AuthorizationFilterContext fillterContext)
        {
            if (fillterContext != null)
            {
                Microsoft.Extensions.Primitives.StringValues authTokens;
                fillterContext.HttpContext.Request.Headers.TryGetValue("authToken", out authTokens);

                var _token = authTokens.FirstOrDefault();
                if (_token != null)
                {
                    if (SecurityHelper.IsValidToken(_cfg, _token))
                    {

                    }
                }
            }
        }
    }
}
