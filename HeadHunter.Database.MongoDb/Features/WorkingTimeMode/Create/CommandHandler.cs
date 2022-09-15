using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeMode.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.WorkingTimeMode>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.WorkingTimeMode> Handle(Command request, CancellationToken cancellationToken)
        {
            var workingTimeMode = new Collections.WorkingTimeMode(request.WorkingTimeMode);

            await _repository.AddAsync(workingTimeMode);

            return workingTimeMode;
        }
    }
}
