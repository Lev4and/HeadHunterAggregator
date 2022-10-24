using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class EmployerAggregateExtensions
    {
        public static IAggregateFluent<Employer> WithArea(this IAggregateFluent<Employer> aggregate, IMongoCollection<Area> collection)
        {
            return aggregate
                .Lookup<Employer, Area, Employer>(collection, employer => employer.AreaId, area => area.Id, employer => employer.Area)
                .Unwind<Employer, Employer>(employer => employer.Area);
        }

        public static IAggregateFluent<Employer> WithIndustries(this IAggregateFluent<Employer> aggregate, IMongoCollection<Industry> collection)
        {
            return aggregate.Lookup<Employer, Industry, Employer>(collection, employer => employer.IndustriesIds, industry => industry.Id, employer => employer.Industries);
        }
    }
}
