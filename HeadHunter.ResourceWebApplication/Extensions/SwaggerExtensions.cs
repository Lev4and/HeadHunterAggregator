using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
                options.AddServers();
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        private static void AddServers(this SwaggerGenOptions options)
        {
            var serverUrl = Environment.GetEnvironmentVariable("BACKEND_URL");

            if (!string.IsNullOrEmpty(serverUrl) )
            {
                options.AddServer(new OpenApiServer() { Url = serverUrl });
            }
        }
    }
}
