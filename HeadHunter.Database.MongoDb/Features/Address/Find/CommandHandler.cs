using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Address.Find
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
            return await _repository.FirstAsync<Collections.Address>(address => address.City == request.City
                && address.Street == request.Street && address.Building == request.Building);
        }
    }
}
