using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Currency.Find
{
    public class Command : IRequest<Collections.Currency>
    {
        public string HeadHunterId { get; set; }
    }
}
