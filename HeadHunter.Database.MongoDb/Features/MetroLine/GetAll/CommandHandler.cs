using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.MetroLine>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;

            MetroLineAggregateExtensions.Init(_repository);
        }

        public async Task<List<Collections.MetroLine>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.Aggregate<Collections.MetroLine>()
                .WithArea()
                .WithStations()
                .SortBy(metroLine => metroLine.Name)
                .ToListAsync();
        }
    }
}
