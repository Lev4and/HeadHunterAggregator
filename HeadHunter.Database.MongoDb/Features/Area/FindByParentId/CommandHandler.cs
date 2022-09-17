using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Area.FindByParentId
{
    public class CommandHandler : IRequestHandler<Command, Collections.Area?>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Area?> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Area>(area => area.HeadHunterId == request.ParentId);
        }
    }
}
