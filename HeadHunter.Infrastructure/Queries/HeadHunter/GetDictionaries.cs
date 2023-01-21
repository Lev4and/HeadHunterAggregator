using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    internal class GetDictionaries : IQuery<Dictionaries?>
    {
        public GetDictionaries()
        {

        }

        internal class Validator : AbstractValidator<GetDictionaries>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<GetDictionaries, Dictionaries?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<Dictionaries?> Handle(GetDictionaries request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Dictionaries.GetDictionariesAsync();

                return response.Result;
            }
        }
    }
}
