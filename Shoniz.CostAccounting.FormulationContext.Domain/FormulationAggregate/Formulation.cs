using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Exceptions;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature;
using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature.Exceptions;
using Shoniz.Framework.Core.Domain;
using Shoniz.Framework.Domain;
using Shoniz.Framework.Globalization;
using System.Linq.Expressions;

namespace Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate
{
    public class Formulation : EntityBase, IAggregateRoot<Formulation>
    {
        public DateTime StartDate { get; private set; }
        public decimal HumidityPercent { get; private set; }
        public Guid ProductCode { get; private set; }
        public ICollection<FormulationDetail> FormulationDetails { get; private set; } = new HashSet<FormulationDetail>();
        public decimal Scale { get; private set; }
        public Signature Regulator { get; private set; }
        public Signature Confirmer { get; private set; }

        public Formulation() { }

        public Formulation(
            IDuplicatedProductCodeAndStartDateChecker duplicatedProductCodeAndStartDateChecker,
            IWarehoueProvider warehoueProvider,
            string startDate,
            decimal humidityPercent,
            Guid productCode,
            decimal scale)
        {
            SetStartDate(startDate);
            SetHumidityPercent(humidityPercent);
            SetProductCode(warehoueProvider, productCode);
            DuplicateChecker(duplicatedProductCodeAndStartDateChecker);
            SetScale(scale);

            Regulator = new Signature();
            Confirmer = new Signature();
        }

        private void SetScale(decimal scale)
        {
            if (scale <= 0)
            {
                throw new ScaleLessThanOrEqualZeroException();
            }

            Scale = scale;
        }

        private void SetStartDate(string startDate)
        {
            if (string.IsNullOrWhiteSpace(startDate))
            {
                throw new StartDateCanNotBeNullException();
            }

            if (!DateTimeValidation.IsValidPersianDate(startDate))
            {
                throw new StartDateInvalidException();
            }

            StartDate = DateConvertion.ConvertToStartOfDate(startDate);
        }

        private void SetHumidityPercent(decimal humidityPercent)
        {
            if (humidityPercent < decimal.Zero)
            {
                throw new HumidityPercentLessThanZeroException();
            }

            if (humidityPercent > 100m)
            {
                throw new HumidityPercentMoreThan100Exception();
            }

            HumidityPercent = humidityPercent;
        }

        private void SetProductCode(IWarehoueProvider warehoueProvider, Guid productCode)
        {
            if (productCode == Guid.Empty)
            {
                throw new ProductCodeCanNotBeNullException();
            }

            if (!warehoueProvider.IsGoodsCodeValid(productCode))
            {
                throw new ProductCodeInvalidException();
            }

            ProductCode = productCode;
        }

        private void DuplicateChecker(IDuplicatedProductCodeAndStartDateChecker duplicatedProductCodeAndStartDateChecker)
        {
            if (duplicatedProductCodeAndStartDateChecker.IsDuplicated(ProductCode, StartDate))
            {
                throw new AddFormulationDuplicatedProductCodeAndStartDateException();
            }
        }

        public void AddFormulationDetail(FormulationDetail formulationDetail)
        {
            if (FormulationDetails.Any(p => p.GoodsCode == formulationDetail.GoodsCode))
            {
                throw new AddFormulationDetailDuplicatedGoodsCodeInOneFormulaException();
            }

            FormulationDetails.Add(formulationDetail);
        }

        private decimal SumUsedAmountFormulationDetail()
        {
            return FormulationDetails.Sum(p => p.UsedAmount);
        }

        private decimal SumMammockUsedAmount()
        {
            var batchAmount = SumUsedAmountFormulationDetail();

            decimal sum = 0;

            foreach (var item in FormulationDetails)
            {
                sum = (item.Mammock * item.UsedAmount) / batchAmount;
            }

            return sum;
        }

        public decimal ExtraDropedAmount()
        {
            var sumMammockUsedAmount = SumMammockUsedAmount();

            return sumMammockUsedAmount - HumidityPercent;
        }

        public void Regulate(string regulator)
        {
            if (!FormulationDetails.Any())
            {
                throw new RegulatorSignWithEmptyItemsException();
            }

            if (!Regulator.IsEmpty())
            {
                throw new RegulatorSignAlreadyRegulatedException();
            }

            var sumUsedAmount = SumUsedAmountFormulationDetail();

            if (sumUsedAmount > Scale)
            {
                throw new RegulatorSignTheSumOfTheUsedAmountShouldNotBeGreaterThanTheScaleException();
            }

            var sumMammock = SumMammockUsedAmount();

            if (sumMammock < HumidityPercent)
            {
                throw new RegulatorSignTheSumOfTheMammockShouldNotBeLessThanTheHumidityPercentException();
            }

            var extraDropedAmount = ExtraDropedAmount();

            foreach (var item in FormulationDetails)
            {
                item.SetCalculateFormulation(Scale, extraDropedAmount, sumMammock);
            }

            try
            {
                Regulator = new Signature(regulator);
            }
            catch (UserIdCanNotBeNullException)
            {
                throw new InvalidFormulationRegulatorException();
            }
            catch (UserIdInvalidException)
            {
                throw new InvalidFormulationRegulatorException();
            }
        }

        public IEnumerable<Expression<Func<Formulation, object>>> GetAggregateExpressions()
        {
            yield return c => c.FormulationDetails;
        }

        public void CheckIfReadyForDelete()
        {
            if (!Regulator.IsEmpty())
            {
                throw new DeleteFormulationSignedException();
            }

            if (FormulationDetails.Any())
            {
                throw new DeleteFormulationWithItemsException();
            }
        }

        public void DeleteDetail(Guid formulationDetailId)
        {
            if (!Regulator.IsEmpty())
            {
                throw new DeleteFormulationDetailSignedException();
            }

            FormulationDetails.Remove(FormulationDetails.FirstOrDefault(f => f.Id == formulationDetailId));
        }

        public void Confirm(string confirmer)
        {
            if (Regulator.IsEmpty())
            {
                throw new ConfirmingNotRegulatorSignedException();
            }

            if (!Confirmer.IsEmpty())
            {
                throw new ConfirmingAlreadyConfirmedException();
            }

            try
            {
                Confirmer = new Signature(confirmer);
            }
            catch (UserIdCanNotBeNullException)
            {
                throw new InvalidFormulationConfirmException();
            }
            catch (UserIdInvalidException)
            {
                throw new InvalidFormulationConfirmException();
            }
        }

        public void UnConfirm()
        {
            if (Confirmer.IsEmpty())
            {
                throw new UnConfirmWithNoConfirmationSignException();
            }

            Confirmer.MakeEmpty();
        }

        public void UnRegulate()
        {
            if (Regulator.IsEmpty())
            {
                throw new UnRegulatorWithNoRegulationSignException();
            }

            if (!Confirmer.IsEmpty())
            {
                throw new UnRegulatorConfirmatorSignException();
            }

            foreach (var item in FormulationDetails)
            {
                item.CalculateFormulation.MakeEmpty();
            }

            Regulator.MakeEmpty();
        }
    }
}