using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class EmployerMapper : IEmployerMapper
    {
        public Employer Map(EmployerDto dto)
        {
            return new Employer
            {
                Name = dto.Name,
                Url = dto.Url,
                AlternateUrl = dto.AlternateUrl,
                HeadHunterId = dto.Id,
                Trusted = dto.Trusted,
                Blacklisted = dto.Blacklisted,
                SiteUrl = dto.SiteUrl,
                VacanciesUrl = dto.VacanciesUrl
            };
        }
    }
}
