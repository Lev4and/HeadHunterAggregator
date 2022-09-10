using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.KeySkill.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.KeySkill>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.KeySkill> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.KeySkill>(keySkill => keySkill.Name == request.Name);
        }
    }
}
