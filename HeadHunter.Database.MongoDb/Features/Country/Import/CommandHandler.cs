using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Country.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Country>, IImporter<Collections.Country, Models.Country>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Country> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Country> ImportAsync(Models.Country model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Country> FindAsync(Models.Country model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Country> SaveAsync(Models.Country model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
