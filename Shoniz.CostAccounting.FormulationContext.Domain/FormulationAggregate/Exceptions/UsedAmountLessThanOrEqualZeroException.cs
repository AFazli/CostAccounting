using Shoniz.CostAccounting.FormulationContext.Resources.FormulationAggregate;
using Shoniz.Framework.Domain;

namespace Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Exceptions
{
    public class UsedAmountLessThanOrEqualZeroException : DomainException
    {
        public override string Message => FormulationException.UsedAmountLessThanOrEqualZeroException;
    }
}
