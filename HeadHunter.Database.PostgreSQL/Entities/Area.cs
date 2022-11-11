using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Area
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string HeadHunterId { get; set; }

        public string? HeadHunterParentId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Area? Parent { get; set; }

        public virtual ICollection<Area>? Children { get; set; }

        public virtual ICollection<Vacancy>? Vacancies { get; set; }

        public virtual ICollection<Employer>? Employers { get; set; }

        public virtual ICollection<MetroLine>? MetroLines { get; set; }

        public Area()
        {

        }

        public Area(Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }

            HeadHunterId = area.Id;
            HeadHunterParentId = area.ParentId;
            Name = area.Name;
        }
    }
}
