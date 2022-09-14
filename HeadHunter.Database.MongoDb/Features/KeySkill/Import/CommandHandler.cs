using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.KeySkill.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.KeySkill>, IImporter<Collections.KeySkill, Models.KeySkill>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.KeySkill> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.KeySkill> ImportAsync(Models.KeySkill model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.KeySkill> FindAsync(Models.KeySkill model)
        {
            return await _mediator.Send(new Find.Command(model.Name));
        }

        public async Task<Collections.KeySkill> SaveAsync(Models.KeySkill model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
