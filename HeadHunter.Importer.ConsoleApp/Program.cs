using HeadHunter.HttpClients;
using HeadHunter.Importer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

var host = AppStartup();

var importer = host.Services.GetService<VacanciesImporter>();
var actor = host.Services.GetService<VacanciesImporterActor>();
var initializingImporter = host.Services.GetService<InitializingImporter>();

await initializingImporter.InitializeAsync();

while (true)
{
    await foreach (var vacancy in importer.GetVacanciesAsync())
    {
        await actor.SendAsync(vacancy);
    }
}

static IHost AppStartup()
{
    var builder = new ConfigurationBuilder();

    BuildConfig(builder);

    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(context.Configuration)
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            services.AddSingleton<HttpContext>();
            services.AddSingleton<EventBus>();
            services.AddSingleton<InitializingImporter>();
            services.AddSingleton<VacanciesImporter>();
            services.AddSingleton<VacanciesImporterActor>();
        })
        .UseSerilog()
        .Build();

    return host;
}

static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
}