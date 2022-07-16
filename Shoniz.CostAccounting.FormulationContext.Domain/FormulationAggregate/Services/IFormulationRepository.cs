using Shoniz.Framework.Core.Persistence;

namespace Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services
{
    public interface IFormulationRepository : IRepository<Formulation>
    {
        void Add(Formulation formulation);
        Formulation Get(Guid formulationId);
        void Delete(Formulation formulation);
        bool IsDuplicatedGoodsCodeAndStartDate(Guid goodsCode, DateTime startDate);
    }
}
