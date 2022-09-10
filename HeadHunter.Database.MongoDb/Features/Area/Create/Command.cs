using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Area.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Area Area { get; }

        public Command(Collections.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }

            Area = area;
        }
    }
}
