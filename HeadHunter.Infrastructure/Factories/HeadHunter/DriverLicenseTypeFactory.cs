using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IDriverLicenseTypeFactory : IFactory<ResponseModels.DriverLicenseType?, 
        Entities.DriverLicenseType?>
    {

    }

    internal class DriverLicenseTypeFactory : IDriverLicenseTypeFactory
    {
        public Entities.DriverLicenseType? Create(ResponseModels.DriverLicenseType? input)
        {
            if (input == null) return null;

            return new Entities.DriverLicenseType
            {
                HeadHunterId = input.Id, 
                Name = input.Id
            };
        }
    }
}
