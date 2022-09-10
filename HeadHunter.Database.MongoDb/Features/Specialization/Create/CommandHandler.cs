using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Create
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
            var specialization = request.Specialization;

            await _repository.SaveAsync(specialization);

            return specialization.Id;
        }
    }
}
