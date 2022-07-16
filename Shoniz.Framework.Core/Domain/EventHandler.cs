namespace Shoniz.Framework.Core.Domain;

internal class EventHandler
{
    public Action<object> Action;

    public EventHandler(Action<object> action)
    {
        Action = action;
    }
}