using Shoniz.Framework.Core.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate
{
    public class RegulateFormulationCommand : Command
    {
        public Guid FormulationId { get; set; }
        public string? Regulator { get; set; }
    }
}
