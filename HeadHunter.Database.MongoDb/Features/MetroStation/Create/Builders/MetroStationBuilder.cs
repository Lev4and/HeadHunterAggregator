using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.Create.Builders
{
    public class MetroStationBuilder : DocumentBuilder<Collections.MetroStation>
    {
        public MetroStationBuilder(IMediator mediator, Collections.MetroStation metroStation) : base(mediator, metroStation)
        {

        }

        public MetroStationBuilder WithMetroLineId()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var metroLineByIdCommand = new MetroLineById.Command(Document.LineId);
                var metroLineById = await Mediator.Send(metroLineByIdCommand);

                Document.MetroLineId = metroLineById.Id;
            }));

            return this;
        }
    }
}
