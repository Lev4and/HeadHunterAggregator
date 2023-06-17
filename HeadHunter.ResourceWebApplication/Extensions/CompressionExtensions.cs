using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class CompressionExtensions
    {
        public static void AddCompression(this IServiceCollection services)
        {
            services.AddResponseCompression();

            services.Configure<BrotliCompressionProviderOptions>(config =>
            {
                config.Level = CompressionLevel.SmallestSize;
            });
        }

        public static IApplicationBuilder UseCompression(this IApplicationBuilder builder)
        {
            return builder.UseResponseCompression();
        }
    }
}
