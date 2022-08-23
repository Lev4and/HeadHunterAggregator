using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Vacancy
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("branded_description")]
        public string BrandedDescription { get; set; }

        [JsonProperty("key_skills")]
        public List<KeySkill> KeySkills { get; set; }

        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }

        [JsonProperty("accept_handicapped")]
        public bool AcceptHandicapped { get; set; }

        [JsonProperty("accept_kids")]
        public bool AcceptKids { get; set; }

        [JsonProperty("experience")]
        public Experience Experience { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("alternate_url")]
        public string AlternateUrl { get; set; }

        [JsonProperty("apply_alternate_url")]
        public string ApplyAlternateUrl { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("department")]
        public Department Department { get; set; }

        [JsonProperty("employment")]
        public Employment Employment { get; set; }

        [JsonProperty("salary")]
        public Salary Salary { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("insider_interview")]
        public InsiderInterview InsiderInterview { get; set; }

        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("initial_created_at")]
        public DateTime InitialCreatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("employer")]
        public Employer Employer { get; set; }

        [JsonProperty("response_letter_required")]
        public bool ResponseLetterRequired { get; set; }

        [JsonProperty("type")]
        public VacancyType Type { get; set; }

        [JsonProperty("has_test")]
        public bool HasTest { get; set; }

        [JsonProperty("response_url")]
        public object ResponseUrl { get; set; }

        [JsonProperty("test")]
        public Test Test { get; set; }

        [JsonProperty("specializations")]
        public List<Specialization> Specializations { get; set; }

        [JsonProperty("contacts")]
        public Contacts Contacts { get; set; }

        [JsonProperty("billing_type")]
        public BillingType BillingType { get; set; }

        [JsonProperty("allow_messages")]
        public bool AllowMessages { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("driver_license_types")]
        public List<DriverLicenseType> DriverLicenseTypes { get; set; }

        [JsonProperty("accept_incomplete_resumes")]
        public bool AcceptIncompleteResumes { get; set; }

        [JsonProperty("working_days")]
        public List<WorkingDay> WorkingDays { get; set; }

        [JsonProperty("working_time_intervals")]
        public List<WorkingTimeInterval> WorkingTimeIntervals { get; set; }

        [JsonProperty("working_time_modes")]
        public List<WorkingTimeMode> WorkingTimeModes { get; set; }

        [JsonProperty("accept_temporary")]
        public bool AcceptTemporary { get; set; }

        [JsonProperty("professional_roles")]
        public List<ProfessionalRole> ProfessionalRoles { get; set; }

        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }
    }
}
