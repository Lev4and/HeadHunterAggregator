using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Experience.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Experience>, IImporter<Collections.Experience, Models.Experience>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Experience> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Experience> ImportAsync(Models.Experience model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Experience> FindAsync(Models.Experience model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Experience> SaveAsync(Models.Experience model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
