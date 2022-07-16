namespace Shoniz.Framework.Core.Domain;

public interface IEventBus
{
    void Publish<TEvent>(TEvent @event);
    void Subscribe<TEvent>(Action<dynamic> action);
}