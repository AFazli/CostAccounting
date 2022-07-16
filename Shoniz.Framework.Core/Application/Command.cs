namespace Shoniz.Framework.Core.Application;

public abstract class Command
{
    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; set; }
}