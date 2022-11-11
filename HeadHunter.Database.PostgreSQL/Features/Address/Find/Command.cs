using MediatR;

namespace HeadHunter.Database.PostgreSQL.Features.Address.Find
{
    public class Command : IRequest<Entities.Address?>
    {
        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Building { get; set; }

        public string? Description { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
