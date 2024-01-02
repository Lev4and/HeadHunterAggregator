using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class ExperienceMapper : IExperienceMapper
    {
        public Experience Map(ExperienceDto dto)
        {
            return new Experience
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
