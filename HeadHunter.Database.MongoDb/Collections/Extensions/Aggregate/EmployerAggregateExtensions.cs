using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class EmployerAggregateExtensions
    {
        private static Repository _repository;

        public static void Init(Repository repository)
        {
            _repository = repository;
        }

        public static IAggregateFluent<Employer> WithArea(this IAggregateFluent<Employer> aggregate)
        {
            return aggregate
                .Lookup<Employer, Area, Employer>(_repository.GetCollection<Area>(), employer => employer.AreaId, area => area.Id, employer => employer.Area)
                .Unwind<Employer, Employer>(employer => employer.Area, new AggregateUnwindOptions<Employer>() { PreserveNullAndEmptyArrays = true });
        }

        public static IAggregateFluent<Employer> WithIndustries(this IAggregateFluent<Employer> aggregate)
        {
            return aggregate.Lookup<Employer, Industry, Employer>(_repository.GetCollection<Industry>(), employer => employer.IndustriesIds, industry => industry.Id, employer => employer.Industries);
        }
    }
}
