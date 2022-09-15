using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.Find
{
    public class Command : IRequest<Collections.MetroLine>
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
