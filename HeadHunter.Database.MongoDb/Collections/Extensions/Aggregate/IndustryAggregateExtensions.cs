using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class IndustryAggregateExtensions
    {
        private static Repository _repository;

        public static void Init(Repository repository)
        {
            _repository = repository;
        }

        public static IAggregateFluent<Industry> WithParent(this IAggregateFluent<Industry> aggregate)
        {
            return aggregate
                .Lookup<Industry, Industry, Industry>(_repository.GetCollection<Industry>(), industry => industry.ParentId, industry => industry.Id, industry => industry.Parent)
                .Unwind<Industry, Industry>(industry => industry.Parent);
        }

        public static IAggregateFluent<Industry> WithChildren(this IAggregateFluent<Industry> aggregate)
        {
            return aggregate.Lookup<Industry, Industry, Industry>(_repository.GetCollection<Industry>(), industry => industry.Id, industry => industry.ParentId, industry => industry.Children);
        }
    }
}
