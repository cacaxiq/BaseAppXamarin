using Newtonsoft.Json;

namespace BaseApp.Infrastructure.Json
{
    public class JsonHelper<T> where T : class
    {
        public static string ObjectToJson(T ObjectToConvert)
        {
            JsonSerializerSettings _jsonWriter = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Encoding.UTF8 = "application/json"
            };

            return JsonConvert.SerializeObject(ObjectToConvert, _jsonWriter);
        }

        public static T JsonToObject(string jsonText)
        {
            var retorno = JsonConvert.DeserializeObject<T>(jsonText);

            return retorno;
        }
    }
}
