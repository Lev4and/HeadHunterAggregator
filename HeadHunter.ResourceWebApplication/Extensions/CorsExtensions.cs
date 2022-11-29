namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class CorsExtensions
    {
        public const string CorsPolicyName = "CorsPolicy";

        private static readonly string[] _origins = new string[3]
        {
            "http://localhost", "http://lev4and.ru", "http://194-67-67-175.cloudvps.regruhosting.ru"
        };

        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(setup =>
            {
                setup.AddPolicy(CorsPolicyName, policy => policy.WithOrigins(_origins)
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
        }

        public static void UseCorsPolicy(this IApplicationBuilder builder)
        {
            builder.UseCors(CorsPolicyName);
        }
    }
}
