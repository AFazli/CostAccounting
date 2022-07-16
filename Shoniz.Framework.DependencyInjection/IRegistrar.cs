using Microsoft.Extensions.DependencyInjection;

namespace Shoniz.Framework.DependencyInjection;

public interface IRegistrar
{
    void Register(IServiceCollection serviceCollection);
}