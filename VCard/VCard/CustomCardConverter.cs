using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VCard.Models;

public class CustomCardConverter : Newtonsoft.Json.JsonConverter<Card>
{
    public override Card? ReadJson(JsonReader reader, Type objectType, Card existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        JObject jsonObject = JObject.Load(reader);

        Card card = new Card
        {
            Id = jsonObject["id"]["value"].Value<string>(),
            Firstname = jsonObject["name"]["first"].Value<string>(),
            Surname = jsonObject["name"]["last"].Value<string>(),
            Email = jsonObject["email"].Value<string>(),
            Phone = jsonObject["phone"].Value<string>(),
            Country = jsonObject["location"]["country"].Value<string>(),
            City = jsonObject["location"]["city"].Value<string>()
        };

        return card;
    }

    public override void WriteJson(JsonWriter writer, Card? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
