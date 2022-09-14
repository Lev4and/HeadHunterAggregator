using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Industry.FindByParentId
{
    public class Command : IRequest<Collections.Industry?>
    {
        public string? ParentId { get; set; }

        public Command(string? parentId)
        {
            ParentId = parentId;
        }
    }
}
