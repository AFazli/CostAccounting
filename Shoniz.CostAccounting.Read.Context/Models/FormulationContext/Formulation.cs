using System;
using System.Collections.Generic;

namespace Shoniz.CostAccounting.Read.Context.Models.FormulationContext
{
    public partial class Formulation
    {
        public Formulation()
        {
            FormulationDetails = new HashSet<FormulationDetail>();
        }

        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public decimal HumidityPercent { get; set; }
        public Guid ProductCode { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ConfirmerDateTime { get; set; }
        public string? ConfirmerUserId { get; set; }
        public DateTime RegulatorDateTime { get; set; }
        public string? RegulatorUserId { get; set; }
        public decimal Scale { get; set; }

        public virtual ICollection<FormulationDetail> FormulationDetails { get; set; }
    }
}
