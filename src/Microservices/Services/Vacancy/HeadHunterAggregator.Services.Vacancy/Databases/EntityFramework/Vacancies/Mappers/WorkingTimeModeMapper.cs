using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class WorkingTimeModeMapper : IWorkingTimeModeMapper
    {
        public WorkingTimeMode Map(WorkingTimeModeDto dto)
        {
            return new WorkingTimeMode
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
