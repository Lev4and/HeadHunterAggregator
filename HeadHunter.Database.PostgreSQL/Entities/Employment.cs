﻿namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Employment
    {
        public Guid Id { get; set; }

        public string HeadHunterId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Vacancy>? Vacancies { get; set; }
    }
}
