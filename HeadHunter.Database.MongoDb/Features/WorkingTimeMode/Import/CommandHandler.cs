using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeMode.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.WorkingTimeMode>, IImporter<Collections.WorkingTimeMode, Models.WorkingTimeMode>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.WorkingTimeMode> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.WorkingTimeMode> ImportAsync(Models.WorkingTimeMode model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.WorkingTimeMode> FindAsync(Models.WorkingTimeMode model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.WorkingTimeMode> SaveAsync(Models.WorkingTimeMode model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
