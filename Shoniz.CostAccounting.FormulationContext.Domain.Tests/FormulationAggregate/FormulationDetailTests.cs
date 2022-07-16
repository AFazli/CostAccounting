using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Exceptions;
using System;

namespace Shoniz.CostAccounting.FormulationContext.Domain.Tests.FormulationAggregate
{
    [TestClass]
    public class FormulationDetailTests
    {
        private string _goodsCode = "001001001";
        private decimal _usedAmount = 100;
        private decimal _mammock = 9;
        private string _registrar = "931524";

        public FormulationDetail CreateFormulationDetail()
        {
            return new FormulationDetail(_goodsCode, _usedAmount, _mammock, _registrar);
        }

        public FormulationDetail CreateFormulationDetail(decimal usedAmount, decimal mammock)
        {
            return new FormulationDetail(_goodsCode, usedAmount, mammock, _registrar);
        }

        #region GoodsCode

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(GoodsCodeCanNotBeNullException))]
        public void SetGoodsCode_CanNotBeNull_ThrowException(string goodsCode)
        {
            _goodsCode = goodsCode;
            CreateFormulationDetail();
        }

        #endregion

        #region UsedAmount

        [TestMethod]
        [DataRow(0)]
        [DataRow(-0.1)]
        [ExpectedException(typeof(UsedAmountLessThanOrEqualZeroException))]
        public void SetUsedAmount_LessThanOrEqualZero_ThrowException(double usedAmount)
        {
            _usedAmount = Convert.ToDecimal(usedAmount);
            CreateFormulationDetail();
        }

        #endregion

        #region Mammock

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-0.1)]
        [ExpectedException(typeof(MammockLessThanZeroException))]
        public void SetMammock_LessThanZero_ThrowException(double mammock)
        {
            _mammock = Convert.ToDecimal(mammock);
            CreateFormulationDetail();
        }


        [TestMethod]
        [DataRow(3, 3)]
        [DataRow(3, 2)]
        [ExpectedException(typeof(MammockLessThanOrEqualUsedAmountException))]
        public void SetMammock_LessThanOrEqualUsedAmount_ThrowException(double mammock, double usedAmount)
        {
            _mammock = Convert.ToDecimal(mammock);
            _usedAmount = Convert.ToDecimal(usedAmount);
            CreateFormulationDetail();
        }

        #endregion

        #region Registrar

        [TestMethod]
        public void SetRegistrar_Retrieve()
        {
            var formulationDetail = CreateFormulationDetail();

            Assert.AreEqual(_registrar, formulationDetail.Registrar.UserId);
        }

        #endregion
    }
}
