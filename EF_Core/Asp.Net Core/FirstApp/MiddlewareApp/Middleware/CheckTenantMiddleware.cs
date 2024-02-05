
namespace MiddlewareApp.Middleware
{
    public class CheckTenantMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.TryGetValue("Tenant-Id", out var tenanId) || string.IsNullOrWhiteSpace(tenanId))
            {
                context.Response.StatusCode = 404;
                Console.WriteLine("you are missing something like thenant id");
            }
            await Console.Out.WriteLineAsync($"CheckTenantMiddleware : {context.Request.Headers.ContainsKey("Tenant-Id")}  ||  {context.Request.Headers.ContainsKey("Tenant-Id")}");
            await Console.Out.WriteLineAsync(tenanId);  
            await next(context);
        }
    }
}
