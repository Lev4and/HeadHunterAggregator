using Serilog;

namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class SerilogExtensions
    {
        public static void UseSerilog(this ConfigureHostBuilder host)
        {
            host.UseSerilog((context, configuration) =>
                configuration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));
        }

        public static void UseSerilogRequestLogging(this IApplicationBuilder builder)
        {
            builder.UseSerilogRequestLogging();
        }
    }
}
