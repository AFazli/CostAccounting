using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Persistence;
using System.Linq.Expressions;

namespace Shoniz.CostAccounting.FormulationContext.Pesistence.FormulationAggregate
{
    public class FormulationRepository : RepositoryBase<Formulation>, IFormulationRepository
    {
        public FormulationRepository(IDbContext context) : base(context)
        {
        }

        public bool IsDuplicatedGoodsCodeAndStartDate(Guid productCode, DateTime startDate)
        {
            return Exist(p => p.ProductCode == productCode && p.StartDate.Date == startDate.Date);
        }
    }
}
