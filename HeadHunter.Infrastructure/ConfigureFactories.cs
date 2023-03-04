using HeadHunter.Infrastructure.Factories.HeadHunter;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.Infrastructure
{
    internal static class ConfigureFactories
    {
        public static void AddFactories(this IServiceCollection services)
        {
            services.AddHeadHunterFactories();
        }
    }
}
