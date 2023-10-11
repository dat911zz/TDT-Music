using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.DTO;
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
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userName = securityHelper.ValidateToken(token);
            if (userName != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = APICallHelper.Get<ResponseDataDTO<User>>($"user/{userName}", token: token).Result;
            }

            await _next(context);
        }
    }
}
