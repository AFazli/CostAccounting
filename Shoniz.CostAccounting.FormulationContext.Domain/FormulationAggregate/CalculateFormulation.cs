using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Exceptions;

namespace Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate
{
    public class CalculateFormulation
    {
        public decimal UsedPercent { get; private set; }
        public decimal DroppedAmount { get; private set; }
        public decimal DroppedPercent { get; private set; }

        public CalculateFormulation() { }

        public CalculateFormulation(
            decimal usedPercent,
            decimal droppedAmount,
            decimal droppedPercent)
        {
            SetUsedPercent(usedPercent);
            SetDroppedAmount(droppedAmount);
            SetDroppedPercent(droppedPercent);
        }

        private void SetUsedPercent(decimal usedPercent)
        {
            if (usedPercent < 0)
            {
                throw new UsedPercentLessThanZeroException();
            }

            if (usedPercent > 100)
            {
                throw new UsedPercentMoreThan100Exception();
            }

            UsedPercent = usedPercent;
        }

        private void SetDroppedAmount(decimal droppedAmount)
        {
            if (droppedAmount < 0)
            {
                throw new DroppedAmountLessThanZeroException();
            }

            DroppedAmount = droppedAmount;
        }

        private void SetDroppedPercent(decimal droppedPercent)
        {
            if (droppedPercent < 0)
            {
                throw new DroppedPercentLessThanZeroException();
            }

            if (droppedPercent > 100)
            {
                throw new DroppedPercentMoreThan100Exception();
            }

            DroppedPercent = droppedPercent;
        }

        public bool IsEmpty()
        {
            return UsedPercent == decimal.Zero;
        }

        internal void MakeEmpty()
        {
            UsedPercent = default;
            DroppedAmount = default;
            DroppedPercent = default;
        }
    }
}
