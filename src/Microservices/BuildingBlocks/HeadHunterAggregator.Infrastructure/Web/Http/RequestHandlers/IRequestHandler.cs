using HeadHunterAggregator.Infrastructure.Web.Http.ResponseMapers;
using HeadHunterAggregator.Infrastructure.Web.Http.ResponseReaders;

namespace HeadHunterAggregator.Infrastructure.Web.Http.RequestHandlers
{
    public interface IRequestHandler
    {
        IResponseMaper Maper { get; }

        IResponseReader Reader { get; }

        Task<ResponseModel<TResult>> HandleAsync<TResult>(Func<Task<HttpResponseMessage>> request);
    }
}
