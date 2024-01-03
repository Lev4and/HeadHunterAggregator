using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class InsiderInterviewMapper : IInsiderInterviewMapper
    {
        public InsiderInterview Map(InsiderInterviewDto dto)
        {
            return new InsiderInterview
            {
                HeadHunterId = dto.Id,
                Title = dto.Title,
                Url = dto.Url,
            };
        }
    }
}
