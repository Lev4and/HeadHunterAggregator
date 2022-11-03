namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class MetroLine
    {
        public Guid Id { get; set; }

        public Guid? AreaId { get; set; }

        public string HeadHunterId { get; set; }

        public string Name { get; set; }

        public string? CityId { get; set; }

        public string? HexColor { get; set; }

        public virtual Area? Area { get; set; }

        public virtual ICollection<MetroStation>? Stations { get; set; }
    }
}
