using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.IdentityCore.Filters
{
    public class SessionRequirementFilter : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionRequirementFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_httpContextAccessor.HttpContext!.Request.Headers["Authorization"].Any())
            {
                context.Result = new UnauthorizedObjectResult(string.Empty);
                return;
            }
        }
    }
}
