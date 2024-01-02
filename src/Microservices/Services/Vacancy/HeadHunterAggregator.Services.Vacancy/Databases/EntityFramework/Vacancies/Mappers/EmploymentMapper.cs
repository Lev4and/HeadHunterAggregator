using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class EmploymentMapper : IEmploymentMapper
    {
        public Employment Map(EmploymentDto dto)
        {
            return new Employment
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
