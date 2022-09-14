using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Employer.Find
{
    public class Command : IRequest<Collections.Employer>
    {
        public long HeadHunterId { get; set; }

        public Command(long headHunterId)
        {
            HeadHunterId = headHunterId;
        }
    }
}
