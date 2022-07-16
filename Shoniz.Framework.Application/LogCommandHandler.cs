using Shoniz.Framework.Core.Application;

namespace Shoniz.Framework.Application;

internal class LogCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
{
    private readonly ICommandHandler<TCommand> _commandHandler;

    public LogCommandHandler(ICommandHandler<TCommand> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public void Execute(TCommand command)
    {
        _commandHandler.Execute(command);

        // log (ILogger)
    }
}