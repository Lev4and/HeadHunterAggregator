namespace HeadHunter.HttpClients.Core
{
    public interface IHttpResponseReader
    {
        Task<string> ReadAsync(HttpResponseMessage response);
    }
}
