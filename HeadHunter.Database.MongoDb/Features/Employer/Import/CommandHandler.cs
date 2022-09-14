using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Employer.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Employer>, IImporter<Collections.Employer, Models.Employer>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Employer> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Employer> ImportAsync(Models.Employer model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Employer> FindAsync(Models.Employer model)
        {
            return await _mediator.Send(new Find.Command(Convert.ToInt64(model.Id)));
        }

        public async Task<Collections.Employer> SaveAsync(Models.Employer model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
