using Microsoft.Extensions.DependencyInjection;
using Shoniz.Framework.Core.DependencyInjection;

namespace Shoniz.Framework.DependencyInjection
{
    public abstract class RegistrarBase : IRegistrar
    {
        protected readonly IServiceCollection serviceCollection;

        protected RegistrarBase(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
            RegisterDiContainer();
        }
        public abstract void Register();

        public void Register(IServiceCollection serviceCollection)
        {
            throw new NotImplementedException();
        }

        private void RegisterDiContainer()
        {
            serviceCollection.AddTransient<IDiContainer, DiContainer>();
        }
    }
}
