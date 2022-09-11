using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("vacancies")]
    public class Vacancy : ICollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("hasTest")]
        public bool? HasTest { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("archived")]
        public bool? Archived { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("premium")]
        public bool? Premium { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("acceptKids")]
        public bool? AcceptKids { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("allowMessages")]
        public bool? AllowMessages { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("acceptTemporary")]
        public bool? AcceptTemporary { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("acceptHandicapped")]
        public bool? AcceptHandicapped { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("responseLetterRequired")]
        public bool? ResponseLetterRequired { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("acceptIncompleteResumes")]
        public bool? AcceptIncompleteResumes { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public long HeadHunterId { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("alternateUrl")]
        public string AlternateUrl { get; set; }

        [BsonElement("applyAlternateUrl")]
        public string ApplyAlternateUrl { get; set; }

        [BsonElement("brandedDescription")]
        public string BrandedDescription { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [BsonElement("initialCreatedAt")]
        public DateTime InitialCreatedAt { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("area")]
        public Area? Area { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("test")]
        public Test? Test { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("salary")]
        public Salary? Salary { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("schedule")]
        public Address? Address { get; set; }

        [BsonRequired]
        [BsonElement("employer")]
        public Employer Employer { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("schedule")]
        public Schedule? Schedule { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("contacts")]
        public Contacts? Contacts { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("experience")]
        public Experience? Experience { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("employment")]
        public Employment? Employment { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("department")]
        public Department? Department { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("vacancyType")]
        public VacancyType? VacancyType { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("billingType")]
        public BillingType? BillingType { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("insiderInterview")]
        public InsiderInterview? InsiderInterview { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("languages")]
        public List<Language> Languages { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("keySkills")]
        public List<KeySkill> KeySkills { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("workingDays")]
        public List<WorkingDay> WorkingDays { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("specializations")]
        public List<Specialization> Specializations { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("workingTimeModes")]
        public List<WorkingTimeMode> WorkingTimeModes { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("professionalRoles")]
        public List<ProfessionalRole> ProfessionalRoles { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("driverLicenseTypes")]
        public List<DriverLicenseType> DriverLicenseTypes { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("workingTimeIntervals")]
        public List<WorkingTimeInterval> WorkingTimeIntervals { get; set; }

        public Vacancy(Models.Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException(nameof(vacancy));
            }

            HasTest = vacancy.HasTest;
            Archived = vacancy.Archived;
            Premium = vacancy.Premium;
            AcceptKids = vacancy.AcceptKids;
            AllowMessages = vacancy.AllowMessages;
            AcceptTemporary = vacancy.AcceptTemporary;
            AcceptHandicapped = vacancy.AcceptHandicapped;
            ResponseLetterRequired = vacancy.ResponseLetterRequired;
            AcceptIncompleteResumes = vacancy.AcceptIncompleteResumes;
            HeadHunterId = Convert.ToInt64(vacancy.Id);
            Code = vacancy.Code;
            Name = vacancy.Name;
            Description = vacancy.Description;
            AlternateUrl = vacancy.AlternateUrl;
            ApplyAlternateUrl = vacancy.ApplyAlternateUrl;
            BrandedDescription = vacancy.BrandedDescription;
            CreatedAt = vacancy.CreatedAt;
            PublishedAt = vacancy.PublishedAt;
            InitialCreatedAt = vacancy.InitialCreatedAt;
            Area = new Area(vacancy.Area);
            Test = new Test(vacancy.Test);
            Salary = new Salary(vacancy.Salary);
            Address = new Address(vacancy.Address);
            Employer = new Employer(vacancy.Employer);
            Schedule = new Schedule(vacancy.Schedule);
            Contacts = new Contacts(vacancy.Contacts);
            Experience = new Experience(vacancy.Experience);
            Employment = new Employment(vacancy.Employment);
            Department = new Department(vacancy.Department);
            VacancyType = new VacancyType(vacancy.Type);
            BillingType = new BillingType(vacancy.BillingType);
            InsiderInterview = new InsiderInterview(vacancy.InsiderInterview);
            Languages = vacancy.Languages.Select(language => new Language(language)).ToList();
            KeySkills = vacancy.KeySkills.Select(keySkill => new KeySkill(keySkill)).ToList();
            WorkingDays = vacancy.WorkingDays.Select(workingDay => new WorkingDay(workingDay)).ToList();
            Specializations = vacancy.Specializations.Select(specialization => new Specialization(specialization)).ToList();
            WorkingTimeModes = vacancy.WorkingTimeModes.Select(workingTimeMode => new WorkingTimeMode(workingTimeMode)).ToList();
            ProfessionalRoles = vacancy.ProfessionalRoles.Select(professionalRole => new ProfessionalRole(professionalRole)).ToList();
            DriverLicenseTypes = vacancy.DriverLicenseTypes.Select(driverLicenseType => new DriverLicenseType(driverLicenseType)).ToList();
            WorkingTimeIntervals = vacancy.WorkingTimeIntervals.Select(workingTimeInterval => new WorkingTimeInterval(workingTimeInterval)).ToList();
        }
    }
}
