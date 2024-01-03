using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class EmployerLogoMapper : IEmployerLogoMapper
    {
        public EmployerLogo Map(LogoUrlsDto dto)
        {
            return new EmployerLogo
            {
                Small = dto.Small,
                Normal = dto.Normal,
                Original = dto.Original
            };
        }
    }
}
