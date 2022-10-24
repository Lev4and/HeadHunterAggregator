using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class SpecializationAggregateExtensions
    {
        public static IAggregateFluent<Specialization> WithParent(this IAggregateFluent<Specialization> aggregate, IMongoCollection<Specialization> collection)
        {
            return aggregate
                .Lookup<Specialization, Specialization, Specialization>(collection, specialization => specialization.ParentId, specialization => specialization.Id, specialization => specialization.Parent)
                .Unwind<Specialization, Specialization>(specialization => specialization.Parent);
        }

        public static IAggregateFluent<Specialization> WithChildren(this IAggregateFluent<Specialization> aggregate, IMongoCollection<Specialization> collection)
        {
            return aggregate.Lookup<Specialization, Specialization, Specialization>(collection, specialization => specialization.Id, specialization => specialization.ParentId, specialization => specialization.Children);
        }
    }
}
