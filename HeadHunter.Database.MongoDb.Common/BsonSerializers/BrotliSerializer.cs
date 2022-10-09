using HeadHunter.Model.Common.Compression;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace HeadHunter.Database.MongoDb.Common.BsonSerializers
{
    public class BrotliSerializer : SerializerBase<string>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            context.Writer.WriteString(BrotliCompressor.Compress(value));
        }

        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return BrotliCompressor.Decompress(context.Reader.ReadString());
        }
    }
}
