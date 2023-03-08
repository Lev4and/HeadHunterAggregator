using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Extensions;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IAreaFactory : IFactory<ResponseModels.Area?, Entities.Area?>
    {

    }

    internal class AreaFactory : IAreaFactory
    {
        private readonly IAreaFactory _areaFactory;

        public AreaFactory()
        {
            _areaFactory = this;
        }

        public Entities.Area? Create(ResponseModels.Area? input)
        {
            if (input == null) return null;

            return new Entities.Area
            {
                HeadHunterId = input.Id, 
                Name = input.Name,
                Children = _areaFactory.CreateArray(input.Areas?.ToArray())
            };
        }
    }
}
