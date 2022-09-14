using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.VacancyType.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.VacancyType>, IImporter<Collections.VacancyType, Models.VacancyType>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.VacancyType> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.VacancyType> ImportAsync(Models.VacancyType model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.VacancyType> FindAsync(Models.VacancyType model)
        {
            return await _mediator.Send(new Find.Command(model.Name, model.Id));
        }

        public async Task<Collections.VacancyType> SaveAsync(Models.VacancyType model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
