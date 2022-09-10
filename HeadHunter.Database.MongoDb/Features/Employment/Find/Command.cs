using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Employment.Find
{
    public class Command : IRequest<Collections.Employment>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
