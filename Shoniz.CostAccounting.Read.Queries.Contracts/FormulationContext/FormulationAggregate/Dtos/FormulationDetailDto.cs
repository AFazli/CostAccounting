using System.ComponentModel.DataAnnotations;

namespace Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos
{
    public class FormulationDetailDto
    {
        public Guid Id { get; set; }
        public Guid FormulationId { get; set; }

        [Display(Name ="مقدار استفاده شده")]
        public decimal UsedAmount { get; set; }
        public decimal Mammock { get; set; }
        public Guid GoodsCode { get; set; }
        public string RegistrarUserId { get; set; }
        public DateTime RegistrarDateTime { get; set; }
    }
}