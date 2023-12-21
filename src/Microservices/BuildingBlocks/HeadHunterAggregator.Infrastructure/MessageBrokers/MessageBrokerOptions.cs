using HeadHunterAggregator.Infrastructure.MessageBrokers.RabbitMQ;

namespace HeadHunterAggregator.Infrastructure.MessageBrokers
{
    public class MessageBrokerOptions
    {
        public RabbitMQOptions RabbitMQ { get; set; }
    }
}
