using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Experience.GetAll
{
    public class Command : IRequest<List<Collections.Experience>>
    {

    }
}
