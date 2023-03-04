using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Extensions;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IMetroLineFactory : IFactory<ResponseModels.MetroLine?, Entities.MetroLine?>
    {

    }

    internal class MetroLineFactory : IMetroLineFactory
    {
        private readonly IAreaFactory _areaFactory;
        private readonly IMetroStationFactory _metroStationFactory;

        public MetroLineFactory(IAreaFactory areaFactory, IMetroStationFactory metroStationFactory)
        {
            _areaFactory = areaFactory;
            _metroStationFactory = metroStationFactory;
        }

        public Entities.MetroLine? Create(ResponseModels.MetroLine? input)
        {
            if (input == null) return null;

            return new Entities.MetroLine
            {
                HeadHunterId = input.Id, 
                Name = input.Name, 
                HexColor = input.HexColor,
                Area = _areaFactory.Create(input.Area),
                Stations = _metroStationFactory.CreateArray(input.Stations?.ToArray())
            };
        }
    }
}
