using HeadHunter.MongoDB.Core;
using HeadHunter.MongoDB.Entities;
using MongoDB.Driver;

namespace HeadHunter.MongoDB
{
    public class HeadHunterRepository : BaseRepository
    {
        public override Dictionary<Type, string> Collections => new Dictionary<Type, string> 
        {
            { typeof(Address), "addresses" },
            { typeof(Area), "areas" },
            { typeof(BillingType), "billingtypes" },
            { typeof(Contact), "contacts" },
            { typeof(Currency), "currencies" },
            { typeof(Department), "departments" },
            { typeof(DriverLicenseType), "driverlicensetypes" },
            { typeof(Employer), "employers" },
            { typeof(Employment), "employments" },
            { typeof(Experience), "experience" },
            { typeof(Industry), "industries" },
            { typeof(InsiderInterview), "insiderinterviews" },
            { typeof(KeySkill), "keyskills" },
            { typeof(Language), "languages" },
            { typeof(MetroLine), "metrolines" },
            { typeof(MetroStation), "metrostations" },
            { typeof(Phone), "phones" },
            { typeof(ProfessionalRole), "professionalroles" },
            { typeof(Schedule), "schedules" },
            { typeof(Specialization), "specializations" },
            { typeof(Test), "tests" },
            { typeof(Vacancy), "vacancies" },
            { typeof(VacancyType), "vacancytypes" },
            { typeof(WorkingDay), "workingdays" },
            { typeof(WorkingTimeInterval), "workingtimeinterval" },
            { typeof(WorkingTimeMode), "workingtimemode" },
        };

        public HeadHunterRepository(IMongoDatabase database) : base(database)
        {

        }
    }
}
