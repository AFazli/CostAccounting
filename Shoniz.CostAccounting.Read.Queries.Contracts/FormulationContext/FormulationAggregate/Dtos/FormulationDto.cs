using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature;

namespace Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos
{
    public class FormulationDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public decimal HumidityPercent { get; set; }
        public Guid ProductCode { get; set; }
        public DateTime Timestamp { get; set; }
        public string RegulatorUserId { get; set; }
        public DateTime RegulatorDateTime { get; set; }
        public string ConfirmerUserId { get; set; }
        public DateTime ConfirmerDateTime { get; set; }
    }
}
