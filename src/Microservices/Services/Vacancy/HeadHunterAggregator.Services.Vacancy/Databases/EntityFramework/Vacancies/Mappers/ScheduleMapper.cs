using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class ScheduleMapper : IScheduleMapper
    {
        public Schedule Map(ScheduleDto dto)
        {
            return new Schedule
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
