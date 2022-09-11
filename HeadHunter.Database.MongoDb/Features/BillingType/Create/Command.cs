using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.BillingType.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.BillingType BillingType { get; }

        public Command(Models.BillingType billingType)
        {
            if (billingType == null)
            {
                throw new ArgumentNullException(nameof(billingType));
            }

            BillingType = billingType;
        }
    }
}
