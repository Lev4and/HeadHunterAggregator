using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.ProfessionalRole>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.ProfessionalRole> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.ProfessionalRole>(professionalRole => professionalRole.HeadHunterId == request.HeadHunterId &&
                professionalRole.Name == request.Name);
        }
    }
}
