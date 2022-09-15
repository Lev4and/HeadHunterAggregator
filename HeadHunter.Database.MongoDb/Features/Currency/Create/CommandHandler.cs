using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Currency.Create
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
            var currency = new Collections.Currency(request.Currency);

            await _repository.AddAsync(currency);

            return currency;
        }
    }
}
