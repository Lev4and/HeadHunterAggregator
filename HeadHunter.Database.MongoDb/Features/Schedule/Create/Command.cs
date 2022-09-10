using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Schedule.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Schedule Schedule { get; }

        public Command(Collections.Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            Schedule = schedule;
        }
    }
}
