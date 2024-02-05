namespace MiddlewareApp.Endpoints
{
    public static class Products
    {
        public static void AddProductRoutes(this WebApplication app)
        {
            app.MapGet("/test1", ()=>"asds");
        }
    }
}
