using MediatR;

namespace HeadHunter.Database.PostgreSQL.Features.Address.Create
{
    public class Command : IRequest<Entities.Address>
    {
        public Models.Address Address { get; }

        public Command(Models.Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            Address = address;
        }
    }
}
