﻿using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HeadHunterId))]
    public class Currency : EntityBase
    {
        public string HeadHunterId { get; set; }

        public virtual IReadOnlyCollection<VacancySalary>? Salaries { get; set; }
    }
}