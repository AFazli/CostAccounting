using Microsoft.AspNetCore.Mvc;
using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Facade.Contracts;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;

namespace Shoniz.CostAccounting.Api.Controllers.FormulationContext
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulationDetailController : ControllerBase
    {
        public IFormulationQueryFacade formulationQueryfacade { get; }
        public IFormulationCommandFacade formulationCommandFacade { get; }

        public FormulationDetailController(
            IFormulationQueryFacade formulationQueryfacade,
            IFormulationCommandFacade formulationCommandFacade)
        {
            this.formulationQueryfacade = formulationQueryfacade;
            this.formulationCommandFacade = formulationCommandFacade;
        }

        [HttpPost]
        public ActionResult<IActionResult> CreateFormulationDetail([FromBody] AddFormulationDetailCommand command)
        {
            try
            {
                command.Registrar = "931524";

                formulationCommandFacade.CreateFormulationDetail(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<FormulationDetailDto>>> GetFormulationDetails(Guid id)
        {
            try
            {
                var getFormulationDetail = await formulationQueryfacade.GetFormulationDetails(id);

                if (getFormulationDetail == null)
                {
                    return NoContent();
                }

                return Ok(getFormulationDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public ActionResult DeleteFormulationDetail(Guid id)
        {
            try
            {
                var command = new DeleteFormulationDetailCommand
                {
                    FormulationId = id
                };

                formulationCommandFacade.DeleteFormulationDetail(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}