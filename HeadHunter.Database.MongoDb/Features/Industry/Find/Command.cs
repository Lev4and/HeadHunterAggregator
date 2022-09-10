using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Industry.Find
{
    public class Command : IRequest<Collections.Industry>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
