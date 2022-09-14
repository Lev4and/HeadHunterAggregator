using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.ProfessionalRole>, IImporter<Collections.ProfessionalRole, Models.ProfessionalRole>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.ProfessionalRole> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.ProfessionalRole> ImportAsync(Models.ProfessionalRole model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.ProfessionalRole> FindAsync(Models.ProfessionalRole model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.ProfessionalRole> SaveAsync(Models.ProfessionalRole model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
