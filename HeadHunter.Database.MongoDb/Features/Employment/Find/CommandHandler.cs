using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Employment.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Employment>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Employment> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Employment>(employment => employment.HeadHunterId == request.HeadHunterId &&
                employment.Name == request.Name);
        }
    }
}
