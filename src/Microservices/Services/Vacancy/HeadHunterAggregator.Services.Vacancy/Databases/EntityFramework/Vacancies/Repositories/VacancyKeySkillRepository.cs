using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyKeySkillRepository : VacanciesDbRepository<VacancyKeySkill>, IVacancyKeySkillRepository
    {
        public VacancyKeySkillRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}