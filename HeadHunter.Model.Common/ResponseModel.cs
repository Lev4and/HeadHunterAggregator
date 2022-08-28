namespace HeadHunter.Model.Common
{
    public class ResponseModel<T>
    {
        public T Result { get; set; }

        public ResponseStatus Status { get; set; }

        public ResponseModel()
        {

        }

        public ResponseModel(T result, ResponseStatus status)
        {
            Result = result;
            Status = status;
        }
    }
}
