using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.WorkingDay>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Collections.WorkingDay>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync<Collections.WorkingDay>();
        }
    }
}
