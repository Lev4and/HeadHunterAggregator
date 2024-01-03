using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class VacancyDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("branded_description")]
        public string? BrandedDescription { get; set; }

        [JsonProperty("key_skills")]
        public IReadOnlyCollection<KeySkillDto>? KeySkills { get; set; }

        [JsonProperty("schedule")]
        public ScheduleDto? Schedule { get; set; }

        [JsonProperty("accept_handicapped")]
        public bool? AcceptHandicapped { get; set; }

        [JsonProperty("accept_kids")]
        public bool? AcceptKids { get; set; }

        [JsonProperty("experience")]
        public ExperienceDto? Experience { get; set; }

        [JsonProperty("address")]
        public AddressDto? Address { get; set; }

        [JsonProperty("alternate_url")]
        public string? AlternateUrl { get; set; }

        [JsonProperty("apply_alternate_url")]
        public string? ApplyAlternateUrl { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("department")]
        public DepartmentDto? Department { get; set; }

        [JsonProperty("employment")]
        public EmploymentDto? Employment { get; set; }

        [JsonProperty("salary")]
        public SalaryDto? Salary { get; set; }

        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("insider_interview")]
        public InsiderInterviewDto? InsiderInterview { get; set; }

        [JsonProperty("area")]
        public AreaDto? Area { get; set; }

        [JsonProperty("initial_created_at")]
        public DateTime? InitialCreatedAt { get; set; }

        [JsonRequired]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonRequired]
        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonRequired]
        [JsonProperty("employer")]
        public EmployerDto Employer { get; set; }

        [JsonProperty("response_letter_required")]
        public bool? ResponseLetterRequired { get; set; }

        [JsonProperty("type")]
        public VacancyTypeDto? Type { get; set; }

        [JsonProperty("has_test")]
        public bool HasTest { get; set; }

        [JsonProperty("response_url")]
        public object? ResponseUrl { get; set; }

        [JsonProperty("test")]
        public TestDto? Test { get; set; }

        [JsonProperty("specializations")]
        public IReadOnlyCollection<SpecializationDto>? Specializations { get; set; }

        [JsonProperty("contacts")]
        public ContactsDto? Contacts { get; set; }

        [JsonProperty("billing_type")]
        public BillingTypeDto? BillingType { get; set; }

        [JsonProperty("allow_messages")]
        public bool? AllowMessages { get; set; }

        [JsonProperty("premium")]
        public bool? Premium { get; set; }

        [JsonProperty("driver_license_types")]
        public IReadOnlyCollection<DriverLicenseTypeDto>? DriverLicenseTypes { get; set; }

        [JsonProperty("accept_incomplete_resumes")]
        public bool? AcceptIncompleteResumes { get; set; }

        [JsonProperty("working_days")]
        public IReadOnlyCollection<WorkingDayDto>? WorkingDays { get; set; }

        [JsonProperty("working_time_intervals")]
        public IReadOnlyCollection<WorkingTimeIntervalDto>? WorkingTimeIntervals { get; set; }

        [JsonProperty("working_time_modes")]
        public IReadOnlyCollection<WorkingTimeModeDto>? WorkingTimeModes { get; set; }

        [JsonProperty("accept_temporary")]
        public bool? AcceptTemporary { get; set; }

        [JsonProperty("professional_roles")]
        public IReadOnlyCollection<ProfessionalRoleDto>? ProfessionalRoles { get; set; }

        [JsonProperty("languages")]
        public IReadOnlyCollection<LanguageDto>? Languages { get; set; }
    }
}
