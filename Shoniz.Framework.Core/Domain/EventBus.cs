namespace Shoniz.Framework.Core.Domain;

public class EventBus : IEventBus
{
    private readonly IList<EventSubscriptionItem> _subscriptionList;

    public EventBus()
    {
        _subscriptionList = new List<EventSubscriptionItem>();
    }

    public void Publish<TEvent>(TEvent @event)
    {
        var existingEvent = _subscriptionList.SingleOrDefault(item => item.EventType == typeof(TEvent));

        if (existingEvent != null)
        {
            foreach (var handler in existingEvent.Handlers)
            {
                handler.Action(@event);
            }
        }
    }

    public void Subscribe<TEvent>(Action<dynamic> action)
    {
        var existingEvent = _subscriptionList.SingleOrDefault(item => item.EventType == typeof(TEvent));

        if (existingEvent is null)
        {
            var newSubscription = new EventSubscriptionItem()
            {
                EventType = typeof(TEvent),
                Handlers = new List<EventHandler>() { new EventHandler(action) }
            };

            _subscriptionList.Add(newSubscription);
        }
        else
        {
            existingEvent.Handlers.Add(new EventHandler(action));
        }
    }
}