using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class EmployerBrandedDescriptionMapper : IEmployerBrandedDescriptionMapper
    {
        public EmployerBrandedDescription Map(EmployerDto dto)
        {
            return new EmployerBrandedDescription
            {
                Description = dto.BrandedDescription
            };
        }
    }
}
