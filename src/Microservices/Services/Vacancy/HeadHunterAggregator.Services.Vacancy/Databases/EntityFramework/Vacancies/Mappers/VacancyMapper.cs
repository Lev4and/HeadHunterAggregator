using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MassTransit.Internals.GraphValidation;
using System.Xml.Linq;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers
{
    public class VacancyMapper : IVacancyMapper
    {
        public Entities.Vacancy Map(VacancyDto dto)
        {
            return new Entities.Vacancy
            {
                HasTest = dto.HasTest,
                Premium = dto.Premium,
                Archived = dto.Archived,
                AcceptKids = dto.AcceptKids,
                AllowMessages = dto.AllowMessages,
                AcceptTemporary = dto.AcceptTemporary,
                AcceptHandicapped = dto.AcceptHandicapped,
                ResponseLetterRequired = dto.ResponseLetterRequired,
                AcceptIncompleteResumes = dto.AcceptIncompleteResumes,
                HeadHunterId = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                AlternateUrl = dto.AlternateUrl,
                ApplyAlternateUrl = dto.ApplyAlternateUrl,
                CreatedAt = dto.CreatedAt,
                PublishedAt = dto.PublishedAt,
                InitialCreatedAt = dto.InitialCreatedAt ?? DateTime.UnixEpoch
            };
        }
    }
}
