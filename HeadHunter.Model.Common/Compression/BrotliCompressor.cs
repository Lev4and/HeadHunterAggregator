﻿using System.IO.Compression;
using System.Text;

namespace HeadHunter.Model.Common.Compression
{
    public static class BrotliCompressor
    {
        public static string Compress(string uncompressedText)
        {
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

        public static string Decompress(string compressedText)
        {
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
