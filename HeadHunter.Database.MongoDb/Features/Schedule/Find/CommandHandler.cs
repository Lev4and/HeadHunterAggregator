using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Schedule.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Schedule>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Schedule> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Schedule>(schedule => schedule.HeadHunterId == request.HeadHunterId &&
                schedule.Name == request.Name);
        }
    }
}
