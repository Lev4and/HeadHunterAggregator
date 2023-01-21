using FluentValidation;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.HttpClients;
using MediatR;
using HeadHunter.Core.Domain.Cqrs;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    public class GetLanguages : IQuery<Language[]?>
    {
        public GetLanguages()
        {

        }

        internal class Validator : AbstractValidator<GetLanguages>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<GetLanguages, Language[]?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<Language[]?> Handle(GetLanguages request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Languages.GetLanguagesAsync();

                return response.Result;
            }
        }
    }
}
