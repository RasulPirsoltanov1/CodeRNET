using FirstApp.Settings;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

string message= app.Configuration["Message"];
CurrentApplication currentApplication = app.Configuration.GetSection("CurrentApplication").Get<CurrentApplication>();

app.MapGet("/", () => $"Hello {message}! {currentApplication.Url}");

app.MapGet("/html", () => Results.Extensions.Html(@$"<!doctype html>
<html>
    <head><title>{message}</title></head>
    <body>
        <h1>Hello World</h1>
        <p>The time on the server is {DateTime.Now:O}</p>
    </body>
</html>"));

app.Run();
