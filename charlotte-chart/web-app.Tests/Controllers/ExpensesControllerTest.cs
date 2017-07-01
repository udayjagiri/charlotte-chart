using Microsoft.VisualStudio.TestTools.UnitTesting;
using web_app.Helpers;

namespace web_app.Tests.Controllers
{
    [TestClass]
    public class ExpensesControllerTest
    {
        [TestMethod]
        public void GivenInputIsIntegerThenReturnTrue()
        {
            var result = StringHelper.IsDecimal("10");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenInputIsStringThenReturnFalse()
        {
            var result = StringHelper.IsDecimal("abc");
            Assert.IsFalse(result);
        }
    }
}