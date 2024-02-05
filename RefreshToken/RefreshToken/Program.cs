using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Refresh token'ınız
        string refreshToken = "your_refresh_token";

        // OAuth 2.0 yetkilendirme sunucunuzun token endpoint URL'si
        string tokenEndpoint = "https://example.com/token";

        // OAuth 2.0 istemcisine ait kimlik bilgileri
        string clientId = "your_client_id";
        string clientSecret = "your_client_secret";

        // Yeni erişim jetonunu almak için refresh token'ı kullan
        string newAccessToken = await GetNewAccessToken(tokenEndpoint, clientId, clientSecret, refreshToken);

        Console.WriteLine($"Yeni Erişim Jetonu: {newAccessToken}");
    }

    static async Task<string> GetNewAccessToken(string tokenEndpoint, string clientId, string clientSecret, string refreshToken)
    {
        using (HttpClient client = new HttpClient())
        {
            // Token endpoint'e POST isteği yap
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            });

            var response = await client.PostAsync(tokenEndpoint, content);

            // Yanıtı oku ve yeni erişim jetonunu al
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Token Endpoint Yanıtı: {responseContent}");

            // JSON yanıtını işle
            // Bu örnekte basitçe JSON'dan "access_token" alanını çıkartıyoruz
            // Gerçek bir uygulamada daha güvenli ve kapsamlı bir JSON işleme yapılmalıdır
            // Newtonsoft.Json veya System.Text.Json gibi kütüphaneler kullanılabilir
            string newAccessToken = responseContent.Split('"')[3];
            return newAccessToken;
        }
    }
}
