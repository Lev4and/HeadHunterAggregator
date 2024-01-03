﻿using HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public interface IInsiderInterviewMapper : IDbMapper<InsiderInterviewDto, InsiderInterview>
    {

    }
}