using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Currency.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Currency>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Currency> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Currency>(currency => currency.HeadHunterId == request.HeadHunterId);
        }
    }
}
