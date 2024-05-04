using Newtonsoft.Json;

namespace EngineTrendMonitoring.Shared.ExtensionMethods
{
    public class JsonExtensionMethods
    {
        public static string ToJson<T>(T obj) => JsonConvert.SerializeObject(obj);
        public static T? ToObject<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
