using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeMode.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.WorkingTimeMode>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Collections.WorkingTimeMode>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync<Collections.WorkingTimeMode>();
        }
    }
}
