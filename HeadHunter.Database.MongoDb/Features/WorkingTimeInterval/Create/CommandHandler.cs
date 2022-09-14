using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.WorkingTimeInterval>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.WorkingTimeInterval> Handle(Command request, CancellationToken cancellationToken)
        {
            var workingTimeInterval = new Collections.WorkingTimeInterval(request.WorkingTimeInterval);

            await _repository.AddAsync(workingTimeInterval);

            return workingTimeInterval;
        }
    }
}
