﻿using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Common.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<ResponseModel<string>> GetResponseModel(this HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            var code = response.StatusCode;

            return new ResponseModel<string>(result, new ResponseStatus(code));
        }

        public static async Task<ResponseModel<T>> GetResponseModel<T>(this HttpResponseMessage response)
        {
            var stringContent = await response.Content.ReadAsStringAsync();
            var result = stringContent.Deserialize<T>();
            var code = response.StatusCode;

            return new ResponseModel<T>(result, new ResponseStatus(code));
        }
    }
}
