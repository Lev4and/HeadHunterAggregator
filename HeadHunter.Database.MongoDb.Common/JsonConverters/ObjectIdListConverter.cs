using MongoDB.Bson;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Common.JsonConverters
{
    public class ObjectIdListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var objectId = ObjectId.Empty;
            var value = (List<ObjectId>?)existingValue;

            return value?.Where(item => ObjectId.TryParse(Convert.ToString(item), out objectId))
                ?.Select(item => ObjectId.Parse(Convert.ToString(item)))?.ToList();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (List<ObjectId>)value);

        }
    }
}
