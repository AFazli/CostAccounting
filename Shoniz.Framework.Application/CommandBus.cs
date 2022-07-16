using Shoniz.Framework.Core.Application;
using Shoniz.Framework.Core.DependencyInjection;

namespace Shoniz.Framework.Application;

public class CommandBus : ICommandBus
{
    public void Dispatch<TCommand>(TCommand command) where TCommand : Command
    {
        var commandHandler = ServiceLocator.Current.Resolve<ICommandHandler<TCommand>>();
        var transactionalCommandHandler = new TransactionalCommandHandler<TCommand>(commandHandler);
        var logCommandHandler = new LogCommandHandler<TCommand>(transactionalCommandHandler);
        var exceptionHandler = new ExceptionHandler<TCommand>(logCommandHandler);
        exceptionHandler.Execute(command);
    }
}