using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class AddressMapper : IAddressMapper
    {
        public Address Map(AddressDto dto)
        {
            return new Address
            {
                City = dto.City,
                Street = dto.Street,
                Building = dto.Building,
                Description = dto.Description,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };
        }
    }
}
