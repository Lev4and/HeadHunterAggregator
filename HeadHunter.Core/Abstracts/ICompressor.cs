namespace HeadHunter.Core.Abstracts
{
    public interface ICompressor
    {
        string Compress(string uncompressedText);

        string Decompress(string compressedText);
    }
}
