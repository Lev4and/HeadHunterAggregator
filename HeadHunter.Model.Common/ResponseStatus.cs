using System.Net;

namespace HeadHunter.Model.Common
{
    public class ResponseStatus
    {
        public string Name { get; set; }

        public string Message { get; set; }

        public HttpStatusCode Code { get; set; }

        public ResponseStatus()
        {
            Name = "";
            Message = "";
            Code = HttpStatusCode.OK;
        }

        public ResponseStatus(HttpStatusCode code)
        {
            Name = ResponseStatuses.Dictionary[code].Name;
            Message = ResponseStatuses.Dictionary[code].Message;
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
