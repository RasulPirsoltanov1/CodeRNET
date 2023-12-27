using System;
using System.Formats.Asn1;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VCard.Models;
using System.Net;
using System.Reflection.Metadata;
using System.Net.Http.Json;

class Program
{
    private const string URL = "https://randomuser.me/api?results=50&authuser=0";

    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(URL);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<Card> cards = GetCards(responseBody);
        foreach (var item in cards)
        {
            Console.WriteLine(item.GetVCard()+"\n\n");
            item.SaveVCard(item.GetVCard(),item.Id);
        }
    }

    public static List<Card> GetCards(string content)
    {
        try
        {
            List<Card> cards = new List<Card>();
            string jsonCard = string.Empty;

            JObject jsonObject = JObject.Parse(content);

            if (jsonObject.TryGetValue("results", out JToken resultsToken) && resultsToken is JArray resultsArray)
            {
                foreach (JObject result in resultsArray.Children<JObject>())
                {
                    foreach (JProperty singleProp in result.Properties())
                    {
                        string name = singleProp.Name;
                        string value = singleProp.Value.ToString();
                        //Console.WriteLine($"{name}: {value}");
                    }
                    jsonCard = result.ToString();
                    var settings = new JsonSerializerSettings
                    {
                        Converters = { new CustomCardConverter() }
                    };

                    Card card = JsonConvert.DeserializeObject<Card>(jsonCard, settings);
                    cards.Add(card);
                }
                return cards;
            }
            else
            {
                return new List<Card>();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"No 'results' array found in the JSON. {ex.Message}");
        }
    }

}
