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
        }

        public async Task<List<Collections.Vacancy>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.Aggregate<Collections.Vacancy>()
                .WithAll(_repository)
                .Project<Collections.Vacancy>(Builders<Collections.Vacancy>.Projection.WithoutDescriptions())
                .Skip((request.Page - 1) * request.PerPage)
                .Limit(request.PerPage)
                .ToListAsync();
        }
    }
}
