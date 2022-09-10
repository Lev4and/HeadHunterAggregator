using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Currency.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Currency Currency { get; }

        public Command(Collections.Currency currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            Currency = currency;
        }
    }
}
