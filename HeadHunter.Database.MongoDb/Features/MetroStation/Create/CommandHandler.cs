using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Features.MetroStation.Create.Builders;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.MetroStation>
    {
        private readonly IMediator _mediator;
        private readonly Repository _repository;

        public CommandHandler(IMediator mediator, Repository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Collections.MetroStation> Handle(Command request, CancellationToken cancellationToken)
        {
            var metroStation = await new MetroStationBuilder(_mediator, new Collections.MetroStation(request.MetroStation))
                .WithMetroLineId()
                .BuildAsync();

            await _repository.AddAsync(metroStation);

            return metroStation;
        }
    }
}
