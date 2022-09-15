using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.Create
{
    public class Command : IRequest<Collections.WorkingDay>
    {
        public Models.WorkingDay WorkingDay { get; }

        public Command(Models.WorkingDay workingDay)
        {
            if (workingDay == null)
            {
                throw new ArgumentNullException(nameof(workingDay));
            }

            WorkingDay = workingDay;
        }
    }
}
