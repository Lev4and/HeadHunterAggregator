using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Common
{
    public interface IConvertibleHttpResponse
    {
        IReadableHttpContent HttpContentReader { get; }

        Task<ResponseModel<T>> ToResponseModelAsync<T>(HttpResponseMessage response);
    }
}
