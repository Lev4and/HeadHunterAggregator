using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Specialization.FindByParentId
{
    public class Command : IRequest<Collections.Specialization?>
    {
        public string? ParentId { get; set; }

        public Command(string? parentId)
        {
            ParentId = parentId;
        }
    }
}
