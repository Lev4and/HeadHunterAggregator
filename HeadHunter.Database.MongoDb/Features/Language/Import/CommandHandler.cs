using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Language.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Language>, IImporter<Collections.Language, Models.Language>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Language> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Language> ImportAsync(Models.Language model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Language> FindAsync(Models.Language model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Language> SaveAsync(Models.Language model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
