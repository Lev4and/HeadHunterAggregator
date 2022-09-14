using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Create
{
    public class Command : IRequest<Collections.WorkingTimeInterval>
    {
        public Models.WorkingTimeInterval WorkingTimeInterval { get; }

        public Command(Models.WorkingTimeInterval workingTimeInterval)
        {
            if (workingTimeInterval == null)
            {
                throw new ArgumentNullException(nameof(workingTimeInterval));
            }

            WorkingTimeInterval = workingTimeInterval;
        }
    }
}
