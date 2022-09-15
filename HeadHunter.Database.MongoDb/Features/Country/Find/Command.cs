﻿using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Country.Find
{
    public class Command : IRequest<Collections.Country>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }

        public Command(string name, string headHunterId)
        {
            Name = name;
            HeadHunterId = headHunterId;
        }
    }
}