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

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Area>>($"{ResourceRoutes.HeadHunterSuggestsAreaQuery}?q={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<Employer>>> GetSuggestsCompaniesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Employer>>($"{ResourceRoutes.HeadHunterSuggestsCompaniesQuery}?q={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<University>>> GetSuggestsUniversitiesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<University>>($"{ResourceRoutes.HeadHunterSuggestsUniversitiesQuery}?q={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<Specialization>>> GetSuggestsSpecializationsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Specialization>>($"{ResourceRoutes.HeadHunterSuggestsSpecializationsQuery}?q={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<ProfessionalRole>>> GetSuggestsProfessionalRolesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<ProfessionalRole>>($"{ResourceRoutes.HeadHunterSuggestsProfessionalRolesQuery}?q={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<KeySkill>>> GetSuggestsKeySkillsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<KeySkill>>($"{ResourceRoutes.HeadHunterSuggestsKeySkillsQuery}?q={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<VacancyPosition>>> GetSuggestsVacancyPositionsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<VacancyPosition>>($"{ResourceRoutes.HeadHunterSuggestsVacancyPositionsQuery}?q={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<KeyWord>>> GetSuggestsVacancyKeyWordsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<KeyWord>>($"{ResourceRoutes.HeadHunterSuggestsVacancyKeyWordsQuery}?q={searchString}");
        }
    }
}
