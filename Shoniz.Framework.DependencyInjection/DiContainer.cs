using Shoniz.Framework.Core.DependencyInjection;

namespace Shoniz.Framework.DependencyInjection
{
    public class DiContainer : IDiContainer
    {
        private readonly IServiceProvider _serviceProvider;

        public DiContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
