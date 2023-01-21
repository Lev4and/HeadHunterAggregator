using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    public class GetVacancies : IQuery<PagedResponseModel<Vacancy>?>
    {
        public int Page { get; }

        public int PerPage { get; }

        public DateTime DateTo { get; }

        public DateTime DateFrom { get; }

        public GetVacancies(int page, int perPage, DateTime dateFrom, DateTime dateTo) 
        {
            if (page < 1 || page * perPage > 1999) throw new ArgumentOutOfRangeException(nameof(page));
            if (perPage < 1 || perPage > 100) throw new ArgumentOutOfRangeException(nameof(perPage));
            if (dateFrom > dateTo) throw new ArgumentOutOfRangeException(nameof(dateFrom));
            if (dateTo < dateFrom) throw new ArgumentOutOfRangeException(nameof(dateTo));

            Page = page;
            PerPage = perPage;
            DateTo = dateTo;
            DateFrom = dateFrom;
        }

        internal class Validator : AbstractValidator<GetVacancies>
        {
            public Validator() 
            {
                RuleFor(model => model.Page).LessThan(1).WithMessage($"The {nameof(Page)} param should be greater than 0.");
                
                RuleFor(model => model.Page * model.PerPage).GreaterThan(1999).WithMessage($"The {nameof(Page)} param should be " +
                    $"greater than 0 and equal expression {nameof(Page)} * {nameof(PerPage)} <= 1999.");

                RuleFor(model => model.DateFrom).GreaterThan(model => model.DateFrom).WithMessage($"The {nameof(DateFrom)} " +
                    $"should be less or equal than {nameof(DateTo)}");

                RuleFor(model => model.DateTo).LessThan(model => model.DateTo).WithMessage($"The {nameof(DateTo)} " +
                    $"should be greater or equal than {nameof(DateFrom)}");
            }
        }

        internal class Handler : IRequestHandler<GetVacancies, PagedResponseModel<Vacancy>?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<PagedResponseModel<Vacancy>?> Handle(GetVacancies request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(request.Page, request.PerPage,
                    request.DateFrom, request.DateTo);

                return response.Result;
            }
        }
    }
}
