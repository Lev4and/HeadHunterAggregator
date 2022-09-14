using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.DriverLicenseType>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.DriverLicenseType> Handle(Command request, CancellationToken cancellationToken)
        {
            var driverLicenseType = new Collections.DriverLicenseType(request.DriverLicenseType);

            await _repository.AddAsync(driverLicenseType);

            return driverLicenseType;
        }
    }
}
