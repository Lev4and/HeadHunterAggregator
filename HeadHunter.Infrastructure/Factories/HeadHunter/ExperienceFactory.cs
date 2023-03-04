using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IExperienceFactory : IFactory<ResponseModels.Experience?, Entities.Experience?>
    {

    }

    internal class ExperienceFactory : IExperienceFactory
    {
        public Entities.Experience? Create(ResponseModels.Experience? input)
        {
            if (input == null) return null;

            return new Entities.Experience
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
