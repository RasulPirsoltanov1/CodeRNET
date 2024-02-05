using Carter;
using MiddlewareApp.Endpoints;
using MinimalApiExample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddCarter();



var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.MapPost("/", () => "Hello World!");
//app.AddProductRoutes();
app.MapCarter();
app.Run();

