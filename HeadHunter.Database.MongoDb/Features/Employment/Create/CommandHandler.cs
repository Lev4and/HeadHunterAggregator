using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employment.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Employment>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Employment> Handle(Command request, CancellationToken cancellationToken)
        {
            var employment = new Collections.Employment(request.Employment);

            await _repository.AddAsync(employment);

            return employment;
        }
    }
}
