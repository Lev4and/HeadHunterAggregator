using MongoDB.Bson;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Common.JsonConverters
{
    public class ObjectIdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = ObjectId.Empty;
            var value = Convert.ToString(reader.Value);
            var hasObjectId = ObjectId.TryParse(value, out result);

            return hasObjectId ? result : null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());

        }
    }
}
