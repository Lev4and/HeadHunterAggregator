using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.BillingType.Create
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
            var billingType = new Collections.BillingType(request.BillingType);

            await _repository.AddAsync(billingType);

            return billingType;
        }
    }
}
