using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Specialization>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Specialization> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Specialization>(specialization => specialization.HeadHunterId == request.HeadHunterId &&
                specialization.Name == request.Name);
        }
    }
}
