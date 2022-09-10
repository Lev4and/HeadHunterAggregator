using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.DriverLicenseType DriverLicenseType { get; }

        public Command(Collections.DriverLicenseType driverLicenseType)
        {
            if (driverLicenseType == null)
            {
                throw new ArgumentNullException(nameof(driverLicenseType));
            }

            DriverLicenseType = driverLicenseType;
        }
    }
}
