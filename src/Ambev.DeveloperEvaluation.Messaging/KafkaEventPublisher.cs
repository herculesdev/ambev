using Ambev.DeveloperEvaluation.Domain.Publishers;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Messaging;

public class KafkaEventPublisher : IEventPublisher
{
    private readonly ILogger<KafkaEventPublisher> _logger;
    public KafkaEventPublisher(ILogger<KafkaEventPublisher> logger)
    {
        _logger = logger;
    }

    public Task PublishAsync<T>(T @event) where T : class
    {
        _logger.LogInformation("Publishing event: {@event}", @event);
        return Task.CompletedTask;
    }
}
