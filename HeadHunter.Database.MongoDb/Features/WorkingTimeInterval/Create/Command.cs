using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.WorkingTimeInterval WorkingTimeInterval { get; }

        public Command(Collections.WorkingTimeInterval workingTimeInterval)
        {
            if (workingTimeInterval == null)
            {
                throw new ArgumentNullException(nameof(workingTimeInterval));
            }

            WorkingTimeInterval = workingTimeInterval;
        }
    }
}
