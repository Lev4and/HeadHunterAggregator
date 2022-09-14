using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employment.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Employment>, IImporter<Collections.Employment, Models.Employment>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Employment> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Employment> ImportAsync(Models.Employment model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Employment> FindAsync(Models.Employment model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Employment> SaveAsync(Models.Employment model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
