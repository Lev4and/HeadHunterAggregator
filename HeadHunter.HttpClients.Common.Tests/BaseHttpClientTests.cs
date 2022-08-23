using System.Net;

namespace HeadHunter.HttpClients.Common.Tests
{
    public class BaseHttpClientTests
    {
        [Fact]
        public void Initialization_WithNullUriParam_ThrowException()
        {
            var action = () => { new BaseHttpClient(null); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Initialization_WithEmptyUriParam_ThrowException()
        {
            var action = () => { new BaseHttpClient(""); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Initialization_WithValidUriParam_ReturnHttpClient()
        {
            var uri = "https://hh.ru/";
            var httpClient = new BaseHttpClient(uri);

            Assert.NotNull(httpClient);
            Assert.Equal(uri, httpClient?.BaseAddress?.AbsoluteUri);
        }

        [Fact]
        public void Initialization_WithoutParam_ReturnHttpClient()
        {
            var httpClient = new BaseHttpClient();

            Assert.NotNull(httpClient);
            Assert.Equal("", "");
        }

        [Fact]
        public async Task Get_WithNullQueryParam_ThrowException()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var action = async () => { await httpClient.Get(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task Get_WithEmptyQueryParam_ReturnSuccessResponseWithNotNullResult()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var response = await httpClient.Get("");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task Post_WithNullQueryParam_ThrowException()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var action = async () => { await httpClient.Post<dynamic>(null, ""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task Put_WithNullQueryParam_ThrowException()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var action = async () => { await httpClient.Put<dynamic>(null, ""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task Delete_WithNullQueryParam_ThrowException()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var action = async () => { await httpClient.Delete<dynamic>(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public void UseHeaders_WithNullHeadersParam_ThrowException()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            var action = () => { httpClient.UseHeaders(null); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseHeaders_WithEmptyHeadersParam_HeadersLengthShouldBeEqualZero()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");

            httpClient.UseHeaders(new Dictionary<string, string>());

            Assert.NotNull(httpClient);
            Assert.Empty(httpClient.DefaultRequestHeaders);
        }

        [Fact]
        public void UseHeaders_WithHeadersParam_HeadersLengthShouldBeEqualFive()
        {
            var httpClient = new BaseHttpClient("https://github.com/Lev4and/HeadHunter");
            var headers = new Dictionary<string, string>()
            {
                { "accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" },
                { "accept-encoding", "gzip, deflate, br" },
                { "accept-language", "ru,en;q=0.9" },
                { "cache-control", "max-age=0" },
                { "sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"102\", \"Yandex\";v=\"22\"" }
            };

            httpClient.UseHeaders(headers);

            Assert.NotNull(httpClient);
            Assert.NotEmpty(httpClient.DefaultRequestHeaders);
            Assert.Equal(5, httpClient.DefaultRequestHeaders.Count());
        }
    }
}
