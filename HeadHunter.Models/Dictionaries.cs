using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Dictionaries
    {
        [JsonProperty("vacancy_label")]
        public List<VacancyLabel>? VacancyLabels { get; set; }

        [JsonProperty("resume_access_type")]
        public List<ResumeAccessType>? ResumeAccessTypes { get; set; }

        [JsonProperty("vacancy_search_order")]
        public List<VacancySearchOrder>? VacancySearchOrders { get; set; }

        [JsonProperty("vacancy_search_fields")]
        public List<VacancySearchField>? VacancySearchFields { get; set; }

        [JsonProperty("gender")]
        public List<Gender>? Genders { get; set; }

        [JsonProperty("preferred_contact_type")]
        public List<PreferredContactType>? PreferredContactTypes { get; set; }

        [JsonProperty("travel_time")]
        public List<TravelTime>? TravelTimes { get; set; }

        [JsonProperty("relocation_type")]
        public List<RelocationType>? RelocationTypes { get; set; }

        [JsonProperty("business_trip_readiness")]
        public List<BusinessTripReadiness>? BusinessTripReadinesses { get; set; }

        [JsonProperty("resume_contacts_site_type")]
        public List<ResumeContactsSiteType>? ResumeContactsSiteTypes { get; set; }

        [JsonProperty("employer_type")]
        public List<EmployerType>? EmployerTypes { get; set; }

        [JsonProperty("employer_relation")]
        public List<EmployerRelation>? EmployerRelationes { get; set; }

        [JsonProperty("negotiations_state")]
        public List<NegotiationsState>? NegotiationsStates { get; set; }

        [JsonProperty("applicant_negotiation_status")]
        public List<ApplicantNegotiationStatus>? ApplicantNegotiationStatuses { get; set; }

        [JsonProperty("negotiations_participant_type")]
        public List<NegotiationsParticipantType>? NegotiationsParticipantTypes { get; set; }

        [JsonProperty("negotiations_order")]
        public List<NegotiationsOrder>? NegotiationsOrders { get; set; }

        [JsonProperty("resume_moderation_note")]
        public List<ResumeModerationNote>? ResumeModerationNotes { get; set; }

        [JsonProperty("vacancy_relation")]
        public List<VacancyRelation>? VacancyRelations { get; set; }

        [JsonProperty("resume_status")]
        public List<ResumeStatus>? ResumeStatuses { get; set; }

        [JsonProperty("resume_search_logic")]
        public List<ResumeSearchLogic>? ResumeSearchLogics { get; set; }

        [JsonProperty("resume_search_fields")]
        public List<ResumeSearchField>? ResumeSearchFields { get; set; }

        [JsonProperty("messaging_status")]
        public List<MessagingStatus>? MessagingStatuses { get; set; }

        [JsonProperty("employer_active_vacancies_order")]
        public List<EmployerActiveVacanciesOrder>? EmployerActiveVacanciesOrders { get; set; }

        [JsonProperty("employer_archived_vacancies_order")]
        public List<EmployerArchivedVacanciesOrder>? EmployerArchivedVacanciesOrders { get; set; }

        [JsonProperty("employer_hidden_vacancies_order")]
        public List<EmployerHiddenVacanciesOrder>? EmployerHiddenVacanciesOrders { get; set; }

        [JsonProperty("applicant_comments_order")]
        public List<ApplicantCommentsOrder>? ApplicantCommentsOrders { get; set; }

        [JsonProperty("vacancy_not_prolonged_reason")]
        public List<VacancyNotProlongedReason>? VacancyNotProlongedReasons { get; set; }

        [JsonProperty("resume_hidden_fields")]
        public List<ResumeHiddenField>? ResumeHiddenFields { get; set; }

        [JsonProperty("phone_call_status")]
        public List<PhoneCallStatus>? PhoneCallStatuses { get; set; }

        [JsonProperty("experience")]
        public List<Experience>? Experiences { get; set; }

        [JsonProperty("employment")]
        public List<Employment>? Employments { get; set; }

        [JsonProperty("schedule")]
        public List<Schedule>? Schedules { get; set; }

        [JsonProperty("education_level")]
        public List<EducationLevel>? EducationLevels { get; set; }

        [JsonProperty("currency")]
        public List<Currency>? Currencies { get; set; }

        [JsonProperty("vacancy_billing_type")]
        public List<BillingType>? VacancyBillingTypes { get; set; }

        [JsonProperty("applicant_comment_access_type")]
        public List<ApplicantCommentAccessType>? ApplicantCommentAccessType { get; set; }

        [JsonProperty("vacancy_cluster")]
        public List<VacancyCluster>? VacancyClusters { get; set; }

        [JsonProperty("driver_license_types")]
        public List<DriverLicenseType>? DriverLicenseTypes { get; set; }

        [JsonProperty("language_level")]
        public List<LanguageLevel>? LanguageLevels { get; set; }

        [JsonProperty("working_days")]
        public List<WorkingDay>? WorkingDays { get; set; }

        [JsonProperty("working_time_intervals")]
        public List<WorkingTimeInterval>? WorkingTimeIntervals { get; set; }

        [JsonProperty("working_time_modes")]
        public List<WorkingTimeMode>? WorkingTimeModes { get; set; }

        [JsonProperty("vacancy_type")]
        public List<VacancyType>? VacancyTypes { get; set; }

        [JsonProperty("resume_search_label")]
        public List<ResumeSearchLabel>? ResumeSearchLabels { get; set; }

        [JsonProperty("resume_search_relocation")]
        public List<ResumeSearchRelocation>? ResumeSearchRelocations { get; set; }

        [JsonProperty("resume_search_order")]
        public List<ResumeSearchOrder>? ResumeSearchOrders { get; set; }

        [JsonProperty("resume_search_experience_period")]
        public List<ResumeSearchExperiencePeriod>? ResumeSearchExperiencePeriods { get; set; }
    }
}
