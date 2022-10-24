using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class MetroLineAggregateExtensions
    {
        public static IAggregateFluent<MetroLine> WithArea(this IAggregateFluent<MetroLine> aggregate, IMongoCollection<Area> collection)
        {
            return aggregate
                .Lookup<MetroLine, Area, MetroLine>(collection, metroLine => metroLine.AreaId, area => area.Id, metroLine => metroLine.Area)
                .Unwind<MetroLine, MetroLine>(metroLine => metroLine.Area);
        }

        public static IAggregateFluent<MetroLine> WithStations(this IAggregateFluent<MetroLine> aggregate, IMongoCollection<MetroStation> collection)
        {
            return aggregate.Lookup<MetroLine, MetroStation, MetroLine>(collection, metroLine => metroLine.Id, metroStation => metroStation.MetroLineId, metroLine => metroLine.Stations);
        }
    }
}
