using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Create
{
    public class CommandHandler : IRequestHandler<Command, ObjectId>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<ObjectId> Handle(Command request, CancellationToken cancellationToken)
        {
            var professionalRole = request.ProfessionalRole;

            await _repository.SaveAsync(professionalRole);

            return professionalRole.Id;
        }
    }
}
