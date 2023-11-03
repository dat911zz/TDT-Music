using Google.Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

namespace TDT.IdentityCore.Middlewares
{
    public class RBACMiddleware
    {
        private readonly RequestDelegate _next;
        public RBACMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IConfiguration cfg, ISecurityHelper securityHelper)
        {
            if (context.User.Claims.Count() > 0)
            {
                var time = long.Parse(context.User.FindFirstValue("exp"));
                if (DateTimeOffset.FromUnixTimeSeconds(time).UtcDateTime <= DateTime.UtcNow || SecurityHelper.permDic.Count == 0)
                {
                    SecurityHelper.permDic.Clear();
                    await context.SignOutAsync();
                }
            }
            
            await _next(context);
        }
        
    }
}
