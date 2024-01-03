using HeadHunterAggregator.Domain.Entities;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers;
using MassTransit.Internals;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class VacanciesDbMappers : IDbMappers
    {
        public IDbMapper<TSource, TEntity> GetDbMapper<TSource, TEntity>()
            where TSource : class
            where TEntity : EntityBase
        {
            var mapperType = typeof(VacanciesDbMappers).Assembly.GetTypes()
                .First(type => type.IsClass && type.HasInterface<IDbMapper<TSource, TEntity>>());

            return Activator.CreateInstance(mapperType) as IDbMapper<TSource, TEntity>
                ?? throw new NotSupportedException();
        }

        public TEntity Map<TSource, TEntity>(TSource source) 
            where TSource : class 
            where TEntity : EntityBase
        {
            return GetDbMapper<TSource, TEntity>().Map(source);
        }
    }
}
