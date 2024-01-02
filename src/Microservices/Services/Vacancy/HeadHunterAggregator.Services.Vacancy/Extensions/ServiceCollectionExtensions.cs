using HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using MassTransit.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunterAggregator.Services.Vacancy.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            foreach (var mapperInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(IMapper<,>))))
            {
                foreach (var mapper in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(mapperInterface)))
                {
                    services.AddTransient(mapperInterface, mapper);
                }
            }

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

            return services;
        }
    }
}
