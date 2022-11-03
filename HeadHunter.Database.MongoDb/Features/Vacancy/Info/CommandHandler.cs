using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Collections.Extensions.Projection;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Info
{
    public class CommandHandler : IRequestHandler<Command, Collections.Vacancy>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;

            VacancyAggregateExtensions.Init(_repository);
        }

        public async Task<Collections.Vacancy> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await _repository.Aggregate<Collections.Vacancy>()
                .WithAll()
                .Match(vacancy => vacancy.Id == request.Id)
                .Project<Collections.Vacancy>(Builders<Collections.Vacancy>.Projection.WithoutEmployerDescriptions())
                .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}
