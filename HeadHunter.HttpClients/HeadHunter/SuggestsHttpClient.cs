using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class SuggestsHttpClient : HeadHunterHttpClient
    {
        public SuggestsHttpClient(): base(HeadHunterRoutes.SuggestsPath)
        {

        }

        public async Task<ResponseModel<ItemsResponseModel<Area>>> GetSuggestsAreaLeavesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Area>>($"{HeadHunterRoutes.SuggestsAreaLeavesQuery}?text={searchString}");
        }

        public async Task<ResponseModel<ItemsResponseModel<Employer>>> GetSuggestsCompaniesLeavesAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            if (searchString.Length <= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(searchString));
            }

            return await Get<ItemsResponseModel<Employer>>($"{HeadHunterRoutes.SuggestsCompaniesQuery}?text={searchString}");
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

            return await Get<ItemsResponseModel<University>>($"{HeadHunterRoutes.SuggestsUniversitiesQuery}?text={searchString}");
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

            return await Get<ItemsResponseModel<Specialization>>($"{HeadHunterRoutes.SuggestsSpecializationsQuery}?text={searchString}");
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

            return await Get<ItemsResponseModel<ProfessionalRole>>($"{HeadHunterRoutes.SuggestsProfessionalRolesQuery}?text={searchString}");
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

            return await Get<ItemsResponseModel<KeySkill>>($"{HeadHunterRoutes.SuggestsKeySkillsQuery}?text={searchString}");
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

            return await Get<ItemsResponseModel<VacancyPosition>>($"{HeadHunterRoutes.SuggestsVacancyPositionsQuery}?text={searchString}");
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

            return await Get<ItemsResponseModel<KeyWord>>($"{HeadHunterRoutes.SuggestsVacancyKeyWordsQuery}?text={searchString}");
        }
    }
}
