using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HeadHunter.Database.PostgreSQL.Features.Address.Find
{
    public class CommandHandler : IRequestHandler<Command, Entities.Address?>
    {
        private readonly HeadHunterDbContext _context;

        public CommandHandler(HeadHunterDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.Address?> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _context.Addresses.FirstOrDefaultAsync(item => item.City == request.City &&
                item.Street == request.Street && item.Building == request.Building && item.Latitude == request.Latitude &&
                    item.Longitude == request.Longitude);
        }
    }
}
