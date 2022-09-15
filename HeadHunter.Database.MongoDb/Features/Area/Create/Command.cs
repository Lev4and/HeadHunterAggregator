using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Area.Create
{
    public class Command : IRequest<Collections.Area>
    {
        public Models.Area Area { get; }

        public Command(Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }

            Area = area;
        }
    }
}
