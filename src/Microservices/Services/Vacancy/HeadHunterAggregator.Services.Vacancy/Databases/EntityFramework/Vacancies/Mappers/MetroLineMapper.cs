using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class MetroLineMapper : IMetroLineMapper
    {
        public MetroLine Map(MetroLineDto dto)
        {
            return new MetroLine
            {
                HeadHunterId = dto.Id,
                Name = dto.Name,
                HexColor = dto.HexColor
            };
        }
    }
}
