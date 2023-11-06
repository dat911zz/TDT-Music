using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TDT.IdentityCore.Models;

namespace TDT.IdentityCore.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            var _logger = _loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
            try
            {
                await _next(context);
                switch (context.Response.StatusCode)
                {
                    case 400:
                        HandlerError(context, "Có lỗi xảy ra!");
                        break;
                    case 401:
                        HandlerError(context, "Chưa xác mình danh tính, vui lòng đăng nhập!");
                        break;
                    case 403:
                        HandlerError(context, "Không đủ quyền hạn truy cập tài nguyên!");
                        break;
                    case 404:
                        HandlerError(context, "Không tìm thấy trang này!");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception error)
            {
                var response = context.Response;

                switch (error)
                {
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                _logger.LogError($"Exception: {error.Message}\n{error.StackTrace}");
                HandlerError(
                    context, 
                    error.Message
                    );
            }
        }
        private void HandlerError(HttpContext context, string msg)
        {
            context.Response.Redirect($"/Home/Error/?statusCode={context.Response.StatusCode}&msg={msg}");
        }
    }
}
