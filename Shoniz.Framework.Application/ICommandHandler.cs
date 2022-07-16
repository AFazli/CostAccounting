using Shoniz.Framework.Core.Application;

namespace Shoniz.Framework.Application
{
    public interface ICommandHandler<in TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}