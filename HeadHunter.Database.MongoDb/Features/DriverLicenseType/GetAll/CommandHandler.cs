using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.DriverLicenseType>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Collections.DriverLicenseType>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync<Collections.DriverLicenseType>();
        }
    }
}
