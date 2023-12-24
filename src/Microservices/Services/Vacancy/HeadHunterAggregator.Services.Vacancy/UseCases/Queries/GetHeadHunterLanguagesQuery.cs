using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterLanguagesQuery : IRequest<IReadOnlyCollection<LanguageDto>>
    {
        internal class Handler : IRequestHandler<GetHeadHunterLanguagesQuery, IReadOnlyCollection<LanguageDto>>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<IReadOnlyCollection<LanguageDto>> Handle(GetHeadHunterLanguagesQuery request, 
                CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Languages.GetLanguagesAsync(cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
