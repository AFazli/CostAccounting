using Microsoft.AspNetCore.Components;
using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Pages.Formulation.Components
{
    public class DisplayFormulationsBase : ComponentBase
    {
        [Inject]
        public IFormulationDetailService FormulationDetailService { get; set; }

        [Inject]
        public IFormulationService FormulationService { get; set; }

        [Parameter]
        public IEnumerable<FormulationDto> Formulations { get; set; }

        protected async Task DeleteFormulation_Click(Guid id)
        {
            try
            {
                var formulationDto = await FormulationService.DeleteFormulation(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async Task RegulatorSignFormulation_Click(Guid id)
        {
            try
            {
                var command = new RegulateFormulationCommand
                {
                    FormulationId = id
            };

                var formulationDto = await FormulationService.RegulateFormulation(command);

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected async Task RemoveRegulatorSignFormulation_Click(Guid id)
        {
            try
            {
                var command = new RemoveRegulateFormulationCommand
                {
                    FormulationId = id
                };

                var formulationDto = await FormulationService.RemoveRegulateFormulation(command);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async Task ConfirmSignFormulation_Click(Guid id)
        {
            try
            {
                var command = new ConfirmFormulationCommand
                {
                    FormulationId = id
                };

                var formulationDto = await FormulationService.ConfirmFormulation(command);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async Task RemoveConfirmSignFormulation_Click(Guid id)
        {
            try
            {
                var command = new RemoveConfirmFormulationCommand
                {
                    FormulationId = id
                };

                var formulationDto = await FormulationService.RemoveConfirmFormulation(command);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
