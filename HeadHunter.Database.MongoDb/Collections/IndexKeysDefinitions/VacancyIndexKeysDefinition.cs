using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class VacancyIndexKeysDefinition : IDefiningIndexKeys<Vacancy>
    {
        public IEnumerable<CreateIndexModel<Vacancy>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Vacancy, object>>>()
            {
                item => item.AreaId, item => item.EmployerId, item => item.ScheduleId, item => item.ExperienceId,
                item => item.EmploymentId, item => item.VacancyTypeId, item => item.BillingTypeId, item => item.Archived,
                item => item.Name, item => item.HeadHunterId, item => item.InitialCreatedAt, 
                item => item.LanguagesIds, item => item.KeySkillsIds,
                item => item.WorkingDaysIds, item => item.SpecializationsIds, item => item.WorkingTimeModesIds,
                item => item.ProfessionalRolesIds, item => item.DriverLicenseTypesIds, 
                item => item.WorkingTimeIntervalsIds,
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
