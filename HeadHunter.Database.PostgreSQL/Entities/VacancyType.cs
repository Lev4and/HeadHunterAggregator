namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyType
    {
        public Guid Id { get; set; }

        public string HeadHunterId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Vacancy>? Vacancies { get; set; }
    }
}
