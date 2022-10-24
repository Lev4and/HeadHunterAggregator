using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Currency.GetAll
{
    public class Command : IRequest<List<Collections.Currency>>
    {

    }
}
