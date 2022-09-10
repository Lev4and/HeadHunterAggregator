using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Create
{
    public class CommandHandler : IRequestHandler<Command, ObjectId>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<ObjectId> Handle(Command request, CancellationToken cancellationToken)
        {
            var driverLicenseType = request.DriverLicenseType;

            await _repository.SaveAsync(driverLicenseType);

            return driverLicenseType.Id;
        }
    }
}
