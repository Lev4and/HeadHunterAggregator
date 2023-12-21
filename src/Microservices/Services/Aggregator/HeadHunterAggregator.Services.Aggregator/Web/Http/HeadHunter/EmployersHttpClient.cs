using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter
{
    public class EmployersHttpClient : HeadHunterHttpClient
    {
        public EmployersHttpClient() : base(new Uri(HeadHunterRoutes.EmployersUriPath, UriKind.Relative))
        {
            
        }

        public async Task<ResponseModel<EmployerDto>> GetEmployerAsync(long id, 
            CancellationToken cancellationToken = default)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return await GetAsync<EmployerDto>(string.Format("{0}", id), cancellationToken);
        }
    }
}
