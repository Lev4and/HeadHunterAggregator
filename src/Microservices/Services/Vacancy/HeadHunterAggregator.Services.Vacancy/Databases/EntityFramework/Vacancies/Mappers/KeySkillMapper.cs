using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class KeySkillMapper : IKeySkillMapper
    {
        public KeySkill Map(KeySkillDto dto)
        {
            return new KeySkill
            {
                HeadHunterId = dto.Name,
                Name = dto.Name
            };
        }
    }
}
