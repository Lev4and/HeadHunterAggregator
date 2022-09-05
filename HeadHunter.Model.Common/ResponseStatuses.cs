using System.Net;

namespace HeadHunter.Model.Common
{
    public static class ResponseStatuses
    {
        public static readonly ResponseStatus Success = new ResponseStatus("Success", "Successful response", HttpStatusCode.OK);

        public static readonly ResponseStatus NotFound = new ResponseStatus("NotFound", "The specified resource was not found", HttpStatusCode.NotFound);

        public static readonly ResponseStatus Forbidden = new ResponseStatus("Forbidden", "Access to the resource is prohibited", HttpStatusCode.Forbidden);

        public static readonly ResponseStatus BadRequest = new ResponseStatus("BadRequest", "Incorrect data was transmitted", HttpStatusCode.BadRequest);


        public static readonly Dictionary<HttpStatusCode, ResponseStatus> Dictionary = new Dictionary<HttpStatusCode, ResponseStatus>()
        {
            { HttpStatusCode.OK, Success },
            { HttpStatusCode.NotFound, NotFound },
            { HttpStatusCode.Forbidden, Forbidden },
            { HttpStatusCode.BadRequest, BadRequest },
        };
    }
}
