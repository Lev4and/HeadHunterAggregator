﻿using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Find
{
    public class Command : IRequest<Collections.Specialization>
    {
        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
