using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataRider
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<DataReaderService>();
    })
    .Build();
            await host.RunAsync();
        }
    }
}