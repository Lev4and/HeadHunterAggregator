using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class DriverLicenseTypeMapper : IDriverLicenseTypeMapper
    {
        public DriverLicenseType Map(DriverLicenseTypeDto dto)
        {
            return new DriverLicenseType
            {
                HeadHunterId = dto.Id
            };
        }
    }
}
