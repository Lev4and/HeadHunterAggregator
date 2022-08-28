namespace HeadHunter.HttpClients.Common
{
    public interface IReadableHttpContent
    {
        Task<string> ReadAsStringAsync(HttpContent content);
    }
}
