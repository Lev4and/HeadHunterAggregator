using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.MetroStation>, IImporter<Collections.MetroStation, Models.MetroStation>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.MetroStation> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.MetroStation> ImportAsync(Models.MetroStation model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.MetroStation> FindAsync(Models.MetroStation model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.MetroStation> SaveAsync(Models.MetroStation model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
