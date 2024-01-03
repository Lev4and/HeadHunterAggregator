using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class VacancyContactMapper : IVacancyContactMapper
    {
        public VacancyContact Map(ContactsDto dto)
        {
            return new VacancyContact
            {
                Name = dto.Name,
                Email = dto.Email
            };
        }
    }
}
