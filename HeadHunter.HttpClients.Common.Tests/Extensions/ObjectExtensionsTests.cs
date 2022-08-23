using HeadHunter.HttpClients.Common.Extensions;

namespace HeadHunter.HttpClients.Common.Tests.Extensions
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ToStringContent_WithNumberTypeParam_ReturnNotNullResult()
        {
            var data = 1;

            var result = data.ToStringContent();

            Assert.NotNull(result);
        }

        [Fact]
        public void ToStringContent_WithStringTypeParam_ReturnNotNullResult()
        {
            var data = "1";

            var result = data.ToStringContent();

            Assert.NotNull(result);
        }

        [Fact]
        public void ToStringContent_WithDateTimeTypeParam_ReturnNotNullResult()
        {
            var data = DateTime.UtcNow;

            var result = data.ToStringContent();

            Assert.NotNull(result);
        }

        [Fact]
        public void ToStringContent_WithStringTypeAsNullValueParam_ReturnNotNullResult()
        {
            var data = null as string;

            var result = data.ToStringContent();

            Assert.NotNull(result);
        }
    }
}
