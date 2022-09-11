using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.VacancyType.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.VacancyType VacancyType { get; }

        public Command(Models.VacancyType vacancyType)
        {
            if (vacancyType == null)
            {
                throw new ArgumentNullException(nameof(vacancyType));
            }

            VacancyType = vacancyType;
        }
    }
}
