using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Industry.Create.Builders
{
    public class IndustryBuilder : DocumentBuilder<Collections.Industry>
    {
        public IndustryBuilder(IMediator mediator, Collections.Industry industry) : base(mediator, industry)
        {

        }

        public IndustryBuilder WithParentId()
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
