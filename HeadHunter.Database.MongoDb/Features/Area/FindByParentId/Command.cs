using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Area.FindByParentId
{
    public class Command : IRequest<Collections.Area?>
    {
        public string? ParentId { get; set; }

        public Command(string? parentId)
        {
            ParentId = parentId;
        }
    }
}
