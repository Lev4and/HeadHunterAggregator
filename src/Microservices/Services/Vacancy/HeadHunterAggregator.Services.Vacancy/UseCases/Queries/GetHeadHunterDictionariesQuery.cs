using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterDictionariesQuery : IRequest<DictionariesDto>
    {
        internal class Handler : IRequestHandler<GetHeadHunterDictionariesQuery, DictionariesDto>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<DictionariesDto> Handle(GetHeadHunterDictionariesQuery request, 
                CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Dictionaries.GetDictionariesAsync(cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
