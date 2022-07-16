using Microsoft.EntityFrameworkCore;
using Shoniz.CostAccounting.Read.Context.Models.FormulationContext;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;

namespace Shoniz.CostAccounting.Read.Queries.Facade.FormulationContext.FormulationAggregate
{
    public class FormulationQueryFacade : IFormulationQueryFacade
    {
        private readonly FormulationDbContext _context;

        public FormulationQueryFacade()
        {
            _context = new FormulationDbContext();
        }

        public async Task<IEnumerable<FormulationDto>> GetFormulations()
        {
            return await (from formulation in _context.Formulations
                          select new FormulationDto
                          {
                              Id = formulation.Id,
                              Timestamp = formulation.Timestamp,
                              StartDate = formulation.StartDate,
                              HumidityPercent = formulation.HumidityPercent,
                              ProductCode = formulation.ProductCode,
                              RegulatorUserId = formulation.RegulatorUserId,
                              RegulatorDateTime = formulation.RegulatorDateTime,
                              ConfirmerUserId = formulation.ConfirmerUserId,
                              ConfirmerDateTime = formulation.ConfirmerDateTime
                          }).ToListAsync();
        }

        public async Task<IEnumerable<FormulationDetailDto>> GetFormulationDetails(Guid formulationId)
        {
            return await (from formulationDetail in _context.FormulationDetails
                          where formulationDetail.FormulationId == formulationId
                          select new FormulationDetailDto
                          {
                              Id = formulationDetail.Id,
                              FormulationId = formulationDetail.FormulationId,
                              UsedAmount = formulationDetail.UsedAmount,
                              Mammock = formulationDetail.Mammock,
                              GoodsCode = formulationDetail.GoodsCode,
                              RegistrarUserId = formulationDetail.RegistrarUserId,
                              RegistrarDateTime = formulationDetail.RegistrarDateTime
                          }).ToListAsync();

        }

        public async Task<FormulationDto> GetFormulation(Guid formulationId)
        {
            return await (from formulation in _context.Formulations
                          where formulation.Id == formulationId
                          select new FormulationDto
                          {
                              Id = formulation.Id,
                              Timestamp = formulation.Timestamp,
                              StartDate = formulation.StartDate,
                              HumidityPercent = formulation.HumidityPercent,
                              ProductCode = formulation.ProductCode,
                              RegulatorUserId = formulation.RegulatorUserId,
                              RegulatorDateTime = formulation.RegulatorDateTime,
                              ConfirmerUserId = formulation.ConfirmerUserId,
                              ConfirmerDateTime = formulation.ConfirmerDateTime
                          }).SingleOrDefaultAsync();
        }

        public async Task<FormulationDetailDto> GetFormulationDetail(Guid formulationDetailId)
        {
            return await (from formulationDetail in _context.FormulationDetails
                          where formulationDetail.Id == formulationDetailId
                          select new FormulationDetailDto
                          {
                              Id = formulationDetail.Id,
                              FormulationId = formulationDetail.FormulationId,
                              UsedAmount = formulationDetail.UsedAmount,
                              Mammock = formulationDetail.Mammock,
                              GoodsCode = formulationDetail.GoodsCode,
                              RegistrarUserId = formulationDetail.RegistrarUserId,
                              RegistrarDateTime = formulationDetail.RegistrarDateTime
                          }).SingleOrDefaultAsync();
        }
    }
}
