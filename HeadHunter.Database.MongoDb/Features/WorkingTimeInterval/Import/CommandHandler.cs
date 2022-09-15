using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.WorkingTimeInterval>, IImporter<Collections.WorkingTimeInterval, Models.WorkingTimeInterval>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.WorkingTimeInterval> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.WorkingTimeInterval> ImportAsync(Models.WorkingTimeInterval model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.WorkingTimeInterval> FindAsync(Models.WorkingTimeInterval model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.WorkingTimeInterval> SaveAsync(Models.WorkingTimeInterval model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
