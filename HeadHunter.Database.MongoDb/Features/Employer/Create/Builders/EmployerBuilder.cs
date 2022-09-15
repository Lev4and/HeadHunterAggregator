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
                var area = _employer.Area != null ? await ImportAsync(new Area.Import.Command(_employer.Area)) : null;

                Document.Area = area;
                Document.AreaId = area?.Id;
            }));

            return this;
        }

        public EmployerBuilder WithIndustries()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var industries = await ImportItemsAsync((item) => new Industry.Import.Command(item), _employer.Industries);

                Document.Industries = industries;
                Document.IndustriesIds = industries.Select(industry => industry.Id).ToList();
            }));

            return this;
        }
    }
}
