using HeadHunter.Core.Abstracts;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.MongoDB.Entities;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IEmployerLogoFactory : IFactory<ResponseModels.LogoUrls?, Entities.EmployerLogo?>
    {

    }

    internal class EmployerLogoFactory : IEmployerLogoFactory
    {
        public EmployerLogo? Create(LogoUrls? input)
        {
            if (input == null) return null;

            return new EmployerLogo
            {
                Small = input.Small, 
                Normal = input.Normal, 
                Original = input.Original
            };
        }
    }
}
