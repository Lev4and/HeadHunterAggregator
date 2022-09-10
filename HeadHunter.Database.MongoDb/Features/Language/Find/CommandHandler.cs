using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Language.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Language>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Language> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Language>(language => language.HeadHunterId == request.HeadHunterId &&
                language.Name == request.Name);
        }
    }
}
