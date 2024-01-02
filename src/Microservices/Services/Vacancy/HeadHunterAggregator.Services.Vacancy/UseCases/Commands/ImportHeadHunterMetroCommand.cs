using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterMetroCommand : IRequest<bool>
    {
        public IReadOnlyCollection<CityDto> Cities { get; }

        public ImportHeadHunterMetroCommand(IReadOnlyCollection<CityDto> cities)
        {
            Cities = cities;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterMetroCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterMetroCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly IMetroLineMapper _metroLineMapper;
            private readonly IMetroStationMapper _metroStationMapper;

            private readonly IAreaRepository _areaRepository;
            private readonly IMetroLineRepository _metroLineRepository;
            private readonly IMetroStationRepository _metroStationRepository;

            public Handler(IUnitOfWork unitOfWork, IMetroLineMapper metroLineMapper, IMetroStationMapper metroStationMapper, 
                IAreaRepository areaRepository, IMetroLineRepository metroLineRepository, IMetroStationRepository metroStationRepository)
            {
                _unitOfWork = unitOfWork;

                _metroLineMapper = metroLineMapper;
                _metroStationMapper = metroStationMapper;

                _areaRepository = areaRepository;
                _metroLineRepository = metroLineRepository;
                _metroStationRepository = metroStationRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterMetroCommand request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        foreach (var city in request.Cities)
                        {
                            if (city.Lines?.Count > 0)
                            {
                                var area = await _areaRepository.FindOneByHeadHunterIdAsync(city.Id);

                                await ImportMetroLinesAsync(city.Lines, area.Id, cancellationToken);
                            }
                        }

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync(cancellationToken);

                        return false;
                    }
                }
            }

            private async Task ImportMetroLinesAsync(IReadOnlyCollection<MetroLineDto> metroLines, Guid areaId, 
                CancellationToken cancellationToken = default)
            {
                foreach (var metroLine in metroLines)
                {
                    var entity = _metroLineMapper.Map(metroLine);

                    entity.AreaId = areaId;

                    var item = await _metroLineRepository.FindOneByHeadHunterIdOrAddAsync(entity, metroLine.Id, 
                        cancellationToken);

                    if (metroLine.Stations?.Count > 0)
                    {
                        await ImportMetroStationsAsync(metroLine.Stations, item.Id, cancellationToken);
                    }
                }
            }

            private async Task ImportMetroStationsAsync(IReadOnlyCollection<MetroStationDto> metroStations, Guid metroLineId,
                CancellationToken cancellationToken = default)
            {
                foreach (var metroStation in metroStations)
                {
                    var enriry = _metroStationMapper.Map(metroStation);

                    enriry.MetroLineId = metroLineId;

                    await _metroStationRepository.FindOneByHeadHunterIdOrAddAsync(enriry, metroStation.Id, 
                        cancellationToken);
                }
            }
        }
    }
}
