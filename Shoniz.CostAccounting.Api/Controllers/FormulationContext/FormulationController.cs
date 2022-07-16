using Microsoft.AspNetCore.Mvc;
using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Facade.Contracts;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.CostAccounting.Read.Queries.Contracts.WarehouseService;
using Shoniz.CostAccounting.Read.Queries.Contracts.WarehouseService.Dto;

namespace Shoniz.CostAccounting.Api.Controllers.FormulationContext
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulationController : ControllerBase
    {
        private readonly IWarehouseServiceFacade warehouseServiceFacade;

        public IFormulationQueryFacade formulationQueryfacade { get; }
        public IFormulationCommandFacade formulationCommandFacade { get; }

        public FormulationController(
            IFormulationQueryFacade formulationQueryfacade,
            IFormulationCommandFacade formulationCommandFacade,
            IWarehouseServiceFacade warehouseServiceFacade)
        {
            this.formulationQueryfacade = formulationQueryfacade;
            this.formulationCommandFacade = formulationCommandFacade;
            this.warehouseServiceFacade = warehouseServiceFacade;
        }

        [HttpPost]
        public ActionResult CreateFormulation([FromBody] CreateFormulationCommand command)
        {
            try
            {
                formulationCommandFacade.CreateFormulation(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id:guid}")]
        public ActionResult DeleteFormulation(Guid id)
        {
            try
            {
                var command = new DeleteFormulationCommand
                {
                    FormulationId = id
                };

                formulationCommandFacade.DeleteFormulation(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Regulate")]
        public ActionResult RegulateFormulation([FromBody] RegulateFormulationCommand command)
        {
            try
            {
                command.Regulator = "931524";

                formulationCommandFacade.RegulateFormulation(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("RemoveRegulate")]
        public ActionResult RemoveRegulateFormulation([FromBody] RemoveRegulateFormulationCommand command)
        {
            try
            {
                formulationCommandFacade.RemoveRegulateFormulation(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Confirm")]
        public ActionResult ConfirmFormulation([FromBody] ConfirmFormulationCommand command)
        {
            try
            {
                command.Confirmer = "931524";

                formulationCommandFacade.ConfirmFormulation(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("RemoveConfirm")]
        public ActionResult RemoveConfirmFormulation([FromBody] RemoveConfirmFormulationCommand command)
        {
            try
            {
                formulationCommandFacade.RemoveConfirmFormulation(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormulationDto>>> GetFormulations()
        {
            try
            {
                var getFormulations = await formulationQueryfacade.GetFormulations();

                if (getFormulations == null)
                {
                    return NoContent();
                }

                return Ok(getFormulations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FormulationDto>> GetFormulation(Guid id)
        {
            try
            {
                var getFormulation = await formulationQueryfacade.GetFormulation(id);

                if (getFormulation == null)
                {
                    return NoContent();
                }

                return Ok(getFormulation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{goodsCode}")]
        public async Task<ActionResult<GoodsCodingDto>> GetCodingByGoodsCode(string goodsCode)
        {
            try
            {
                var goodsCodingDto = await warehouseServiceFacade.GetCodingByGoodsCode(goodsCode);

                if (goodsCodingDto == null)
                {
                    return NoContent();
                }

                return Ok(goodsCodingDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
