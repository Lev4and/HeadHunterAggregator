using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class EmployerDescriptionMapper : IEmployerDescriptionMapper
    {
        public EmployerDescription Map(EmployerDto dto)
        {
            return new EmployerDescription
            {
                Description = dto.Description
            };
        }
    }
}
