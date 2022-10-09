using HeadHunter.Model.Common.Compression;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Common.JsonConverters
{
    public class BrotliConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return Convert.ToString(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, Convert.ToString(value));
        }
    }
}
