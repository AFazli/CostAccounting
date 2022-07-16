using Shoniz.Framework.Core.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate
{
    public class DeleteFormulationDetailCommand : Command
    {
        public Guid FormulationId { get; set; }
        public Guid FormulationDetailId { get; set; }
    }
}
