using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Suggests.Main
{
    public class CommandHandler : IRequestHandler<Command, List<string>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var suggestsVacancies = await _repository.GetCollection<Collections.Vacancy>()
                .Find(Builders<Collections.Vacancy>.Filter.Regex("name", new BsonRegularExpression(request.SearchString)))
                .SortBy(vacancy => vacancy.Name)
                .Project(vacancy => vacancy.Name)
                .Limit(10)
                .ToListAsync();

            return suggestsVacancies;
        }
    }
}
