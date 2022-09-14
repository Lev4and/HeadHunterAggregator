using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.KeySkill.Create
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
            var keySkill = new Collections.KeySkill(request.KeySkill);

            await _repository.AddAsync(keySkill);

            return keySkill;
        }
    }
}
