using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IScheduleFactory : IFactory<ResponseModels.Schedule?, Entities.Schedule?>
    {

    }

    internal class ScheduleFactory : IScheduleFactory
    {
        public Entities.Schedule? Create(ResponseModels.Schedule? input)
        {
            if (input == null) return null;

            return new Entities.Schedule
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
