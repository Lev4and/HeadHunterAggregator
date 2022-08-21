using System.Net;

namespace HeadHunter.Model.Common
{
    public class ResponseStatus
    {
        public string Name { get; }

        public string Message { get; }

        public HttpStatusCode Code { get; }

        public ResponseStatus(HttpStatusCode code)
        {
            Name = "";
            Message = "";
            Code = code;
        }

        public ResponseStatus(string name, string message, HttpStatusCode code)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            Name = name;
            Message = message;
            Code = code;
        }
    }
}
