using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Employment.GetAll
{
    public class Command : IRequest<List<Collections.Employment>>
    {

    }
}
