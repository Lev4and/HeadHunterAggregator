using Newtonsoft.Json;
using System.Net;

namespace HeadHunter.HttpClients.Core.ResponseModels
{
    public class ResponseModel<T>
    {
        public bool? IsError { get; }

        public string? Message { get; }

        public HttpStatusCode? Code { get; }

        public T? Result { get; }

        public Exception? ResponseException { get; }

        [JsonConstructor]
        public ResponseModel()
        {
            IsError = false;
            Message = null;
            Code = null;
            Result = default(T);
            ResponseException = null;
        }

        public ResponseModel(T? result, HttpStatusCode? code, string? message, bool? isError = false, 
            Exception? exception = null)
        {
            IsError = isError;
            Message = message;
            Code = code;
            Result = result;
            ResponseException = exception;
        }

        public ResponseModel(T? result, HttpStatusCode? code, bool? isError = false,
            Exception? exception = null) : this(result, code, code?.ToString(), isError, exception)
        {

        }
    }
}
