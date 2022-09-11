using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeMode.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.WorkingTimeMode WorkingTimeMode { get; }

        public Command(Models.WorkingTimeMode workingTimeMode)
        {
            if (workingTimeMode == null)
            {
                throw new ArgumentNullException(nameof(workingTimeMode));
            }

            WorkingTimeMode = workingTimeMode;
        }
    }
}
