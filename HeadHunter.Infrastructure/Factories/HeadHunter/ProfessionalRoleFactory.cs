using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IProfessionalRoleFactory : IFactory<ResponseModels.ProfessionalRole?, Entities.ProfessionalRole?>
    {

    }

    internal class ProfessionalRoleFactory : IProfessionalRoleFactory
    {
        public Entities.ProfessionalRole? Create(ResponseModels.ProfessionalRole? input)
        {
            if (input == null) return null;

            return new Entities.ProfessionalRole
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
