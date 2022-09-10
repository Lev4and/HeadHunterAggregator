using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Find
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
            return await _repository.FirstAsync<Collections.DriverLicenseType>(driverLicenseType => driverLicenseType.HeadHunterId == request.HeadHunterId);
        }
    }
}
