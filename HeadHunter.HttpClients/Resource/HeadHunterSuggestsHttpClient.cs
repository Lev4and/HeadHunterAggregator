using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterSuggestsHttpClient : ResourceHttpClient
    {
        public HeadHunterSuggestsHttpClient() : base(ResourceRoutes.HeadHunterSuggestsPath)
        {

        }

        public async Task<ResponseModel<ItemsResponseModel<Area>>> GetSuggestsAreaAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Area>>($"{ResourceRoutes.HeadHunterSuggestsAreasQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<Employer>>> GetSuggestsCompaniesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Employer>>($"{ResourceRoutes.HeadHunterSuggestsCompaniesQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<University>>> GetSuggestsUniversitiesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<University>>($"{ResourceRoutes.HeadHunterSuggestsUniversitiesQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<Specialization>>> GetSuggestsSpecializationsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Specialization>>($"{ResourceRoutes.HeadHunterSuggestsSpecializationsQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<ProfessionalRole>>> GetSuggestsProfessionalRolesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<ProfessionalRole>>($"{ResourceRoutes.HeadHunterSuggestsProfessionalRolesQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<KeySkill>>> GetSuggestsKeySkillsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<KeySkill>>($"{ResourceRoutes.HeadHunterSuggestsKeySkillsQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<VacancyPosition>>> GetSuggestsVacancyPositionsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<VacancyPosition>>($"{ResourceRoutes.HeadHunterSuggestsVacancyPositionsQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<KeyWord>>> GetSuggestsVacancyKeyWordsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<KeyWord>>($"{ResourceRoutes.HeadHunterSuggestsVacancyKeyWordsQuery}?{ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam}={searchString}");
        }
    }
}
