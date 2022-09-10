using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.WorkingDay WorkingDay { get; }

        public Command(Collections.WorkingDay workingDay)
        {
            if (workingDay == null)
            {
                throw new ArgumentNullException(nameof(workingDay));
            }

            WorkingDay = workingDay;
        }
    }
}
