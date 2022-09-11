using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.ProfessionalRole ProfessionalRole { get; }

        public Command(Models.ProfessionalRole professionalRole)
        {
            if (professionalRole == null)
            {
                throw new ArgumentNullException(nameof(professionalRole));
            }

            ProfessionalRole = professionalRole;
        }
    }
}
