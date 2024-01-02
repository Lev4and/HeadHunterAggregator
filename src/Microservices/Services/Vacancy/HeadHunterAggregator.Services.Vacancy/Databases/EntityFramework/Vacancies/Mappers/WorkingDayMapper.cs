using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class WorkingDayMapper : IWorkingDayMapper
    {
        public WorkingDay Map(WorkingDayDto dto)
        {
            return new WorkingDay
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
