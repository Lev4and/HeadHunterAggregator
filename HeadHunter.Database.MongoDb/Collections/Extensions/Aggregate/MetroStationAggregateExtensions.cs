using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class MetroStationAggregateExtensions
    {
        private static Repository _repository;

        public static void Init(Repository repository)
        {
            _repository = repository;
        }

        public static IAggregateFluent<MetroStation> WithLine(this IAggregateFluent<MetroStation> aggregate)
        {
            return aggregate
                .Lookup<MetroStation, MetroLine, MetroStation>(_repository.GetCollection<MetroLine>(), metroStation => metroStation.MetroLineId, metroLine => metroLine.Id, metroStation => metroStation.Line)
                .Unwind<MetroStation, MetroStation>(metroStation => metroStation.Line, new AggregateUnwindOptions<MetroStation>() { PreserveNullAndEmptyArrays = true });
        }

        public static IAggregateFluent<MetroStation> WithLineArea(this IAggregateFluent<MetroStation> aggregate)
        {
            return aggregate
                .Lookup<MetroStation, Area, MetroStation>(_repository.GetCollection<Area>(), metroStation => metroStation.Line.AreaId, area => area.Id, metroStation => metroStation.Line.Area)
                .Unwind<MetroStation, MetroStation>(metroStation => metroStation.Line.Area, new AggregateUnwindOptions<MetroStation>() { PreserveNullAndEmptyArrays = true });
        }
    }
}
