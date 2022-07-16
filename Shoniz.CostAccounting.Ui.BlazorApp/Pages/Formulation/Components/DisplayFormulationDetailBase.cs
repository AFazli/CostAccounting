using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Pages.Formulation.Components
{
    public class DisplayFormulationDetailBase : ComponentBase
    {
        [Inject]
        public IFormulationService FormulationService { get; set; }

        [Inject]
        public IFormulationDetailService FormulationDetailService { get; set; }

        [Parameter]
        public IEnumerable<FormulationDetailDto> FormulationDetails { get; set; }

        public decimal SumUsedAmount { get; set; }

        public int TotalFormulationDetail { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                SumUsedAmount = FormulationDetails.Sum(f => f.UsedAmount);
                TotalFormulationDetail = FormulationDetails.Count();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteFormulationDetail_Click(Guid id)
        {
            try
            {
                var formulationDetailDto = await FormulationDetailService.DeleteFormulationDetail(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
