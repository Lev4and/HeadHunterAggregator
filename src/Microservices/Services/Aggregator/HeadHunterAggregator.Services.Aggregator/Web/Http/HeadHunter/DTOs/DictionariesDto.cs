using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class DictionariesDto
    {
        [JsonProperty("vacancy_label")]
        public IReadOnlyCollection<VacancyLabelDto>? VacancyLabels { get; set; }

        [JsonProperty("resume_access_type")]
        public IReadOnlyCollection<ResumeAccessTypeDto>? ResumeAccessTypes { get; set; }

        [JsonProperty("vacancy_search_order")]
        public IReadOnlyCollection<VacancySearchOrderDto>? VacancySearchOrders { get; set; }

        [JsonProperty("vacancy_search_fields")]
        public IReadOnlyCollection<VacancySearchFieldDto>? VacancySearchFields { get; set; }

        [JsonProperty("gender")]
        public IReadOnlyCollection<GenderDto>? Genders { get; set; }

        [JsonProperty("preferred_contact_type")]
        public IReadOnlyCollection<PreferredContactTypeDto>? PreferredContactTypes { get; set; }

        [JsonProperty("travel_time")]
        public IReadOnlyCollection<TravelTimeDto>? TravelTimes { get; set; }

        [JsonProperty("relocation_type")]
        public IReadOnlyCollection<RelocationTypeDto>? RelocationTypes { get; set; }

        [JsonProperty("business_trip_readiness")]
        public IReadOnlyCollection<BusinessTripReadinessDto>? BusinessTripReadinesses { get; set; }

        [JsonProperty("resume_contacts_site_type")]
        public IReadOnlyCollection<ResumeContactsSiteTypeDto>? ResumeContactsSiteTypes { get; set; }

        [JsonProperty("employer_type")]
        public IReadOnlyCollection<EmployerTypeDto>? EmployerTypes { get; set; }

        [JsonProperty("employer_relation")]
        public IReadOnlyCollection<EmployerRelationDto>? EmployerRelationes { get; set; }

        [JsonProperty("negotiations_state")]
        public IReadOnlyCollection<NegotiationsStateDto>? NegotiationsStates { get; set; }

        [JsonProperty("applicant_negotiation_status")]
        public IReadOnlyCollection<ApplicantNegotiationStatusDto>? ApplicantNegotiationStatuses { get; set; }

        [JsonProperty("negotiations_participant_type")]
        public IReadOnlyCollection<NegotiationsParticipantTypeDto>? NegotiationsParticipantTypes { get; set; }

        [JsonProperty("negotiations_order")]
        public IReadOnlyCollection<NegotiationsOrderDto>? NegotiationsOrders { get; set; }

        [JsonProperty("resume_moderation_note")]
        public IReadOnlyCollection<ResumeModerationNoteDto>? ResumeModerationNotes { get; set; }

        [JsonProperty("vacancy_relation")]
        public IReadOnlyCollection<VacancyRelationDto>? VacancyRelations { get; set; }

        [JsonProperty("resume_status")]
        public IReadOnlyCollection<ResumeStatusDto>? ResumeStatuses { get; set; }

        [JsonProperty("resume_search_logic")]
        public IReadOnlyCollection<ResumeSearchLogicDto>? ResumeSearchLogics { get; set; }

        [JsonProperty("resume_search_fields")]
        public IReadOnlyCollection<ResumeSearchFieldDto>? ResumeSearchFields { get; set; }

        [JsonProperty("messaging_status")]
        public IReadOnlyCollection<MessagingStatusDto>? MessagingStatuses { get; set; }

        [JsonProperty("employer_active_vacancies_order")]
        public IReadOnlyCollection<EmployerActiveVacanciesOrderDto>? EmployerActiveVacanciesOrders { get; set; }

        [JsonProperty("employer_archived_vacancies_order")]
        public IReadOnlyCollection<EmployerArchivedVacanciesOrderDto>? EmployerArchivedVacanciesOrders { get; set; }

        [JsonProperty("employer_hidden_vacancies_order")]
        public IReadOnlyCollection<EmployerHiddenVacanciesOrderDto>? EmployerHiddenVacanciesOrders { get; set; }

        [JsonProperty("applicant_comments_order")]
        public IReadOnlyCollection<ApplicantCommentsOrderDto>? ApplicantCommentsOrders { get; set; }

        [JsonProperty("vacancy_not_prolonged_reason")]
        public IReadOnlyCollection<VacancyNotProlongedReasonDto>? VacancyNotProlongedReasons { get; set; }

        [JsonProperty("resume_hidden_fields")]
        public IReadOnlyCollection<ResumeHiddenFieldDto>? ResumeHiddenFields { get; set; }

        [JsonProperty("phone_call_status")]
        public IReadOnlyCollection<PhoneCallStatusDto>? PhoneCallStatuses { get; set; }

        [JsonProperty("experience")]
        public IReadOnlyCollection<ExperienceDto>? Experiences { get; set; }

        [JsonProperty("employment")]
        public IReadOnlyCollection<EmploymentDto>? Employments { get; set; }

        [JsonProperty("schedule")]
        public IReadOnlyCollection<ScheduleDto>? Schedules { get; set; }

        [JsonProperty("education_level")]
        public IReadOnlyCollection<EducationLevelDto>? EducationLevels { get; set; }

        [JsonProperty("currency")]
        public IReadOnlyCollection<CurrencyDto>? Currencies { get; set; }

        [JsonProperty("vacancy_billing_type")]
        public IReadOnlyCollection<BillingTypeDto>? VacancyBillingTypes { get; set; }

        [JsonProperty("applicant_comment_access_type")]
        public IReadOnlyCollection<ApplicantCommentAccessTypeDto>? ApplicantCommentAccessType { get; set; }

        [JsonProperty("vacancy_cluster")]
        public IReadOnlyCollection<VacancyClusterDto>? VacancyClusters { get; set; }

        [JsonProperty("driver_license_types")]
        public IReadOnlyCollection<DriverLicenseTypeDto>? DriverLicenseTypes { get; set; }

        [JsonProperty("language_level")]
        public IReadOnlyCollection<LanguageLevelDto>? LanguageLevels { get; set; }

        [JsonProperty("working_days")]
        public IReadOnlyCollection<WorkingDayDto>? WorkingDays { get; set; }

        [JsonProperty("working_time_intervals")]
        public IReadOnlyCollection<WorkingTimeIntervalDto>? WorkingTimeIntervals { get; set; }

        [JsonProperty("working_time_modes")]
        public IReadOnlyCollection<WorkingTimeModeDto>? WorkingTimeModes { get; set; }

        [JsonProperty("vacancy_type")]
        public IReadOnlyCollection<VacancyTypeDto>? VacancyTypes { get; set; }

        [JsonProperty("resume_search_label")]
        public IReadOnlyCollection<ResumeSearchLabelDto>? ResumeSearchLabels { get; set; }

        [JsonProperty("resume_search_relocation")]
        public IReadOnlyCollection<ResumeSearchRelocationDto>? ResumeSearchRelocations { get; set; }

        [JsonProperty("resume_search_order")]
        public IReadOnlyCollection<ResumeSearchOrderDto>? ResumeSearchOrders { get; set; }

        [JsonProperty("resume_search_experience_period")]
        public IReadOnlyCollection<ResumeSearchExperiencePeriodDto>? ResumeSearchExperiencePeriods { get; set; }
    }
}
