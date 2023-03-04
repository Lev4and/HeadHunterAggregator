using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IWorkingTimeIntervalFactory : IFactory<ResponseModels.WorkingTimeInterval?,
        Entities.WorkingTimeInterval?>
    {

    }

    internal class WorkingTimeIntervalFactory : IWorkingTimeIntervalFactory
    {
        public Entities.WorkingTimeInterval? Create(ResponseModels.WorkingTimeInterval? input)
        {
            if (input == null) return null;

            return new Entities.WorkingTimeInterval
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
