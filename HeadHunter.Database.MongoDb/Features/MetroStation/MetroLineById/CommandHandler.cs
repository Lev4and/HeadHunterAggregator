using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.MetroLineById
{
    public class CommandHandler : IRequestHandler<Command, Collections.MetroLine?>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.MetroLine?> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.MetroLine>(metroLine => metroLine.HeadHunterId == request.MetroLineId);
        }
    }
}
