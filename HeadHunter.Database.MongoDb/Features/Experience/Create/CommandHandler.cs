using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Experience.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Experience>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Experience> Handle(Command request, CancellationToken cancellationToken)
        {
            var experience = new Collections.Experience(request.Experience);

            await _repository.AddAsync(experience);

            return experience;
        }
    }
}
