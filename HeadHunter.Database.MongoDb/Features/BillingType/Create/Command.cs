using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.BillingType.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.BillingType BillingType { get; }

        public Command(Collections.BillingType billingType)
        {
            if (billingType == null)
            {
                throw new ArgumentNullException(nameof(billingType));
            }

            BillingType = billingType;
        }
    }
}
