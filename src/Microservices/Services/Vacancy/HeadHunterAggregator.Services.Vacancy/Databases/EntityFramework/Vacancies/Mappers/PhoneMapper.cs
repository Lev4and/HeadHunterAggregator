using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class PhoneMapper : IPhoneMapper
    {
        public Phone Map(PhoneDto dto)
        {
            return new Phone
            {
                City = dto.City,
                Number = dto.Number,
                Comment = dto.Comment,
                Country = dto.Country
            };
        }
    }
}
