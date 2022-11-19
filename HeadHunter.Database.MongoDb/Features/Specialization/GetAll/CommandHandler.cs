using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Specialization.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.Specialization>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;

            SpecializationAggregateExtensions.Init(_repository);
        }

        public async Task<List<Collections.Specialization>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.Aggregate<Collections.Specialization>()
                .WithChildren()
                .SortBy(specialization => specialization.HeadHunterId)
                .ToListAsync();
        }
    }
}
