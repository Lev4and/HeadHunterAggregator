using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Currency.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.Currency Currency { get; }

        public Command(Models.Currency currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            Currency = currency;
        }
    }
}
