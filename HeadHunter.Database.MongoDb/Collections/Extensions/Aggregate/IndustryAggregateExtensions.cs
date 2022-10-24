using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class IndustryAggregateExtensions
    {
        public static IAggregateFluent<Industry> WithParent(this IAggregateFluent<Industry> aggregate, IMongoCollection<Industry> collection)
        {
            return aggregate
                .Lookup<Industry, Industry, Industry>(collection, industry => industry.ParentId, industry => industry.Id, industry => industry.Parent)
                .Unwind<Industry, Industry>(industry => industry.Parent);
        }

        public static IAggregateFluent<Industry> WithChildren(this IAggregateFluent<Industry> aggregate, IMongoCollection<Industry> collection)
        {
            return aggregate.Lookup<Industry, Industry, Industry>(collection, industry => industry.Id, industry => industry.ParentId, industry => industry.Children);
        }
    }
}
