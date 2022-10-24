using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace HeadHunter.Database.MongoDb.Common.BsonSerializers
{
    public class LookupSerializer<T> : SerializerBase<T?>
    {
        public override T? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var serializer = BsonSerializer.LookupSerializer<T[]>();
            var data = serializer.Deserialize(context, args);

            return data.FirstOrDefault();
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, T? value)
        {
            var serializer = BsonSerializer.LookupSerializer<T[]?>();

            serializer.Serialize(context, value != null ? new T[] { value } : null);
        }
    }
}
