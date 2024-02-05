using MiddlewareApp.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CheckTenantMiddleware>();
var app = builder.Build();
//app.UseRequestLogging();
app.UseMiddleware<CheckTenantMiddleware>();
app.MapGet("/", () => "Hello World!");

app.Run();
