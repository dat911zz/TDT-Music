using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Api;
using System.Net;
using System.Net.Http;
using System.Threading;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

namespace TDT.IdentityCore.AuthHandler
{

    public class DVNAuthorizationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //if (!context.HttpContext.Request.Path.Value.Contains("Error"))
            //{
            //    bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
            //                     .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));
            //    bool hasClaims = context.HttpContext.User.Claims.Count() > 0;

            //    if (hasAllowAnonymous && !hasClaims) return;

            //    var request = context.HttpContext.Request;
            //    if (request.RouteValues.Count > 0)
            //    {
            //        var currentUser = context.HttpContext.User.Identity.Name;
            //        string controller = request.RouteValues["controller"].ToString();
            //        string action = request.RouteValues["action"].ToString();
            //        string targetPerm = controller + "Controller" + "_" + action;

            //        //var curPerms = resRole.Data;

            //        if (!SecurityHelper.permDic.ContainsKey(targetPerm) && SecurityHelper.permDic.Count > 0)
            //        {
            //            context.HttpContext.Response.Redirect("/Home/Error?statusCode=401");
            //        }
            //    }
            //}
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        
    }
}
