using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;

namespace Shoniz.CostAccounting.FormulationContext.Domain.Services.FormulationAggregate
{
    public class DuplicatedProductCodeAndStartDateChecker : IDuplicatedProductCodeAndStartDateChecker
    {
        public IFormulationRepository formulationRepository { get; }

        public DuplicatedProductCodeAndStartDateChecker(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public bool IsDuplicated(Guid productCode, DateTime startDate)
        {
            return formulationRepository.IsDuplicatedGoodsCodeAndStartDate(productCode, startDate);
        }
    }
}
