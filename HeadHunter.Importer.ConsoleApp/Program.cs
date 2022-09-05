using HeadHunter.HttpClients;
using HeadHunter.Importer;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

var services = new ServiceCollection()
    .AddSingleton<HttpContext>()
    .AddSingleton<EventBus>()
    .AddSingleton<Importer>()
    .AddSingleton<ImporterActor>();

var serviceProvider = services.BuildServiceProvider();

var importer = serviceProvider.GetService<Importer>();
var actor = serviceProvider.GetService<ImporterActor>();

await foreach (var vacancy in importer.GetVacanciesAsync())
{
    await actor.SendAsync(vacancy);
}