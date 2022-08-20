using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Dictionaries
    {
        [JsonProperty("vacancy_label")]
        public List<VacancyLabel> VacancyLabel { get; set; }

        [JsonProperty("resume_access_type")]
        public List<ResumeAccessType> ResumeAccessType { get; set; }

        [JsonProperty("vacancy_search_order")]
        public List<VacancySearchOrder> VacancySearchOrder { get; set; }

        [JsonProperty("vacancy_search_fields")]
        public List<VacancySearchField> VacancySearchFields { get; set; }

        [JsonProperty("gender")]
        public List<Gender> Gender { get; set; }

        [JsonProperty("preferred_contact_type")]
        public List<PreferredContactType> PreferredContactType { get; set; }

        [JsonProperty("travel_time")]
        public List<TravelTime> TravelTime { get; set; }

        [JsonProperty("relocation_type")]
        public List<RelocationType> RelocationType { get; set; }

        [JsonProperty("business_trip_readiness")]
        public List<BusinessTripReadiness> BusinessTripReadiness { get; set; }

        [JsonProperty("resume_contacts_site_type")]
        public List<ResumeContactsSiteType> ResumeContactsSiteType { get; set; }

        [JsonProperty("employer_type")]
        public List<EmployerType> EmployerType { get; set; }

        [JsonProperty("employer_relation")]
        public List<EmployerRelation> EmployerRelation { get; set; }

        [JsonProperty("negotiations_state")]
        public List<NegotiationsState> NegotiationsState { get; set; }

        [JsonProperty("applicant_negotiation_status")]
        public List<ApplicantNegotiationStatus> ApplicantNegotiationStatus { get; set; }

        [JsonProperty("negotiations_participant_type")]
        public List<NegotiationsParticipantType> NegotiationsParticipantType { get; set; }

        [JsonProperty("negotiations_order")]
        public List<NegotiationsOrder> NegotiationsOrder { get; set; }

        [JsonProperty("resume_moderation_note")]
        public List<ResumeModerationNote> ResumeModerationNote { get; set; }

        [JsonProperty("vacancy_relation")]
        public List<VacancyRelation> VacancyRelation { get; set; }

        [JsonProperty("resume_status")]
        public List<ResumeStatus> ResumeStatus { get; set; }

        [JsonProperty("resume_search_logic")]
        public List<ResumeSearchLogic> ResumeSearchLogic { get; set; }

        [JsonProperty("resume_search_fields")]
        public List<ResumeSearchField> ResumeSearchFields { get; set; }

        [JsonProperty("messaging_status")]
        public List<MessagingStatus> MessagingStatus { get; set; }

        [JsonProperty("employer_active_vacancies_order")]
        public List<EmployerActiveVacanciesOrder> EmployerActiveVacanciesOrder { get; set; }

        [JsonProperty("employer_archived_vacancies_order")]
        public List<EmployerArchivedVacanciesOrder> EmployerArchivedVacanciesOrder { get; set; }

        [JsonProperty("employer_hidden_vacancies_order")]
        public List<EmployerHiddenVacanciesOrder> EmployerHiddenVacanciesOrder { get; set; }

        [JsonProperty("applicant_comments_order")]
        public List<ApplicantCommentsOrder> ApplicantCommentsOrder { get; set; }

        [JsonProperty("vacancy_not_prolonged_reason")]
        public List<VacancyNotProlongedReason> VacancyNotProlongedReason { get; set; }

        [JsonProperty("resume_hidden_fields")]
        public List<ResumeHiddenField> ResumeHiddenFields { get; set; }

        [JsonProperty("phone_call_status")]
        public List<PhoneCallStatus> PhoneCallStatus { get; set; }

        [JsonProperty("experience")]
        public List<Experience> Experience { get; set; }

        [JsonProperty("employment")]
        public List<Employment> Employment { get; set; }

        [JsonProperty("schedule")]
        public List<Schedule> Schedule { get; set; }

        [JsonProperty("education_level")]
        public List<EducationLevel> EducationLevel { get; set; }

        [JsonProperty("currency")]
        public List<Currency> Currency { get; set; }

        [JsonProperty("vacancy_billing_type")]
        public List<VacancyBillingType> VacancyBillingType { get; set; }

        [JsonProperty("applicant_comment_access_type")]
        public List<ApplicantCommentAccessType> ApplicantCommentAccessType { get; set; }

        [JsonProperty("vacancy_cluster")]
        public List<VacancyCluster> VacancyCluster { get; set; }

        [JsonProperty("driver_license_types")]
        public List<DriverLicenseType> DriverLicenseTypes { get; set; }

        [JsonProperty("language_level")]
        public List<LanguageLevel> LanguageLevel { get; set; }

        [JsonProperty("working_days")]
        public List<WorkingDay> WorkingDays { get; set; }

        [JsonProperty("working_time_intervals")]
        public List<WorkingTimeInterval> WorkingTimeIntervals { get; set; }

        [JsonProperty("working_time_modes")]
        public List<WorkingTimeMode> WorkingTimeModes { get; set; }

        [JsonProperty("vacancy_type")]
        public List<VacancyType> VacancyType { get; set; }

        [JsonProperty("resume_search_label")]
        public List<ResumeSearchLabel> ResumeSearchLabel { get; set; }

        [JsonProperty("resume_search_relocation")]
        public List<ResumeSearchRelocation> ResumeSearchRelocation { get; set; }

        [JsonProperty("resume_search_order")]
        public List<ResumeSearchOrder> ResumeSearchOrder { get; set; }

        [JsonProperty("resume_search_experience_period")]
        public List<ResumeSearchExperiencePeriod> ResumeSearchExperiencePeriod { get; set; }
    }
}
