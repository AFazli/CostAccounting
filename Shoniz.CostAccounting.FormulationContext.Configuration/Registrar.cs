using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shoniz.CostAccounting.FormulationContext.ACL;
using Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.Services.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Facade;
using Shoniz.CostAccounting.FormulationContext.Pesistence.FormulationAggregate;
using Shoniz.Framework.ACL;
using Shoniz.Framework.Application;
using Shoniz.Framework.Core.Persistence;
using Shoniz.Framework.DependencyInjection;
using Shoniz.Framework.Domain;
using Shoniz.Framework.Facade;

namespace Shoniz.MRP.ProductionLineContext.Configuration
{
    public class Registrar : IRegistrar
    {
        public void Register(IServiceCollection services)
        {
            Assembly.GetAssembly(typeof(CreateFormulationCommandHandler))?
               .GetTypes()
               .Where(t => t.GetInterfaces().Any(x => x.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
               .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
               .ToList()
               .ForEach(typesToRegister =>
               {
                   typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
               });

            Assembly.GetAssembly(typeof(FormulationCommandFacade))?
                .GetTypes()
                .Where(t => typeof(FacadeCommandBase).IsAssignableFrom(t))
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });

            Assembly.GetAssembly(typeof(DuplicatedProductCodeAndStartDateChecker))?
                .GetTypes()
                .Where(t => typeof(IDomainService).IsAssignableFrom(t))
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });

            Assembly.GetAssembly(typeof(FormulationRepository))?
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(x => x.GetInterfaces().Any(z => z.GetGenericTypeDefinition() == typeof(IRepository<>))))
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });

            Assembly.GetAssembly(typeof(WarehouseAclService))?.GetTypes()
                 .Where(t => typeof(IAclService).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                 .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                 .ToList()
                 .ForEach(typesToRegister =>
                 {
                     typesToRegister.serviceTypes.ForEach(typeToRegister =>
                         services.AddScoped(typeToRegister, typesToRegister.assignedType));
                 });
        }
    }
}