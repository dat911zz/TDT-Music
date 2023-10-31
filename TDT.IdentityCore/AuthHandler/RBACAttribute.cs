using Google.Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
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
        public string? Claims { get; set; }
        public RBACAttribute()
        {
            
        }
        public RBACAttribute(string claims)
        {
            Claims = claims;       
        }
        public async void OnAuthorization(AuthorizationFilterContext fillterContext)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = fillterContext.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;
            if (fillterContext != null)
            {
                if (fillterContext.HttpContext.User.Claims.Count() > 0)
                {
                    var time = long.Parse(fillterContext.HttpContext.User.FindFirstValue("exp"));
                    if (DateTimeOffset.FromUnixTimeSeconds(time).UtcDateTime <= DateTime.UtcNow)
                    {
                        await fillterContext.HttpContext.SignOutAsync();
                    }
                }
                string actionName = fillterContext.RouteData.Values["action"].ToString();
                string controllerName = fillterContext.RouteData.Values["controller"].ToString();

                // authorization
                //var user = (User)context.HttpContext.Items["User"];
                //if (user == null)
                //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
