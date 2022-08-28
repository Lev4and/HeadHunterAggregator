namespace HeadHunter.HttpClients.Common.HttpContentReaders
{
    public class DefaultHttpContentReader : IReadableHttpContent
    {
        public async Task<string> ReadAsStringAsync(HttpContent content)
        {
            return await content.ReadAsStringAsync();
        }
    }
}
