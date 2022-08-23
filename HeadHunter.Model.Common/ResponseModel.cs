namespace HeadHunter.Model.Common
{
    public class ResponseModel<T>
    {
        public T? Result { get; }

        public ResponseStatus Status { get; }

        public ResponseModel(T? result, ResponseStatus status)
        {
            Result = result;
            Status = status;
        }
    }
}
