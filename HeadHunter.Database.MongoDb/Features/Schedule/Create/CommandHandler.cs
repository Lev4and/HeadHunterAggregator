using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Schedule.Create
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
            var schedule = new Collections.Schedule(request.Schedule);

            await _repository.AddAsync(schedule);

            return schedule;
        }
    }
}
