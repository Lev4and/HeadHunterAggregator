using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class ProfessionalRoleMapper : IProfessionalRoleMapper
    {
        public ProfessionalRole Map(ProfessionalRoleDto dto)
        {
            return new ProfessionalRole
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
