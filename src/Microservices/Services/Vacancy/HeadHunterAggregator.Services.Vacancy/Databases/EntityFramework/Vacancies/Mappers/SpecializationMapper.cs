using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class SpecializationMapper : ISpecializationMapper
    {
        public Specialization Map(SpecializationDto dto)
        {
            return new Specialization
            {
                Laboring = dto.Laboring,
                Name = dto.Name,
                HeadHunterId = dto.Id
            };
        }
    }
}
