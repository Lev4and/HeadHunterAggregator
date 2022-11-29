using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.HttpClients
{
    public static class Configure
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddSingleton<HttpContext>();
        }
    }
}
