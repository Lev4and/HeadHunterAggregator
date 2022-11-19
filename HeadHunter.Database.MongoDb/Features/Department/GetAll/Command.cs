using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Department.GetAll
{
    public class Command : IRequest<List<Collections.Department>>
    {

    }
}
