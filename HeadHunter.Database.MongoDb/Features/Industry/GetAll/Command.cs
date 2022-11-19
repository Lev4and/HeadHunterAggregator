using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Industry.GetAll
{
    public class Command : IRequest<List<Collections.Industry>>
    {

    }
}
