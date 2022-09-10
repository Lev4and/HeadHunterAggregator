using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Find
{
    public class Command : IRequest<Collections.Vacancy>
    {
        public long HeadHunterId { get; set; }
    }
}
