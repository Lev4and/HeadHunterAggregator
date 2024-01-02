using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class BillingTypeMapper : IBillingTypeMapper
    {
        public BillingType Map(BillingTypeDto dto)
        {
            return new BillingType
            {
                HeadHunterId = dto.Id,
                Name = dto.Name
            };
        }
    }
}
