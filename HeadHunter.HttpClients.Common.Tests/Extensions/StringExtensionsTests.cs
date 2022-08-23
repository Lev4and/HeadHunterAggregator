using HeadHunter.HttpClients.Common.Extensions;

namespace HeadHunter.HttpClients.Common.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Deserialize_WithNullStringParam_ReturnDefaultValue()
        {
            var json = null as string;

            var result = json.Deserialize<dynamic>();

            Assert.NotNull(result);
        }

        [Fact]
        public void Deserialize_WithStringParam_ReturnValueTypeOfNumber()
        {
            var json = "1";

            var result = json.Deserialize<int>();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Deserialize_WithStringParam_ReturnValueTypeOfString()
        {
            var json = "1";

            var result = json.Deserialize<string>();

            Assert.Equal("1", result);
        }

        [Fact]
        public void Deserialize_WithStringParam_ReturnValueTypeOfDynamic()
        {
            var json = "{\"a\":1,\"b\":\"1\"}";

            var result = json.Deserialize<dynamic>();

            Assert.NotNull(result);
        }
    }
}
