using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Experience.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.Experience>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Collections.Experience>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync<Collections.Experience>();
        }
    }
}
