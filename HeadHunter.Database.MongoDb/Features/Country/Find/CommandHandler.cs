using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Country.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Country>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Country> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Country>(country => country.HeadHunterId == request.HeadHunterId &&
                country.Name == request.Name);
        }
    }
}
