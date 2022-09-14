using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Create.Builders
{
    public class SpecializationBuilder : DocumentBuilder<Collections.Specialization>
    {
        public SpecializationBuilder(IMediator mediator, Collections.Specialization specialization) : base(mediator, specialization)
        {

        }

        public SpecializationBuilder WithParentId()
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
