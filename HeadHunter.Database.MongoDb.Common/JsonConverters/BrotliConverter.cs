using Newtonsoft.Json;
using System.IO.Compression;
using System.Text;

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
            var uncompressedText = Convert.ToString(reader.Value) ?? "";
            var uncompressedTextBytes = Encoding.UTF8.GetBytes(uncompressedText);

            using (var outputStream = new MemoryStream())
            {
                using (var compressStream = new BrotliStream(outputStream, CompressionLevel.SmallestSize))
                {
                    compressStream.Write(uncompressedTextBytes, 0, uncompressedTextBytes.Length);
                }

                return Encoding.UTF8.GetString(outputStream.ToArray());
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var compressedText = Convert.ToString(value) ?? "";
            var compressedTextBytes = Encoding.UTF8.GetBytes(compressedText);

            using (var inputStream = new MemoryStream(compressedTextBytes))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var decompressStream = new BrotliStream(inputStream, CompressionMode.Decompress))
                    {
                        decompressStream.CopyTo(outputStream);
                    }

                    serializer.Serialize(writer, Encoding.UTF8.GetString(outputStream.ToArray()));
                }
            }
        }
    }
}
