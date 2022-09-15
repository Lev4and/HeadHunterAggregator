using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.Create
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
            var workingDay = new Collections.WorkingDay(request.WorkingDay);

            await _repository.AddAsync(workingDay);

            return workingDay;
        }
    }
}
