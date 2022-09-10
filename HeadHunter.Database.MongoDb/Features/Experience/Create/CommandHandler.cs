using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Experience.Create
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
            var experience = request.Experience;

            await _repository.SaveAsync(experience);

            return experience.Id;
        }
    }
}
