using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Area.Create.Builders
{
    public class AreaBuilder : DocumentBuilder<Collections.Area>
    {
        public AreaBuilder(IMediator mediator, Collections.Area area): base(mediator, area)
        {

        }

        public AreaBuilder WithParentId()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var findByParentIdCommand = new FindByParentId.Command(Document.HeadHunterParentId);
                var areaByParentId = await Mediator.Send(findByParentIdCommand);

                Document.ParentId = areaByParentId?.Id;
            }));

            return this;
        }
    }
}
