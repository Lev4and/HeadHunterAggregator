namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class WorkingTimeInterval
    {
        public Guid Id { get; set; }

        public string HeadHunterId { get; set; }

        public string Name { get; set; }
    }
}
