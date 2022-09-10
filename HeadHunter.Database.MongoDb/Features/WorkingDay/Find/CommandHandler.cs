using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.WorkingDay>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.WorkingDay> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.WorkingDay>(workingDay => workingDay.HeadHunterId == request.HeadHunterId &&
                workingDay.Name == request.Name);
        }
    }
}
