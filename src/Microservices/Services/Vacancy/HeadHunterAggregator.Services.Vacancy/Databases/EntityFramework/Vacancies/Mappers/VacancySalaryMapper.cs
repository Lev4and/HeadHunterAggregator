using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class VacancySalaryMapper : IVacancySalaryMapper
    {
        public VacancySalary Map(SalaryDto dto)
        {
            return new VacancySalary
            {
                Gross = dto.Gross,
                From = dto.From,
                To = dto.To
            };
        }
    }
}
