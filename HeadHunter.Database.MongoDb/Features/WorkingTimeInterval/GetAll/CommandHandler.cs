using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.WorkingTimeInterval>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Collections.WorkingTimeInterval>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync<Collections.WorkingTimeInterval>();
        }
    }
}
