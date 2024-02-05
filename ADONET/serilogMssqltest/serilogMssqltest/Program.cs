using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.SystemConsole.Themes;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

try
{
    // Logger konfigurasiyasını yarat
    Logger loggerConfiguration = new LoggerConfiguration()
        .ReadFrom.Configuration(new ConfigurationBuilder()
            .AddJsonFile("appsettings.serilog-configs.json")
            .Build())
        // loglari Db yə yazmaq ucun "Serilog.Sinks.MSSqlServer" paketini yuklemek lazimdir
        .WriteTo.MSSqlServer(connectionString: "Data Source=DESKTOP-NG2G057;Initial Catalog=SerilogExampleDB;Integrated Security=True ;TrustServerCertificate=True", tableName: "mylogs", autoCreateSqlTable: true, restrictedToMinimumLevel: LogEventLevel.Information)
        .Enrich.FromLogContext()
        .CreateLogger();
    
    // Mövcud loglama providerlerini təmizləyirik
    builder.Logging.ClearProviders();

    // Serilog'u loglama provideri kimi əlavə et
    builder.Logging.AddSerilog(loggerConfiguration);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
