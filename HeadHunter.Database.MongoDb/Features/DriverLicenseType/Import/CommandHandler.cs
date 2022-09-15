using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.DriverLicenseType>, IImporter<Collections.DriverLicenseType, Models.DriverLicenseType>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.DriverLicenseType> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.DriverLicenseType> ImportAsync(Models.DriverLicenseType model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.DriverLicenseType> FindAsync(Models.DriverLicenseType model)
        {
            return await _mediator.Send(new Find.Command(model.Id));
        }

        public async Task<Collections.DriverLicenseType> SaveAsync(Models.DriverLicenseType model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
