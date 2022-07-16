using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Exceptions;
using System;

namespace Shoniz.CostAccounting.FormulationContext.Domain.Tests.FormulationAggregate
{
    [TestClass]
    public class CalculateFormulationTests
    {
        private decimal _usedPercent = 10;
        private decimal _droppedAmount = 100;
        private decimal _droppedPercent = 9;

        private CalculateFormulation CreateCalculateFormulation()
        {
            return new CalculateFormulation(_usedPercent,_droppedAmount, _droppedPercent);
        }

        [TestMethod]
        [DataRow(-1)]
        [ExpectedException(typeof(UsedPercentLessThanZeroException))]
        public void SetUsedPercent_LessThanZero_ThrowException(double usedPercent)
        {
            _usedPercent = Convert.ToDecimal(usedPercent);
            CreateCalculateFormulation();
        }


        [TestMethod]
        [DataRow(1000)]
        [DataRow(101)]
        [ExpectedException(typeof(UsedPercentMoreThan100Exception))]
        public void SetUsedPercent_MoreThan100_ThrowException(double usedPercent)
        {
            _usedPercent = Convert.ToDecimal(usedPercent);
            CreateCalculateFormulation();
        }
        
        [TestMethod]
        [DataRow(-1)]
        [DataRow(-0.1)]
        [ExpectedException(typeof(DroppedAmountLessThanZeroException))]
        public void SetDroppedAmount_LessThanZero_ThrowException(double droppedAmount)
        {
            _droppedAmount = Convert.ToDecimal(droppedAmount);
            CreateCalculateFormulation();
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-0.1)]
        [ExpectedException(typeof(DroppedPercentLessThanZeroException))]
        public void SetDroppedPercent_LessThanZero_ThrowException(double droppedPercent)
        {
            _droppedPercent = Convert.ToDecimal(droppedPercent);
            CreateCalculateFormulation();
        }

        [TestMethod]
        [DataRow(1000)]
        [DataRow(101)]
        [ExpectedException(typeof(DroppedPercentMoreThan100Exception))]
        public void SetDroppedPercent_MoreThan100_ThrowException(double droppedPercent)
        {
            _droppedPercent = Convert.ToDecimal(droppedPercent);
            CreateCalculateFormulation();
        }
    }
}
