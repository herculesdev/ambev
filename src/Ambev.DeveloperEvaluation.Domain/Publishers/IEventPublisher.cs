namespace Ambev.DeveloperEvaluation.Domain.Publishers;

public interface IEventPublisher
{
    Task PublishAsync<T>(T @event) where T : class;
}
