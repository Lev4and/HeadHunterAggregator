using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class MetroStationMapper : IMetroStationMapper
    {
        public MetroStation Map(MetroStationDto dto)
        {
            return new MetroStation
            {
                Order = dto.Order,
                HeadHunterId = dto.Id,
                Name = dto.Name,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };
        }
    }
}
