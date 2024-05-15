using Newtonsoft.Json;

namespace EngineTrendMonitoring.Shared.ExtensionMethods
{
    public static class JsonExtensionMethods
    {
        public static string ToJson<T>(this T obj) => JsonConvert.SerializeObject(obj);
        public static T? ToObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
