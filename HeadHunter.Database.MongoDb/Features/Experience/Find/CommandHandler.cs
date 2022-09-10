using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Experience.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Experience>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Experience> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Experience>(experience => experience.HeadHunterId == request.HeadHunterId &&
                experience.Name == request.Name);
        }
    }
}
