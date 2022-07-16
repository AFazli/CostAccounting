using Shoniz.Framework.Core.Application;

namespace Shoniz.Framework.Application;

internal class ExceptionHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
{
    private readonly ICommandHandler<TCommand> _commandHandler;

    public ExceptionHandler(ICommandHandler<TCommand> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public void Execute(TCommand command)
    {
        try
        {
            _commandHandler.Execute(command);
        }
        catch (Exception e)
        {
            // handle exception
            throw;
        }
    }
}