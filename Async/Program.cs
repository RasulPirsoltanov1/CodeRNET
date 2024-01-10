using System.Diagnostics;

namespace Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var url = new Uri("https://randomuser.me/api?results=50");
            stopwatch.Stop();
            Console.WriteLine(DownloadContent(url));
            Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
        }
        static string DownloadContent(Uri uri)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(uri).GetAwaiter().GetResult();
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}