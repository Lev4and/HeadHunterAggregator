using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Create
{
    public class Command : IRequest<Collections.DriverLicenseType>
    {
        public Models.DriverLicenseType DriverLicenseType { get; }

        public Command(Models.DriverLicenseType driverLicenseType)
        {
            if (driverLicenseType == null)
            {
                throw new ArgumentNullException(nameof(driverLicenseType));
            }

            DriverLicenseType = driverLicenseType;
        }
    }
}
