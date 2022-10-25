using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class MetroLineAggregateExtensions
    {
        private static Repository _repository;

        public static void Init(Repository repository)
        {
            _repository = repository;
        }

        public static IAggregateFluent<MetroLine> WithArea(this IAggregateFluent<MetroLine> aggregate)
        {
            return aggregate
                .Lookup<MetroLine, Area, MetroLine>(_repository.GetCollection<Area>(), metroLine => metroLine.AreaId, area => area.Id, metroLine => metroLine.Area)
                .Unwind<MetroLine, MetroLine>(metroLine => metroLine.Area);
        }

        public static IAggregateFluent<MetroLine> WithStations(this IAggregateFluent<MetroLine> aggregate)
        {
            return aggregate.Lookup<MetroLine, MetroStation, MetroLine>(_repository.GetCollection<MetroStation>(), metroLine => metroLine.Id, metroStation => metroStation.MetroLineId, metroLine => metroLine.Stations);
        }
    }
}
