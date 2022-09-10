using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.MetroStation>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.MetroStation> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.MetroStation>(metroStation => metroStation.HeadHunterId == request.HeadHunterId &&
                metroStation.Name == request.Name);
        }
    }
}
