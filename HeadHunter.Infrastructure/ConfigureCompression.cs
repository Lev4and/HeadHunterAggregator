using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Compression;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.Infrastructure
{
    internal static class ConfigureCompression
    {
        public static void AddCompression(this IServiceCollection services)
        {
            services.AddSingleton<ICompressor, BrotliCompressor>();
        }
    }
}
