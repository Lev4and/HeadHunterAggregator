﻿using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class SpecializationsHttpClientTests
    {
        private readonly SpecializationsHttpClient _httpClient;

        public SpecializationsHttpClientTests()
        {
            _httpClient = new SpecializationsHttpClient();
        }

        [Fact]
        public async Task GetSpecializationsAsync_ReturnNotEmptyResult()
        {
            var response = await _httpClient.GetSpecializationsAsync();

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);
        }
    }
}