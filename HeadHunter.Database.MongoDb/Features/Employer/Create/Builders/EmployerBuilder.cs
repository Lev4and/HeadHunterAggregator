using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Employer.Create.Builders
{
    public class EmployerBuilder : DocumentBuilder<Collections.Employer>
    {
        private readonly Models.Employer _employer;

        public EmployerBuilder(IMediator mediator, Models.Employer employer) : base(mediator)
        {
            _employer = employer;

            Document = new Collections.Employer(employer);
        }

        public EmployerBuilder WithArea()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Area = _employer.Area != null ? await ImportAsync(new Area.Import.Command(_employer.Area)) : null;
            }));

            return this;
        }

        public EmployerBuilder WithIndustries()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Industries = await ImportItemsAsync((item) => new Industry.Import.Command(item), _employer.Industries);
            }));

            return this;
        }
    }
}
