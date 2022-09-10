using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Address.Find
{
    public class Command : IRequest<Collections.Address>
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public Command(string city, string street, string building)
        {
            City = city;
            Street = street;
            Building = building;
        }
    }
}
