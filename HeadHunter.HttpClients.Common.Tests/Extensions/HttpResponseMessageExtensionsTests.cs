using HeadHunter.HttpClients.Common.Extensions;
using System.Net;

namespace HeadHunter.HttpClients.Common.Tests.Extensions
{
    public class HttpResponseMessageExtensionsTests
    {
        [Fact]
        public async Task GetResponseModel_WithNullResponseParam_ThrowException()
        {
            var response = null as HttpResponseMessage;

            var action = async () => { await response.GetResponseModel(); };

            await Assert.ThrowsAsync<NullReferenceException>(action);
        }

        [Fact]
        public async Task GetResponseModel_WithValidResponseParam_ReturnNotNullResult()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var response = await httpClient.GetAsync("");
            var result = await response.GetResponseModel();

            Assert.NotNull(result);
            Assert.NotEmpty(result.Result);
            Assert.Equal(HttpStatusCode.OK, result.Status.Code);
        }

        [Fact]
        public async Task GetResponseModelWithGeneric_WithNullResponseParam_ThrowException()
        {
            var response = null as HttpResponseMessage;

            var action = async () => { await response.GetResponseModel<dynamic>(); };

            await Assert.ThrowsAsync<NullReferenceException>(action);
        }

        [Fact]
        public async Task GetResponseModelWithGeneric_WithResponseWithHtmlContentParam_WithoutThrowException()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var response = await httpClient.GetAsync("");
            var result = await response.GetResponseModel<dynamic>();
        }

        [Fact]
        public async Task GetResponseModelWithGeneric_WithResponseParam_ReturnNotNullResponse()
        {
            var httpClient = new BaseHttpClient("https://api.hh.ru/vacancies");

            var response = await httpClient.GetAsync("?per_page=100");
            var result = await response.GetResponseModel<dynamic>();

            Assert.NotNull(result);
        }
    }
}
