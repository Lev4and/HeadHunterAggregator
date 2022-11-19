using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.ProfessionalRole>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Collections.ProfessionalRole>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync<Collections.ProfessionalRole>();
        }
    }
}
