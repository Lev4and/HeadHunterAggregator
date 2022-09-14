using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.WorkingDay>, IImporter<Collections.WorkingDay, Models.WorkingDay>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.WorkingDay> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.WorkingDay> ImportAsync(Models.WorkingDay model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.WorkingDay> FindAsync(Models.WorkingDay model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.WorkingDay> SaveAsync(Models.WorkingDay model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
