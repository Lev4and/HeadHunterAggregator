﻿namespace HeadHunterAggregator.Infrastructure.Web.Http.ResponseReaders
{
    public interface IResponseReader
    {
        Task<string> ReadAsync(HttpResponseMessage response);
    }
}
