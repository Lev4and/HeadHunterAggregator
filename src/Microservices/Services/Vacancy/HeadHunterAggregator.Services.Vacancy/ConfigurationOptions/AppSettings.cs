using HeadHunterAggregator.Infrastructure.MessageBrokers;
using HeadHunterAggregator.Services.Vacancy.Databases;

namespace HeadHunterAggregator.Services.Vacancy.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public MessageBrokerOptions MessageBroker { get; set; }
    }
}
