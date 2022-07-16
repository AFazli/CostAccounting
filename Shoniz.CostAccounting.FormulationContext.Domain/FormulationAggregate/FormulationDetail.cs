using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Exceptions;
using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature;
using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature.Exceptions;
using Shoniz.Framework.Domain;

namespace Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate
{
    public class FormulationDetail : EntityBase
    {
        public Guid GoodsCode { get; private set; }
        public decimal UsedAmount { get; private set; }
        public decimal Mammock { get; private set; }
        public Signature Registrar { get; private set; }
        public CalculateFormulation CalculateFormulation { get; private set; }

        public FormulationDetail() { }

        public FormulationDetail(
            string goodsCode,
            decimal usedAmount,
            decimal mammock,
            string registrar)
        {
            SetGoodsCode(goodsCode);
            SetUsedAmount(usedAmount);
            SetMammock(mammock, usedAmount);
            SetRegistrar(registrar);
        }

        private void SetGoodsCode(string goodsCode)
        {
            if (string.IsNullOrWhiteSpace(goodsCode))
            {
                throw new GoodsCodeCanNotBeNullException();
            }

            GoodsCode = Guid.Empty;
        }

        private void SetUsedAmount(decimal usedAmount)
        {
            if (usedAmount <= 0)
            {
                throw new UsedAmountLessThanOrEqualZeroException();
            }

            UsedAmount = usedAmount;
        }

        private void SetMammock(decimal mammock, decimal usedAmount)
        {
            if (mammock < 0)
            {
                throw new MammockLessThanZeroException();
            }

            if (mammock >= usedAmount)
            {
                throw new MammockLessThanOrEqualUsedAmountException();
            }

            Mammock = mammock;
        }

        private void SetRegistrar(string registrar)
        {
            try
            {
                Registrar = new Signature(registrar);
            }
            catch (UserIdCanNotBeNullException)
            {
                throw new InvalidFormulationDetailRegistrarException();
            }
            catch (UserIdInvalidException)
            {
                throw new InvalidFormulationDetailRegistrarException();
            }
        }

        public void SetCalculateFormulation(decimal scale, decimal extraDropedAmount, decimal sumMammock)
        {
            var dropedAmount = Mammock * extraDropedAmount / sumMammock;
            var dropedPercent = Mammock * extraDropedAmount / sumMammock;
            var usedPercent = (UsedAmount * 100) / scale;

            var calculateFormulation = new CalculateFormulation(usedPercent, dropedAmount, dropedPercent);
            CalculateFormulation = calculateFormulation;
        }
    }
}
