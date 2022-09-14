using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Create
{
    public class Command : IRequest<Collections.Vacancy>
    {
        public Models.Vacancy Vacancy { get; }

        public Command(Models.Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException(nameof(vacancy));
            }

            Vacancy = vacancy;
        }
    }
}
