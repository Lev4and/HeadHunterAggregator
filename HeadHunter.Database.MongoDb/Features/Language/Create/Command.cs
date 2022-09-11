using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Language.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.Language Language { get; }

        public Command(Models.Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            Language = language;
        }
    }
}
