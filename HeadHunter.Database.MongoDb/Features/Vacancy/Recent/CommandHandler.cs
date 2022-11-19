using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Collections.Extensions.Projection;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Recent
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
            return await _repository.Aggregate<Collections.Vacancy>()
                .SortByDescending(vacancy => vacancy.InitialCreatedAt)
                .Limit(request.Limit)
                .WithArea().WithCurrency().WithEmployer()
                .Project<Collections.Vacancy>(Builders<Collections.Vacancy>.Projection.WithoutDescriptions())
                .ToListAsync();
        }
    }
}
