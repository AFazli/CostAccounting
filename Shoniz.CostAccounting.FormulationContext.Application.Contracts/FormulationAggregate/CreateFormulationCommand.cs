using Shoniz.Framework.Core.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate
{
    public class CreateFormulationCommand : Command
    {
        public string StartDate { get; set; }
        public decimal HumidityPercent { get; set; }
        public Guid ProductCode { get; set; }
        public decimal Scale { get; set; }
    }
}
