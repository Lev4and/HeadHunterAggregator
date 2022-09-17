using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.Create.Builders
{
    public class MetroLineBuilder : DocumentBuilder<Collections.MetroLine>
    {
        private readonly Models.MetroLine _metroLine;

        public MetroLineBuilder(IMediator mediator, Models.MetroLine metroLine) : base(mediator)
        {
            _metroLine = metroLine;

            Document = new Collections.MetroLine(metroLine);
        }

        public MetroLineBuilder WithAreaId()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var area = _metroLine.Area != null ? await ImportAsync(new Area.Import.Command(_metroLine.Area)) : null;

                Document.Area = area;
                Document.AreaId = area?.Id;
            }));

            return this;
        }
    }
}
