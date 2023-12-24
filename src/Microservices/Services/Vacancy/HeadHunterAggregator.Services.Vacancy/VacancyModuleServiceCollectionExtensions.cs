﻿using HeadHunterAggregator.Domain.Infrastructure.MessageBrokers;
using HeadHunterAggregator.Infrastructure.MessageBrokers.RabbitMQ;
using HeadHunterAggregator.Services.Vacancy.ConfigurationOptions;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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