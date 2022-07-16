using System;
using System.Collections.Generic;

namespace Shoniz.CostAccounting.Read.Context.Models.FormulationContext
{
    public partial class FormulationDetail
    {
        public Guid Id { get; set; }
        public Guid GoodsCode { get; set; }
        public decimal UsedAmount { get; set; }
        public decimal Mammock { get; set; }
        public Guid FormulationId { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal CalculateFormulationDroppedAmount { get; set; }
        public decimal CalculateFormulationDroppedPercent { get; set; }
        public decimal CalculateFormulationUsedPercent { get; set; }
        public DateTime RegistrarDateTime { get; set; }
        public string RegistrarUserId { get; set; } = null!;

        public virtual Formulation Formulation { get; set; } = null!;
    }
}
