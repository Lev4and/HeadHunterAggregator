using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
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
            private readonly IAreaRepository _areaRepository;
            private readonly IMetroLineRepository _metroLineRepository;
            private readonly IMetroStationRepository _metroStationRepository;

            public Handler(IUnitOfWork unitOfWork, IAreaRepository areaRepository, IMetroLineRepository metroLineRepository, 
                IMetroStationRepository metroStationRepository)
            {
                _unitOfWork = unitOfWork;
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

                                await SaveMetroLines(city.Lines, area.Id, cancellationToken);
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

            private async Task SaveMetroLines(IReadOnlyCollection<MetroLineDto> metroLines, Guid areaId, 
                CancellationToken cancellationToken = default)
            {
                foreach (var metroLine in metroLines)
                {
                    var item = await _metroLineRepository.FindOneByHeadHunterIdOrAddAsync(new MetroLine()
                    { AreaId = areaId, HeadHunterId = metroLine.Id, Name = metroLine.Name, HexColor = metroLine.HexColor },
                        metroLine.Id, cancellationToken);

                    if (metroLine.Stations?.Count > 0)
                    {
                        await SaveMetroStations(metroLine.Stations, item.Id, cancellationToken);
                    }
                }
            }

            private async Task SaveMetroStations(IReadOnlyCollection<MetroStationDto> metroStations, Guid metroLineId,
                CancellationToken cancellationToken = default)
            {
                foreach (var metroStation in metroStations)
                {
                    await _metroStationRepository.FindOneByHeadHunterIdOrAddAsync(new MetroStation()
                        { MetroLineId = metroLineId, Order = metroStation.Order, HeadHunterId = metroStation.Id, 
                            Name = metroStation.Name, Latitude = metroStation.Latitude, Longitude = metroStation.Longitude }, 
                                metroStation.Id, cancellationToken);
                }
            }
        }
    }
}
