using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IVacancyTypeFactory : IFactory<ResponseModels.VacancyType?, Entities.VacancyType?>
    {

    }

    internal class VacancyTypeFactory : IVacancyTypeFactory
    {
        public Entities.VacancyType? Create(ResponseModels.VacancyType? input)
        {
            if (input == null) return null;

            return new Entities.VacancyType
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
