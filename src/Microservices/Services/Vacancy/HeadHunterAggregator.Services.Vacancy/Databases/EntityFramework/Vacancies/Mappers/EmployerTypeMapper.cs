using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class EmployerTypeMapper : IEmployerTypeMapper
    {
        public EmployerType Map(EmployerTypeDto dto)
        {
            return new EmployerType
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
