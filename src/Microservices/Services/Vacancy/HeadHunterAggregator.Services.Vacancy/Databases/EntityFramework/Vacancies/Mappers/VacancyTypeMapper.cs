using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class VacancyTypeMapper : IVacancyTypeMapper
    {
        public VacancyType Map(VacancyTypeDto dto)
        {
            return new VacancyType 
            { 
                HeadHunterId = dto.Id, 
                Name = dto.Name 
            };
        }
    }
}
