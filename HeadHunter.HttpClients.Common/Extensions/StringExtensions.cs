using Newtonsoft.Json;

namespace HeadHunter.HttpClients.Common.Extensions
{
    public static class StringExtensions
    {
        public static T? Deserialize<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}
