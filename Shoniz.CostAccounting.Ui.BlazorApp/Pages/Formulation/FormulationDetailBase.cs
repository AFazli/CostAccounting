using Microsoft.AspNetCore.Components;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Pages
{
    public class FormulationDetailBase : ComponentBase
    {
        [Parameter]
        public Guid FormulationId { get; set; }

        [Inject]
        public IFormulationService FormulationService { get; set; }

        [Inject]
        public IFormulationDetailService FormulationDetailService { get; set; }

        public decimal SumUsedAmount { get; set; }

        public FormulationDto Formulation { get; set; }

        public IEnumerable<FormulationDetailDto> FormulationDetails { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Formulation = await FormulationService.GetFormulation(FormulationId);
                FormulationDetails = await FormulationDetailService.GetFormulationDetails(FormulationId);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
