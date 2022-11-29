using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class SwaggerExtensions
    {
        private static readonly string[] _serverUrls = new string[2]
        {
            "https://localhost:44300", "http://lev4and.ru/resource"
        };

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
                options.AddServers();
            });
        }

        private static void AddServers(this SwaggerGenOptions options)
        {
            foreach (var serverUrl in _serverUrls)
            {
                options.AddServer(new OpenApiServer() { Url = serverUrl });
            }
        }
    }
}
