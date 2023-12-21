using HeadHunterAggregator.Infrastructure.Web.Http.Extensions;
using System.Net;
using System.Text.Json.Serialization;

namespace HeadHunterAggregator.Infrastructure.Web.Http
{
    public class ResponseModel<TResult>
    {
        public bool IsError => Code.IsErrorStatusCode() || Exception != null;

        public string? Message { get; }

        public TResult? Result { get; }

        public HttpStatusCode? Code { get; }

        public Exception? Exception { get; }

        [JsonConstructor]
        public ResponseModel()
        {
            Message = null;
            Result = default(TResult);
            Code = null;
            Exception = null;
        }

        public ResponseModel(TResult? result, HttpStatusCode? code, string? message,
            Exception? exception = null)
        {
            Message = message;
            Code = code;
            Result = result;
            Exception = exception;
        }

        public ResponseModel(TResult? result, HttpStatusCode? code, Exception? exception = null) : 
            this(result, code, code?.ToString(), exception)
        {

        }
    }
}
