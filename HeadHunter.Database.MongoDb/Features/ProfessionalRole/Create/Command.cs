using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.ProfessionalRole ProfessionalRole { get; }

        public Command(Collections.ProfessionalRole professionalRole)
        {
            if (professionalRole == null)
            {
                throw new ArgumentNullException(nameof(professionalRole));
            }

            ProfessionalRole = professionalRole;
        }
    }
}
