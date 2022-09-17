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

var importer = host.Services.GetService<Importer>();
var actor = host.Services.GetService<ImporterActor>();

await foreach (var vacancy in importer.GetVacanciesAsync())
{
    await actor.SendAsync(vacancy);
}

static IHost AppStartup()
{
    var builder = new ConfigurationBuilder();

    BuildConfig(builder);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Build())
        .WriteTo.Console()
        .CreateLogger();

    Log.Logger.Information("Application Starting");

    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddTransient<HttpContext>();
            services.AddTransient<EventBus>();
            services.AddTransient<Importer>();
            services.AddTransient<ImporterActor>();
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