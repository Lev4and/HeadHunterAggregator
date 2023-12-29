using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Domain.Infrastructure.MessageBrokers;
using HeadHunterAggregator.Infrastructure.MessageBrokers.RabbitMQ;
using HeadHunterAggregator.Services.Vacancy.ConfigurationOptions;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using MassTransit;
using MassTransit.Internals;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HeadHunterAggregator.Services.Vacancy
{
    public static class VacancyModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddVacancyModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumers(typeof(VacancyModuleServiceCollectionExtensions).Assembly);

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(settings.MessageBroker.RabbitMQ.Host), hostConfigurator =>
                    {
                        hostConfigurator.Username(settings.MessageBroker.RabbitMQ.Username);
                        hostConfigurator.Password(settings.MessageBroker.RabbitMQ.Password);
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });

            services.AddTransient<IMessageBus, RabbitMQMessageBus>();

            services.AddDbContext<VacanciesDbContext>((options) =>
            {
                options.UseNpgsql(settings.ConnectionStrings.VacanciesDbPostgreSQL)
                    .UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<VacanciesDbContext>());

            foreach (var repositoryInterface in typeof(VacancyModuleServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(IRepository<>))))
            {
                foreach (var repository in typeof(VacancyModuleServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(repositoryInterface)))
                {
                    services.AddTransient(repositoryInterface, repository);
                }
            }

            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<HeadHunterApi>();

            return services;
        }

        public static void MigrateVacanciesDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                serviceScope?.ServiceProvider.GetRequiredService<VacanciesDbContext>().Database.Migrate();
            }
        }
    }
}
