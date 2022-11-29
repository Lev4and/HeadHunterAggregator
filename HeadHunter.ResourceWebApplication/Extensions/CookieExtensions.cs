namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class CookieExtensions
    {
        public static void ConfigureCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options => options.LoginPath = "/api/error/unauthorized");
        }
    }
}
