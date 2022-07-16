using Shoniz.Framework.Core.Application;
using Shoniz.Framework.Core.DependencyInjection;
using Shoniz.Framework.Core.Domain;

namespace Shoniz.Framework.Facade
{
    public abstract class FacadeCommandBase
    {
        protected FacadeCommandBase(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }

        protected ICommandBus CommandBus { get; set; }
        protected IEventBus EventBus => ServiceLocator.Current.Resolve<IEventBus>();
    }
}