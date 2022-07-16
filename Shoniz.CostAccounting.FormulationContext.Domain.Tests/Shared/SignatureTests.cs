using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature;
using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature.Exceptions;

namespace Shoniz.CostAccounting.FormulationContext.Domain.Tests.Shared
{
    [TestClass]
    public class SignatureTests
    {
        private Signature CreateSignature(string userId)
        {
            return new Signature(userId);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(UserIdCanNotBeNullException))]
        public void SetUserId_CanNotBeNull_ThrowException(string userId)
        {
            CreateSignature(userId);
        }

        [TestMethod]
        [DataRow("abc")]
        [DataRow("12a")]
        [ExpectedException(typeof(UserIdInvalidException))]
        public void SetUserId_Invalid_ThrowException(string userId)
        {
            CreateSignature(userId);
        }


        [TestMethod]
        [DataRow("3254")]
        [ExpectedException(typeof(UserIdInvalidException))]
        public void SetUserId_TheLengthShouldNotBeLessThan5Digits_ThrowException(string userId)
        {
            CreateSignature(userId);
        }

        [TestMethod]
        [DataRow("32549860")]
        [ExpectedException(typeof(UserIdInvalidException))]
        public void SetUserId_TheLengthShouldNotBeMoreThan7Digits_ThrowException(string userId)
        {
            CreateSignature(userId);
        }
    }
}
