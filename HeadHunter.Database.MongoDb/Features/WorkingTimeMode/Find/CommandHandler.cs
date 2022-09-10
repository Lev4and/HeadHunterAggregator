using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeMode.Find
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
            return await _repository.FirstAsync<Collections.WorkingTimeMode>(workingTimeMode => workingTimeMode.HeadHunterId == request.HeadHunterId &&
                workingTimeMode.Name == request.Name);
        }
    }
}
