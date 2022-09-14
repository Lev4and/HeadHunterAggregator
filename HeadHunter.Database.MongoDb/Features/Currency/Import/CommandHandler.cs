using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Currency.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Currency>, IImporter<Collections.Currency, Models.Currency>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Currency> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Currency> ImportAsync(Models.Currency model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Currency> FindAsync(Models.Currency model)
        {
            return await _mediator.Send(new Find.Command(model.Code));
        }

        public async Task<Collections.Currency> SaveAsync(Models.Currency model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
