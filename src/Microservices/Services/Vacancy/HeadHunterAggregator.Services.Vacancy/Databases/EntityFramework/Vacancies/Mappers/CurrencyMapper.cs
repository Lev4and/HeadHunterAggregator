using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class CurrencyMapper : ICurrencyMapper
    {
        public Currency Map(CurrencyDto dto)
        {
            return new Currency
            {
                HeadHunterId = dto.Code
            };
        }
    }
}
