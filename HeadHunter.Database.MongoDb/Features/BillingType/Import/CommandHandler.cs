using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.BillingType.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.BillingType>, IImporter<Collections.BillingType, Models.BillingType>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.BillingType> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.BillingType> ImportAsync(Models.BillingType model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.BillingType> FindAsync(Models.BillingType model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.BillingType> SaveAsync(Models.BillingType model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
