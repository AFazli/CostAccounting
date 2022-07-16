using Shoniz.Framework.Core.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate
{
    public class RemoveConfirmFormulationCommand : Command
    {
        public Guid FormulationId { get; set; }
    }
}
