using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportDictionaries : ICommand<bool>
    {
        public Dictionaries Dictionaries { get; }

        public ImportDictionaries(Dictionaries dictionaries)
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            Dictionaries = dictionaries;
        }

        internal class Validator : AbstractValidator<ImportDictionaries>
        {
            public Validator()
            {
                RuleFor(model => model.Dictionaries).Null().WithMessage($"The {nameof(Dictionaries)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportDictionaries, bool>
        {
            private readonly IImportVisitor _visitor;

            private readonly ICurrencyFactory _currencyFactory;
            private readonly IScheduleFactory _scheduleFactory;
            private readonly IEmploymentFactory _employmentFactory;
            private readonly IExperienceFactory _experienceFactory;
            private readonly IWorkingDayFactory _workingDayFactory;
            private readonly IBillingTypeFactory _billingTypeFactory;
            private readonly IVacancyTypeFactory _vacancyTypeFactory;
            private readonly IWorkingTimeModeFactory _workingTimeModeFactory;
            private readonly IDriverLicenseTypeFactory _driverLicenseTypeFactory;
            private readonly IWorkingTimeIntervalFactory _workingTimeIntervalFactory;

            public Handler(IImportVisitor visitor, ICurrencyFactory currencyFactory, 
                IScheduleFactory scheduleFactory, IEmploymentFactory employmentFactory, 
                IExperienceFactory experienceFactory, IWorkingDayFactory workingDayFactory, 
                IBillingTypeFactory billingTypeFactory, IVacancyTypeFactory vacancyTypeFactory, 
                IWorkingTimeModeFactory workingTimeModeFactory, IDriverLicenseTypeFactory driverLicenseTypeFactory, 
                IWorkingTimeIntervalFactory workingTimeIntervalFactory)
            {
                _visitor = visitor;

                _currencyFactory = currencyFactory;
                _scheduleFactory = scheduleFactory;
                _employmentFactory = employmentFactory;
                _experienceFactory = experienceFactory;
                _workingDayFactory = workingDayFactory;
                _billingTypeFactory = billingTypeFactory;
                _vacancyTypeFactory = vacancyTypeFactory;
                _workingTimeModeFactory = workingTimeModeFactory;
                _driverLicenseTypeFactory = driverLicenseTypeFactory;
                _workingTimeIntervalFactory = workingTimeIntervalFactory;
            }

            public async Task<bool> Handle(ImportDictionaries request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
