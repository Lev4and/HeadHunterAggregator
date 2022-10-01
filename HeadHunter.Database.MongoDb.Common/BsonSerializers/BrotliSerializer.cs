using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.IO.Compression;
using System.Text;

namespace HeadHunter.Database.MongoDb.Common.BsonSerializers
{
    public class BrotliSerializer : SerializerBase<string>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            var uncompressedText = value;
            var uncompressedTextBytes = Encoding.UTF8.GetBytes(uncompressedText);

            using (var outputStream = new MemoryStream())
            {
                using (var compressStream = new BrotliStream(outputStream, CompressionLevel.SmallestSize))
                {
                    compressStream.Write(uncompressedTextBytes, 0, uncompressedTextBytes.Length);
                }

                context.Writer.WriteString(Convert.ToBase64String(outputStream.ToArray()));
            }
        }

        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var compressedText = context.Reader.ReadString();
            var compressedTextBytes = Convert.FromBase64String(compressedText);

            using (var inputStream = new MemoryStream(compressedTextBytes))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var decompressStream = new BrotliStream(inputStream, CompressionMode.Decompress))
                    {
                        decompressStream.CopyTo(outputStream);
                    }

                    return Convert.ToBase64String(outputStream.ToArray());
                }
            }
        }
    }
}
