using Shoniz.Framework.Core.Application;
using Shoniz.Framework.Core.DependencyInjection;
using Shoniz.Framework.Persistence;

namespace Shoniz.Framework.Application;

internal class TransactionalCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
{
    private readonly ICommandHandler<TCommand> _commandHandler;

    public TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public void Execute(TCommand command)
    {
        var unitOfWork = ServiceLocator.Current.Resolve<IUnitOfWork>();

        try
        {
            _commandHandler.Execute(command);
            unitOfWork.Commit();

        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }
}