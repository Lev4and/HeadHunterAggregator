using HeadHunter.Core.Abstracts;
using System.IO.Compression;
using System.Text;

namespace HeadHunter.Core.Compression
{
    public class BrotliCompressor : ICompressor
    {
        public string? Compress(string? uncompressedText)
        {
            if (string.IsNullOrEmpty(uncompressedText)) return uncompressedText;

            var uncompressedTextBytes = Encoding.UTF8.GetBytes(uncompressedText);

            using (var outputStream = new MemoryStream())
            {
                using (var compressStream = new BrotliStream(outputStream, CompressionLevel.SmallestSize))
                {
                    compressStream.Write(uncompressedTextBytes, 0, uncompressedTextBytes.Length);
                }

                return Convert.ToBase64String(outputStream.ToArray());
            }
        }

        public string? Decompress(string? compressedText)
        {
            if (string.IsNullOrEmpty(compressedText)) return compressedText;

            var compressedTextBytes = Convert.FromBase64String(compressedText);

            using (var inputStream = new MemoryStream(compressedTextBytes))
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var decompressStream = new BrotliStream(inputStream, CompressionMode.Decompress))
                    {
                        decompressStream.CopyTo(outputStream);
                    }

                    return Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }
        }
    }
}
