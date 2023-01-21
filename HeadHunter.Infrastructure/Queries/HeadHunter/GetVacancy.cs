using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    public class GetVacancy : IQuery<Vacancy?>
    {
        public long Id { get; }

        public GetVacancy(long id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
        }

        internal class Validator : AbstractValidator<GetVacancy>
        {
            public Validator()
            {
                RuleFor(model => model.Id).LessThanOrEqualTo(0).WithMessage($"The {nameof(Id)} param should be " +
                    $"greater than 0.");
            }
        }

        internal class Handler : IRequestHandler<GetVacancy, Vacancy?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<Vacancy?> Handle(GetVacancy request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Vacancies.GetVacancyAsync(request.Id);

                return response.Result;
            }
        }
    }
}
