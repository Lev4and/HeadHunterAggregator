using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class DepartmentMapper : IDepartmentMapper
    {
        public Department Map(DepartmentDto dto)
        {
            return new Department
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
