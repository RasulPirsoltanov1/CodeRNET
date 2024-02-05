using Microsoft.AspNetCore.Http.Extensions;

namespace MiddlewareApp.Middleware
{
    public class RequestLoggingMiddleware
    {
        public RequestDelegate _next{ get; set; }

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            await Console.Out.WriteLineAsync($"Request: {context.Request.Body}");
            await _next(context);
            await Console.Out.WriteLineAsync($"Response: {context.Response.StatusCode}  Body: {context.Response.Body}");

        }
    }
}
