using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class IndustryMapper : IIndustryMapper
    {
        public Industry Map(IndustryDto dto)
        {
            return new Industry
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
