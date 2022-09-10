using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Find
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
            return await _repository.FirstAsync<Collections.WorkingTimeInterval>(workingTimeInterval => workingTimeInterval.HeadHunterId == request.HeadHunterId &&
                workingTimeInterval.Name == request.Name);
        }
    }
}
