using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class VacancyDescriptionMapper : IVacancyDescriptionMapper
    {
        public VacancyDescription Map(VacancyDto dto)
        {
            return new VacancyDescription
            {
                Description = dto.Description
            };
        }
    }
}
