using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.Find
{
    public class Command : IRequest<Collections.WorkingDay>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
