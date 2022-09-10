using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Employer.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Employer>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Employer> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Employer>(employer => employer.HeadHunterId == request.HeadHunterId);
        }
    }
}
