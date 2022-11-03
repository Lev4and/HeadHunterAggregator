using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Collections.Extensions.Projection;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Filter
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.Vacancy>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;

            VacancyAggregateExtensions.Init(_repository);
        }

        public async Task<List<Collections.Vacancy>> Handle(Command request, CancellationToken cancellationToken)
        {
            var filterBuilder = Builders<Collections.Vacancy>.Filter;

            return await _repository.Aggregate<Collections.Vacancy>()
                .WithAll()
                .Match(filterBuilder.Or(filterBuilder.Regex(vacancy => vacancy.Name, request.SearchString)))
                .Project<Collections.Vacancy>(Builders<Collections.Vacancy>.Projection.WithoutDescriptions())
                .Skip((request.Page - 1) * request.PerPage)
                .Limit(request.PerPage)
                .ToListAsync();
        }
    }
}
