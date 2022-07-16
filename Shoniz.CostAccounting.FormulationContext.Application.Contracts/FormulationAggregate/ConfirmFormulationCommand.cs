using Shoniz.Framework.Core.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate
{
    public class ConfirmFormulationCommand : Command
    {
        public Guid FormulationId { get; set; }
        public string? Confirmer { get; set; }
    }
}
