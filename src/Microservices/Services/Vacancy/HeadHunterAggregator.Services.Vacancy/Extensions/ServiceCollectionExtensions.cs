using HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using MassTransit.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunterAggregator.Services.Vacancy.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            foreach (var mapperInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(IDbMapper<,>))))
            {
                foreach (var mapper in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(mapperInterface)))
                {
                    services.AddSingleton(mapperInterface, mapper);
                }
            }

            services.AddSingleton<IDbMappers, VacanciesDbMappers>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            foreach (var repositoryInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(IRepository<>))))
            {
                foreach (var repository in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(repositoryInterface)))
                {
                    services.AddTransient(repositoryInterface, repository);
                }
            }

            services.AddTransient<IRepository, VacanciesDbRepository>();
            services.AddTransient<IFromHeadHunterRepository, VacanciesDbFromHeadHunterRepository>();

            return services;
        }
    }
}
