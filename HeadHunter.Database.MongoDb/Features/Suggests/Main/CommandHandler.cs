using HeadHunter.Database.MongoDb.Common;
using MediatR;
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
            var filterBuilder = Builders<Collections.Vacancy>.Filter;

            var suggestsVacancies = await _repository.GetCollection<Collections.Vacancy>()
                .Find(filterBuilder.Or(filterBuilder.Regex(vacancy => vacancy.Name, request.SearchString)))
                .SortBy(vacancy => vacancy.Name)
                .Project(vacancy => vacancy.Name)
                .Limit(10)
                .ToListAsync();

            return suggestsVacancies.Distinct().ToList();
        }
    }
}
