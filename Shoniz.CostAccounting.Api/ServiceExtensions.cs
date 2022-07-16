using System.Reflection;
using Shoniz.Framework.Application;
using Shoniz.Framework.Core.Application;
using Shoniz.Framework.Core.DependencyInjection;
using Shoniz.Framework.Core.Security;
using Shoniz.Framework.Persistence;
using Shoniz.Framework.Read;
using Shoniz.Framework.Security;
using Shoniz.CostAccounting.Database;
using Shoniz.CostAccounting.Read.Queries.Facade.FormulationContext.FormulationAggregate;
using Shoniz.MRP.ProductionLineContext.Configuration;

namespace Shoniz.CostAccounting.Api
{
    public static class ServiceExtensions
    {
        public static void RegisterCostAccountingDependencies(this IServiceCollection services)
        {
            //singleton
            services.AddSingleton<IHashProvider, HashProvider>();

            //web: PerWebRequest
            //Windows: RequestContext
            //WebService: PerOperationContext
            services.AddScoped<IDbContext, CostAccountingDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICommandBus, CommandBus>();

            Assembly.GetAssembly(typeof(FormulationQueryFacade))
                ?.GetTypes()
                .Where(x => typeof(IQueryFacade).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });

            new Registrar().Register(services);

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
        }
    }
}
