namespace MiddlewareApp.Middleware
{
    public static class MiddlewareConfigureExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
        public static IApplicationBuilder CheckTenant(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckTenantMiddleware>();
        }

    }
}
