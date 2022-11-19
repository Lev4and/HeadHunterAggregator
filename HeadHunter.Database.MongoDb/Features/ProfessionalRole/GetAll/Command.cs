using MediatR;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.GetAll
{
    public class Command : IRequest<List<Collections.ProfessionalRole>>
    {

    }
}
