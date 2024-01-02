using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class AreaMapper : IAreaMapper
    {
        public Area Map(AreaDto dto)
        {
            return new Area
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
