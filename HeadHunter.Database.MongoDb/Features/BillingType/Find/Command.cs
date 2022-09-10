using MediatR;

namespace HeadHunter.Database.MongoDb.Features.BillingType.Find
{
    public class Command : IRequest<Collections.BillingType>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
