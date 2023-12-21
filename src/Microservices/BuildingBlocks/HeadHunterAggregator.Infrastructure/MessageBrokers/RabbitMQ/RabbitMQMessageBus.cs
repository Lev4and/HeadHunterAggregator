using HeadHunterAggregator.Domain.Infrastructure.MessageBrokers;
using MassTransit;

namespace HeadHunterAggregator.Infrastructure.MessageBrokers.RabbitMQ
{
    public class RabbitMQMessageBus : IMessageBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMQMessageBus(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
            where TMessage : class
        {
            await _publishEndpoint.Publish(message, cancellationToken);
        }
    }
}
