using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.Industry.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.Industry>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Collections.Industry>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.Aggregate<Collections.Industry>()
                .WithChildren(_repository.GetCollection<Collections.Industry>())
                .SortBy(industry => industry.Name)
                .ToListAsync();
        }
    }
}
