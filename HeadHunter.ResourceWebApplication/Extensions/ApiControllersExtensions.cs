namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class ApiControllersExtensions
    {
        public static void AddApiControllers(this IServiceCollection services)
        {
            services.AddControllersWithViews().ConfigureJson();
        }

        private static void ConfigureJson(this IMvcBuilder builder)
        {
            builder.AddNewtonsoftJson(options => 
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }
    }
}
