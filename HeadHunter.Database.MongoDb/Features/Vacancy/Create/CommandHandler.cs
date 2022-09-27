using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Features.Vacancy.Create.Builders;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Vacancy>
    {
        private readonly IMediator _mediator;
        private readonly Repository _repository;

        public CommandHandler(IMediator mediator, Repository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Collections.Vacancy> Handle(Command request, CancellationToken cancellationToken)
        {
            var vacancy = await new VacancyBuilder(_mediator, request.Vacancy)
                .WithArea().WithSalary().WithEmployer().WithSchedule().WithExperience().WithEmployment()
                .WithDepartment().WithVacancyType().WithBillingType().WithLanguages().WithKeySkills().WithWorkingDays()
                .WithSpecializations().WithWorkingTimeModes().WithProfessionalRoles().WithDriverLicenseTypes()
                .WithWorkingTimeIntervals().BuildAsync();

            await _repository.AddAsync(vacancy);

            return vacancy;
        }
    }
}
