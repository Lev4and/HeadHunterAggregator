﻿using HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.GetAll
{
    public class CommandHandler : IRequestHandler<Command, List<Collections.MetroStation>>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;

            MetroStationAggregateExtensions.Init(_repository);
        }

        public async Task<List<Collections.MetroStation>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.Aggregate<Collections.MetroStation>()
                .WithLine()
                .WithLineArea()
                .SortBy(metroStation => metroStation.Name)
                .ToListAsync();
        }
    }
}
