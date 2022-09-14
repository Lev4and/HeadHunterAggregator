using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Country.Create
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
            var country = new Collections.Country(request.Country);

            await _repository.AddAsync(country);

            return country;
        }
    }
}
