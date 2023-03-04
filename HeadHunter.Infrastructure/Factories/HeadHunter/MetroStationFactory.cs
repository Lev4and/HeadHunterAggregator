using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IMetroStationFactory : IFactory<ResponseModels.MetroStation?, Entities.MetroStation?>
    {

    }

    internal class MetroStationFactory : IMetroStationFactory
    {
        public Entities.MetroStation? Create(ResponseModels.MetroStation? input)
        {
            if (input == null) return null;

            return new Entities.MetroStation
            {
                HeadHunterId = input.Id, 
                Order = input.Order, 
                Name = input.Name, 
                Latitude = input.Latitude, 
                Longitude = input.Longitude
            };
        }
    }
}
