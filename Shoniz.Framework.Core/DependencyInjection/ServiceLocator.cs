﻿
using Microsoft.Extensions.DependencyInjection;

namespace Shoniz.Framework.Core.DependencyInjection;

public class ServiceLocator
{
    private ServiceProvider _currentServiceProvider;
    private static ServiceProvider _serviceProvider;

    public ServiceLocator(ServiceProvider currentServiceProvider)
    {
        _currentServiceProvider = currentServiceProvider;
    }

    public static ServiceLocator Current
    {
        get
        {
            return new ServiceLocator(_serviceProvider);
        }
    }

    public static void SetLocatorProvider(ServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object GetInstance(Type serviceType)
    {
        return _currentServiceProvider.GetService(serviceType);
    }

    public TService Resolve<TService>()
    {
        return _currentServiceProvider.GetService<TService>();
    }
}