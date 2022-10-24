using MediatR;

namespace HeadHunter.Database.MongoDb.Features.BillingType.GetAll
{
    public class Command : IRequest<List<Collections.BillingType>>
    {

    }
}
