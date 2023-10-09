using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TDT.CAdmin.Filters
{
    public class RBACAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IEnumerable<Claim> _claims;
        public RBACAttribute(IHttpContextAccessor httpContextAccessor)
        {
            _claims = httpContextAccessor.HttpContext.User.Claims;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context != null)
            {
                
            }
        }
    }
}
