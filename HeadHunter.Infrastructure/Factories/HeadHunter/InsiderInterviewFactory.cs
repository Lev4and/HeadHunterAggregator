using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IInsiderInterviewFactory : IFactory<ResponseModels.InsiderInterview?, Entities.InsiderInterview?>
    {

    }

    internal class InsiderInterviewFactory : IInsiderInterviewFactory
    {
        public Entities.InsiderInterview? Create(ResponseModels.InsiderInterview? input)
        {
            if (input == null) return null;

            return new Entities.InsiderInterview
            {
                HeadHunterId = input.Id, 
                Url = input.Url
            };
        }
    }
}
