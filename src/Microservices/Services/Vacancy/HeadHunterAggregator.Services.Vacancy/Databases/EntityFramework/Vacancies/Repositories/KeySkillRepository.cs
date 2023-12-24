using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class KeySkillRepository : VacanciesDbRepository<KeySkill>, IKeySkillRepository
    {
        public KeySkillRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}