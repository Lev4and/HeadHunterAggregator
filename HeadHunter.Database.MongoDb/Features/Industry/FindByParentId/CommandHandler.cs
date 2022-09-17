using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Industry.FindByParentId
{
    public class CommandHandler : IRequestHandler<Command, Collections.Industry?>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Industry?> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Industry>(industry => industry.HeadHunterId == request.ParentId);
        }
    }
}
