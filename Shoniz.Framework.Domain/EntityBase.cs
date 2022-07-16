using Shoniz.Framework.Core.DependencyInjection;
using Shoniz.Framework.Core.Domain;

namespace Shoniz.Framework.Domain
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime Timestamp { get; private set; }

        protected IEventBus EventBus => ServiceLocator.Current.Resolve<IEventBus>();
    }
}
