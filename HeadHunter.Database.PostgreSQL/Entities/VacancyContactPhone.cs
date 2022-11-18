namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyContactPhone
    {
        public Guid Id { get; set; }

        public Guid ContactId { get; set; }

        public Guid PhoneId { get; set; }

        public virtual VacancyContact? Contact { get; set; }

        public virtual Phone? Phone { get; set; }
    }
}
