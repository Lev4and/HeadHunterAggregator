namespace HeadHunter.Core.Domain.Cqrs
{
    public class ResultModel<T>
    {
        public T Data { get; }

        public bool IsError { get; }

        public string ErrorMessage { get; }

        public ResultModel(T data) : this(data, false, string.Empty)
        {

        }

        public ResultModel(T data, bool isError) : this(data, isError, string.Empty)
        {

        }

        public ResultModel(T data, bool isError, string errorMessage)
        {
            Data = data;
            IsError = isError;
            ErrorMessage = errorMessage;
        }
    }
}
