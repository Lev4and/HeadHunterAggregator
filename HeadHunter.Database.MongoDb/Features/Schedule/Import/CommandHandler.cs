using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Schedule.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Schedule>, IImporter<Collections.Schedule, Models.Schedule>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Schedule> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Schedule> ImportAsync(Models.Schedule model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Schedule> FindAsync(Models.Schedule model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Schedule> SaveAsync(Models.Schedule model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
