using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IAddressFactory : IFactory<ResponseModels.Address?, Entities.Address?>
    {

    }

    internal class AddressFactory : IAddressFactory
    {
        public Entities.Address? Create(ResponseModels.Address? input)
        {
            if (input == null) return null;

            return new Entities.Address
            {
                City = input.City, 
                Street = input.Street, 
                Building = input.Building, 
                Description = input.Description,
                Latitude = input.Latitude, 
                Longitude = input.Longitude
            };
        }
    }
}
