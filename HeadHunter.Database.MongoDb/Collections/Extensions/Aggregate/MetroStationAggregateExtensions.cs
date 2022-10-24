using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class MetroStationAggregateExtensions
    {
        public static IAggregateFluent<MetroStation> WithLine(this IAggregateFluent<MetroStation> aggregate, IMongoCollection<MetroLine> collection)
        {
            return aggregate
                .Lookup<MetroStation, MetroLine, MetroStation>(collection, metroStation => metroStation.MetroLineId, metroLine => metroLine.Id, metroStation => metroStation.Line)
                .Unwind<MetroStation, MetroStation>(metroStation => metroStation.Line);
        }

        public static IAggregateFluent<MetroStation> WithLineArea(this IAggregateFluent<MetroStation> aggregate, IMongoCollection<Area> collection)
        {
            return aggregate
                .Lookup<MetroStation, Area, MetroStation>(collection, metroStation => metroStation.Line.AreaId, area => area.Id, metroStation => metroStation.Line.Area)
                .Unwind<MetroStation, MetroStation>(metroStation => metroStation.Line.Area);
        }
    }
}
