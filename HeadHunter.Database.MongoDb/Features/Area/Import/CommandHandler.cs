using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Area.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Area>, IImporter<Collections.Area, Models.Area>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Area> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Area> ImportAsync(Models.Area model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Area> FindAsync(Models.Area model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Area> SaveAsync(Models.Area model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
