using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IWorkingDayFactory : IFactory<ResponseModels.WorkingDay?, Entities.WorkingDay?>
    {

    }

    internal class WorkingDayFactory : IWorkingDayFactory
    {
        public Entities.WorkingDay? Create(ResponseModels.WorkingDay? input)
        {
            if (input == null) return null;

            return new Entities.WorkingDay
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
