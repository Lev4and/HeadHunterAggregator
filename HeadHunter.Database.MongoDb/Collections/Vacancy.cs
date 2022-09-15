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

        [BsonIgnoreIfNull]
        [BsonElement("code")]
        public string? Code { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("alternateUrl")]
        public string? AlternateUrl { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("applyAlternateUrl")]
        public string? ApplyAlternateUrl { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("brandedDescription")]
        public string? BrandedDescription { get; set; }

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
        [BsonElement("address")]
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
            Area = vacancy.Area != null ? new Area(vacancy.Area) : null;
            Test = vacancy.Test != null ? new Test(vacancy.Test) : null;
            Salary = vacancy.Salary != null ? new Salary(vacancy.Salary) : null;
            Address = vacancy.Address != null ? new Address(vacancy.Address) : null;
            Employer = new Employer(vacancy.Employer);
            Schedule = vacancy.Schedule != null ? new Schedule(vacancy.Schedule) : null;
            Contacts = vacancy.Contacts != null ? new Contacts(vacancy.Contacts) : null;
            Experience = vacancy.Experience != null ? new Experience(vacancy.Experience) : null;
            Employment = vacancy.Employment != null ? new Employment(vacancy.Employment) : null;
            Department = vacancy.Department != null ? new Department(vacancy.Department) : null;
            VacancyType = vacancy.Type != null ? new VacancyType(vacancy.Type) : null;
            BillingType = vacancy.BillingType != null ? new BillingType(vacancy.BillingType) : null;
            InsiderInterview = vacancy.InsiderInterview != null ? new InsiderInterview(vacancy.InsiderInterview) : null;
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
