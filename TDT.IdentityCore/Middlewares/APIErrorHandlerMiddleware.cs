using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDT.IdentityCore.Models;

namespace TDT.IdentityCore.Middlewares
{
    public class APIErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public APIErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new ErrorDetails()
                {
                    StatusCode = response.StatusCode,
                    Message = error?.Message
                });
                await response.WriteAsync(result);
            }
        }
    }
}
