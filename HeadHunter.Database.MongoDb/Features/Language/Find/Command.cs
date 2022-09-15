using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Language.Find
{
    public class Command : IRequest<Collections.Language>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }

        public Command(string name, string headHunterId)
        {
            Name = name;
            HeadHunterId = headHunterId;
        }
    }
}
