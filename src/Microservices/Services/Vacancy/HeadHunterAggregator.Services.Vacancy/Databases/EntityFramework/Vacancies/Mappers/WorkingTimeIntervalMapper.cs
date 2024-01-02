using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class WorkingTimeIntervalMapper : IWorkingTimeIntervalMapper
    {
        public WorkingTimeInterval Map(WorkingTimeIntervalDto dto)
        {
            return new WorkingTimeInterval
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
