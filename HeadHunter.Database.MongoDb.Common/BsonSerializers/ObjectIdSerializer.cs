using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace HeadHunter.Database.MongoDb.Common.BsonSerializers
{
    public class ObjectIdSerializer : SerializerBase<ObjectId?>
    {
        public override ObjectId? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var value = context.Reader.ReadObjectId();

            return ObjectId.Empty != value ? value : null;
        }
    }
}
