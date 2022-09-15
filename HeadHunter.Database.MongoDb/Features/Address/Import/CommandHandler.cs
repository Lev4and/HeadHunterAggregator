using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Address.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Address>, IImporter<Collections.Address, Models.Address>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Address> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Address> ImportAsync(Models.Address model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Address> FindAsync(Models.Address model)
        {
            return await _mediator.Send(new Find.Command(model.City, model.Street, model.Building));
        }

        public async Task<Collections.Address> SaveAsync(Models.Address model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
