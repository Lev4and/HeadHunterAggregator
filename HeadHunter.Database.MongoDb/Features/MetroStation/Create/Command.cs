using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.Create
{
    public class Command : IRequest<Collections.MetroStation>
    {
        public Models.MetroStation MetroStation { get; }

        public Command(Models.MetroStation metroStation)
        {
            if (metroStation == null)
            {
                throw new ArgumentNullException(nameof(metroStation));
            }

            MetroStation = metroStation;
        }
    }
}
