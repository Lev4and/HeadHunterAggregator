using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class SpecializationAggregateExtensions
    {
        private static Repository _repository;

        public static void Init(Repository repository)
        {
            _repository = repository;
        }

        public static IAggregateFluent<Specialization> WithParent(this IAggregateFluent<Specialization> aggregate)
        {
            return aggregate
                .Lookup<Specialization, Specialization, Specialization>(_repository.GetCollection<Specialization>(), specialization => specialization.ParentId, specialization => specialization.Id, specialization => specialization.Parent)
                .Unwind<Specialization, Specialization>(specialization => specialization.Parent);
        }

        public static IAggregateFluent<Specialization> WithChildren(this IAggregateFluent<Specialization> aggregate)
        {
            return aggregate.Lookup<Specialization, Specialization, Specialization>(_repository.GetCollection<Specialization>(), specialization => specialization.Id, specialization => specialization.ParentId, specialization => specialization.Children);
        }
    }
}
