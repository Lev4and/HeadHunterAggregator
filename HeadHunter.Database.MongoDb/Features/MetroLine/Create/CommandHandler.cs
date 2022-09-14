using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.MetroLine>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.MetroLine> Handle(Command request, CancellationToken cancellationToken)
        {
            var metroLine = new Collections.MetroLine(request.MetroLine);

            await _repository.AddAsync(metroLine);

            return metroLine;
        }
    }
}
