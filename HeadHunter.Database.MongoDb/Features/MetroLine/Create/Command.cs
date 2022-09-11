using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.MetroLine MetroLine { get; }

        public Command(Models.MetroLine metroLine)
        {
            if (metroLine == null)
            {
                throw new ArgumentNullException(nameof(metroLine));
            }

            MetroLine = metroLine;
        }
    }
}
