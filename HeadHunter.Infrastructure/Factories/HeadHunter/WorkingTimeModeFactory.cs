using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IWorkingTimeModeFactory : IFactory<ResponseModels.WorkingTimeMode?,
        Entities.WorkingTimeMode?>
    {

    }

    internal class WorkingTimeModeFactory : IWorkingTimeModeFactory
    {
        public Entities.WorkingTimeMode? Create(ResponseModels.WorkingTimeMode? input)
        {
            if (input == null) return null;

            return new Entities.WorkingTimeMode
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
