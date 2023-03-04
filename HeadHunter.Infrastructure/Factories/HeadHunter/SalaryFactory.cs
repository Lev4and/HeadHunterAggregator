using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface ISalaryFactory : IFactory<ResponseModels.Salary?, Entities.Salary?>
    {

    }

    internal class SalaryFactory : ISalaryFactory
    {
        private readonly ICurrencyFactory _currencyFactory;

        public SalaryFactory(ICurrencyFactory currencyFactory)
        {
            _currencyFactory = currencyFactory;
        }

        public Entities.Salary? Create(ResponseModels.Salary? input)
        {
            if (input == null) return null;

            return new Entities.Salary
            {
                Gross = input.Gross, 
                To = input.To, 
                From = input.From, 
                Currency = _currencyFactory.Create(input.Currency)
            };
        }
    }
}
