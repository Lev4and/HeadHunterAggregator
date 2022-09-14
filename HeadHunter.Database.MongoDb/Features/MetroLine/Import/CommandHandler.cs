using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.MetroLine>, IImporter<Collections.MetroLine, Models.MetroLine>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.MetroLine> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.MetroLine> ImportAsync(Models.MetroLine model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.MetroLine> FindAsync(Models.MetroLine model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.MetroLine> SaveAsync(Models.MetroLine model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
