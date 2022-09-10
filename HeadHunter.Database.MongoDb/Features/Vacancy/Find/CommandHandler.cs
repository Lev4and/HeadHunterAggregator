using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Vacancy>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Vacancy> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Vacancy>(vacancy => vacancy.HeadHunterId == request.HeadHunterId);
        }
    }
}
