using MediatR;

namespace HeadHunter.Database.PostgreSQL.Features.Address.Create
{
    public class CommandHandler : IRequestHandler<Command, Entities.Address>
    {
        private readonly HeadHunterDbContext _context;

        public CommandHandler(HeadHunterDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.Address> Handle(Command request, CancellationToken cancellationToken)
        {
            var item = new Entities.Address(request.Address);

            await _context.Addresses.SingleInsertAsync(item);

            return item;
        }
    }
}
