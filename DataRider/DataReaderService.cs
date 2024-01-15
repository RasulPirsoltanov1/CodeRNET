using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataRider
{
    internal class DataReaderService : BackgroundService
    {
        public async Task StartAsync()
        {

            HttpClient client = new HttpClient();

            var data = await client.GetAsync(new Uri("https://ankitvijay.net/2021/02/22/a-poor-mans-scheduler-using-net-background-serivce/comment-page-1/"));
            await Console.Out.WriteLineAsync(data.Content.ReadAsStringAsync().Result.Length.ToString());
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await StartAsync();await Task.Delay(5000);
            }
            throw new NotImplementedException();
        }
    }
}
