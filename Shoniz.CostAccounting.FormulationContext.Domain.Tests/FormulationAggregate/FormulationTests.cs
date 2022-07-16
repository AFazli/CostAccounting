using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Exceptions;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Globalization;
using System;
using System.Linq;

namespace Shoniz.CostAccounting.FormulationContext.Domain.Tests.FormulationAggregate
{
    [TestClass]
    public class FormulationTests : IDuplicatedProductCodeAndStartDateChecker, IWarehoueProvider
    {
        private string _startDate = DateConvertion.GetPersianDate(DateTime.Now);
        private Guid _productCode = Guid.NewGuid();
        private decimal _humidityPercent = 8;
        private bool isDuplicated = false;
        private bool isGoodsCodeValid = true;
        private decimal _scale = 100;
        private string _userId = "931524";

        private Formulation CreateFormulation()
        {
            return new Formulation(this, this, _startDate, _humidityPercent, _productCode, _scale);
        }

        private FormulationDetail CreateFormulationDetail()
        {
            var formulationDetailTest = new FormulationDetailTests();
            return formulationDetailTest.CreateFormulationDetail();
        }

        private FormulationDetail CreateFormulationDetail(decimal usedAmount, decimal mammock)
        {
            var formulationDetailTest = new FormulationDetailTests();
            return formulationDetailTest.CreateFormulationDetail(usedAmount, mammock);
        }

        #region StartDate

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(StartDateCanNotBeNullException))]
        public void SetStartDate_CanNotBeNull_ThrowException(string startDate)
        {
            _startDate = startDate;
            CreateFormulation();
        }

        [TestMethod]
        [DataRow("abc")]
        [DataRow("123")]
        [DataRow("1399/13/01")]
        [ExpectedException(typeof(StartDateInvalidException))]
        public void SetStartDate_Invalid_ThrowException(string startDate)
        {
            _startDate = startDate;
            CreateFormulation();
        }

        #endregion

        #region HumidityPercent

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-0.1)]
        [ExpectedException(typeof(HumidityPercentLessThanZeroException))]
        public void SetHumidityPercent_LessThanZero_ThrowException(double humidityPercent)
        {
            _humidityPercent = Convert.ToDecimal(humidityPercent);
            CreateFormulation();
        }

        [TestMethod]
        [DataRow(1000)]
        [DataRow(101)]
        [ExpectedException(typeof(HumidityPercentMoreThan100Exception))]
        public void SetHumidityPercent_MoreThan100_ThrowException(double humidityPercent)
        {
            _humidityPercent = Convert.ToDecimal(humidityPercent); ;
            CreateFormulation();
        }

        #endregion

        #region ProductCode

        [TestMethod]
        [DataRow(null)]
        [ExpectedException(typeof(ProductCodeCanNotBeNullException))]
        public void SetProductCode_CanNotBeNull_ThrowException(Guid productCode)
        {
            _productCode = productCode;
            CreateFormulation();
        }

        [TestMethod]
        [ExpectedException(typeof(ProductCodeInvalidException))]
        public void SetProductCode_Invalid_ThrowException()
        {
            isGoodsCodeValid = false;
            CreateFormulation();
        }

        [TestMethod]
        [ExpectedException(typeof(AddFormulationDuplicatedProductCodeAndStartDateException))]
        public void AddFormulation_DuplicatedProductCodeAndStartDate_ThrowException()
        {
            isDuplicated = true;
            CreateFormulation();
        }

        #endregion

        #region Scale

        [TestMethod]
        [DataRow(0)]
        [DataRow(-0.1)]
        [ExpectedException(typeof(ScaleLessThanOrEqualZeroException))]
        public void SetScale_LessThanOrEqualZero_ThrowException(double scale)
        {
            _scale = Convert.ToDecimal(scale);
            CreateFormulation();
        }

        #endregion

        #region AddItem

        [TestMethod]
        [ExpectedException(typeof(AddFormulationDetailDuplicatedGoodsCodeInOneFormulaException))]
        public void AddFormulation_DuplicatedGoodsCodeInOneFormula_ThrowException()
        {
            var formulation = CreateFormulation();

            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.AddFormulationDetail(formulationDetail);

        }

        #endregion

        #region Regulator

        [TestMethod]
        [ExpectedException(typeof(RegulatorSignWithEmptyItemsException))]
        public void SetRegulator_WithEmptyItems_ThrowException()
        {
            var formulation = CreateFormulation();

            formulation.Regulate(_userId);
        }

        [TestMethod]
        [ExpectedException(typeof(RegulatorSignAlreadyRegulatedException))]
        public void SetRegulator_AlreadyRegulated_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);
            formulation.Regulate(_userId);
        }

        [TestMethod]
        [DataRow(1, 2, 1)]
        [ExpectedException(typeof(RegulatorSignTheSumOfTheUsedAmountShouldNotBeGreaterThanTheScaleException))]
        public void SetRegulator_TheSumOfTheUsedAmountShouldNotBeGreaterThanTheScale_ThrowException(double scale, double usedAmount, double mammock)
        {
            _scale = Convert.ToDecimal(scale);
            var formulation = CreateFormulation();

            var formulationDetail = CreateFormulationDetail(Convert.ToDecimal(usedAmount), Convert.ToDecimal(mammock));

            formulation.AddFormulationDetail(formulationDetail);

            formulation.Regulate(_userId);
        }

        [TestMethod]
        [DataRow(2, 3, 1)]
        [ExpectedException(typeof(RegulatorSignTheSumOfTheMammockShouldNotBeLessThanTheHumidityPercentException))]
        public void SetRegulator_TheSumOfTheMammockShouldNotBeLessThanTheHumidityPercent_ThrowException(double humidityPercent, double usedAmount, double mammock)
        {
            _humidityPercent = Convert.ToDecimal(humidityPercent);
            var formulation = CreateFormulation();

            var formulationDetail = CreateFormulationDetail(Convert.ToDecimal(usedAmount), Convert.ToDecimal(mammock));

            formulation.AddFormulationDetail(formulationDetail);

            formulation.Regulate(_userId);
        }

        [TestMethod]
        public void Regulator_Valid_Signed()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);

            Assert.IsTrue(formulation.Regulator.UserId == _userId);
            Assert.IsNotNull(formulation.Regulator);
        }

        #endregion

        #region UnRegulator

        [TestMethod]
        [ExpectedException(typeof(UnRegulatorWithNoRegulationSignException))]
        public void UnRegulator_WithNoRegulationSign_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);

            formulation.UnRegulate();
        }

        [TestMethod]
        [ExpectedException(typeof(UnRegulatorConfirmatorSignException))]
        public void UnRegulator_ConfirmatorSign_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);
            formulation.Confirm(_userId);
            formulation.UnRegulate();
        }

        [TestMethod]
        public void UnRegulatorEmptyCalculateFormulation_Retrieve()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);
            formulation.UnRegulate();

            Assert.IsTrue(formulationDetail.CalculateFormulation.IsEmpty());
        }

        #endregion

        #region Delete

        [TestMethod]
        [ExpectedException(typeof(DeleteFormulationWithItemsException))]
        public void DeleteFormulation_WithItems_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);

            formulation.CheckIfReadyForDelete();
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteFormulationSignedException))]
        public void DeleteFormulation_Signed_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);
            formulation.CheckIfReadyForDelete();
        }

        #endregion

        #region DeleteDetail

        [TestMethod]
        [ExpectedException(typeof(DeleteFormulationDetailSignedException))]
        public void DeleteFormulationDetail_Signed_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);
            formulation.DeleteDetail(formulationDetail.Id);
        }

        [TestMethod]
        public void DeleteFormulationDetail_Valid_Removed()
        {
            var formulation = CreateFormulation();

            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.DeleteDetail(formulationDetail.Id);

            Assert.IsFalse(formulation.FormulationDetails.Any(f => f.Id == formulationDetail.Id));
        }

        #endregion

        #region Confirm

        [TestMethod]
        [ExpectedException(typeof(ConfirmingNotRegulatorSignedException))]
        public void Confirm_NotRegulatorSigned_ThrowException()
        {
            var formulation = CreateFormulation();

            formulation.Confirm(_userId);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfirmingAlreadyConfirmedException))]
        public void Confirm_AlreadyConfirmed_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);
            formulation.Confirm(_userId);
            formulation.Confirm(_userId);
        }

        #endregion

        #region UnConfirm

        [TestMethod]
        [ExpectedException(typeof(UnConfirmWithNoConfirmationSignException))]
        public void UnConfirm_WithNoConfirmationSign_ThrowException()
        {
            var formulation = CreateFormulation();
            var formulationDetail = CreateFormulationDetail();

            formulation.AddFormulationDetail(formulationDetail);
            formulation.Regulate(_userId);

            formulation.UnConfirm();
        }

        #endregion

        public bool IsDuplicated(Guid productCode, DateTime startDate)
        {
            return isDuplicated;
        }

        public bool IsGoodsCodeValid(Guid id)
        {
            return isGoodsCodeValid;
        }
    }
}
