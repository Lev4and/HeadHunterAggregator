using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Specialization>, IImporter<Collections.Specialization, Models.Specialization>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Specialization> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Specialization> ImportAsync(Models.Specialization model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Specialization> FindAsync(Models.Specialization model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.Specialization> SaveAsync(Models.Specialization model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
