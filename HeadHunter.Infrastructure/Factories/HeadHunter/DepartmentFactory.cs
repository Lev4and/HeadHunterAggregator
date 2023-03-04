using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IDepartmentFactory : IFactory<ResponseModels.Department?, Entities.Department?>
    {

    }

    internal class DepartmentFactory : IDepartmentFactory
    {
        public Entities.Department? Create(ResponseModels.Department? input)
        {
            if (input == null) return null;

            return new Entities.Department
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
