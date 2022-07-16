using Shoniz.Framework.Domain;

namespace Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services
{
    public interface IDuplicatedProductCodeAndStartDateChecker :IDomainService
    {
        bool IsDuplicated(Guid goodsCode, DateTime startDate);
    }
}
