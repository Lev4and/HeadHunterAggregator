using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Employer.Info
{
    public class CommandHandler : IRequestHandler<Command, Collections.Employer>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;

            EmployerAggregateExtensions.Init(_repository);
        }

        public async Task<Collections.Employer> Handle(Command request, CancellationToken cancellationToken)
        {
            var filterBuilder = Builders<Collections.Employer>.Filter;

            return await _repository.Aggregate<Collections.Employer>()
                .WithArea()
                .WithIndustries()
                .Match(filterBuilder.Eq(employer => employer.Id, request.Id))
                .FirstOrDefaultAsync();
        }
    }
}
