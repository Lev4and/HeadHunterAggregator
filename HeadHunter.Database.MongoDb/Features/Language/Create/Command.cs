using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Language.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Language Language { get; }

        public Command(Collections.Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            Language = language;
        }
    }
}
