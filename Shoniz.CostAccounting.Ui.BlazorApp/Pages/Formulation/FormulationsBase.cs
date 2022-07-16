using Microsoft.AspNetCore.Components;
using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Pages
{
    public class FormulationsBase : ComponentBase
    {
        [Inject]
        public IFormulationService FormulationService { get; set; }

        public IEnumerable<FormulationDto> Formulations { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Formulations = await FormulationService.GetFormulations(); 
        }

        protected async Task CreateFormulation_Click(CreateFormulationCommand command)
        {
            try
            {
                var formulationDto = await FormulationService.CreateFormulation(command);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Reload()
        {
            await OnReadData();
        }

        private async Task OnReadData()
        {
            Formulations = await FormulationService.GetFormulations();
        }
    }
}
