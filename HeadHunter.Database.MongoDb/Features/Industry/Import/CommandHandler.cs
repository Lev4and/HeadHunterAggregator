using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Industry.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Industry>, IImporter<Collections.Industry, Models.Industry>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Industry> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Industry> ImportAsync(Models.Industry model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Industry> FindAsync(Models.Industry model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Industry> SaveAsync(Models.Industry model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
