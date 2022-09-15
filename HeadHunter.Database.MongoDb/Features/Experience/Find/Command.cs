using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Experience.Find
{
    public class Command : IRequest<Collections.Experience>
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
