using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.CountActive
{
    public class CommandHandler : IRequestHandler<Command, long>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.GetCollection<Collections.Vacancy>()
                .CountDocumentsAsync(vacancy => vacancy.Archived != true);
        }
    }
}
