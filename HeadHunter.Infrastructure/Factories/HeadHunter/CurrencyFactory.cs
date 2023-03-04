using HeadHunter.Core.Abstracts;
using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.MongoDB.Entities;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface ICurrencyFactory : IFactory<string?, Currency?>
    {

    }

    internal class CurrencyFactory : ICurrencyFactory
    {
        public Currency? Create(string? input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            return new Currency
            {
                HeadHunterId = input,
            };
        }
    }
}
