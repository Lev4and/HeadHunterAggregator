using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Department.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Department>, IImporter<Collections.Department, Models.Department>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Department> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Department> ImportAsync(Models.Department model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Department> FindAsync(Models.Department model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Department> SaveAsync(Models.Department model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
