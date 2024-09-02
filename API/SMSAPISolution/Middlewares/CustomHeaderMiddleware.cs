using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middlewares
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("LoginUserId"))
            {
                // Header value not found, return "Bad Request" response.
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Required 'LoginUserId' header is not found.");
                return;
            }

            // Checking value is empty or not
            var loginUser = context.Request.Headers["LoginUserId"];
            if(string.IsNullOrWhiteSpace(loginUser))
            {
                // Header value not found, return "Bad Request" response.
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("'LoginUserId' header value not found.");
                return;
            }

            // Passing call to Controller
            await _next(context);
        }
    }
}
