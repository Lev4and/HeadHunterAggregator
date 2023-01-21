namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class CorsExtensions
    {
        public const string CorsPolicyName = "CorsPolicy";

        private static readonly string[] _origins = new string[2]
        {
            "http://localhost", "http://lev4and.ru"
        };

        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(setup =>
            {
                setup.AddPolicy(CorsPolicyName, policy => policy.WithOrigins(_origins)
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
        }

        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder builder)
        {
            return builder.UseCors(CorsPolicyName);
        }
    }
}
