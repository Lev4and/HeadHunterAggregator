namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyRepository : VacanciesDbRepository<Entities.Vacancy>, IVacancyRepository
    {
        public VacancyRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}