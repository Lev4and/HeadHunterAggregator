using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class LanguageMapper : ILanguageMapper
    {
        public Language Map(LanguageDto dto)
        {
            return new Language
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
