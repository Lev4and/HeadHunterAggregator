using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Import
{
    public class CommandHandler : IRequestHandler<Command, Collections.Vacancy>, IImporter<Collections.Vacancy, Models.Vacancy>
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Collections.Vacancy> Handle(Command request, CancellationToken cancellationToken)
        {
            return await ImportAsync(request.Model);
        }

        public async Task<Collections.Vacancy> ImportAsync(Models.Vacancy model)
        {
            return (await FindAsync(model)) ?? await SaveAsync(model);
        }

        public async Task<Collections.Vacancy> FindAsync(Models.Vacancy model)
        {
            return await _mediator.Send(new Find.Command(Convert.ToInt64(model.Id)));
        }

        public async Task<Collections.Vacancy> SaveAsync(Models.Vacancy model)
        {
            return await _mediator.Send(new Create.Command(model));
        }
    }
}
