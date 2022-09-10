using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.BillingType.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.BillingType>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.BillingType> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.BillingType>(billingType => billingType.HeadHunterId == request.HeadHunterId &&
                billingType.Name == request.Name);
        }
    }
}
