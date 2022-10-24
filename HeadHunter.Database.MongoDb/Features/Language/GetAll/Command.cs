using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Language.GetAll
{
    public class Command : IRequest<List<Collections.Language>>
    {

    }
}
