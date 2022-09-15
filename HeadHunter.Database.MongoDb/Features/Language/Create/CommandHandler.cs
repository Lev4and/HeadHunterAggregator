using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Language.Create
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
            var language = new Collections.Language(request.Language);

            await _repository.AddAsync(language);

            return language;
        }
    }
}
