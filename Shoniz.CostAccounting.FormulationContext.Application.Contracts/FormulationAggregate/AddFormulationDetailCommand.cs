using Shoniz.Framework.Core.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate
{
    public class AddFormulationDetailCommand : Command
    {
        public Guid FormulationId { get; set; }
        public string GoodsCode { get; set; }
        public decimal UsedAmount { get; set; }
        public decimal Mammock { get; set; }
        public string Registrar { get; set; }
    }
}
