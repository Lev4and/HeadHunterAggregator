using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Address.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Address>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Address> Handle(Command request, CancellationToken cancellationToken)
        {
            var address = new Collections.Address(request.Address);

            await _repository.AddAsync(address);

            return address;
        }
    }
}
