using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using web_app.Helpers;
using Assert = NUnit.Framework.Assert;

namespace web_app.Tests.Controllers
{
    [TestClass]
    public class ExpensesControllerTest
    {
        [TestMethod]
        public void GivenInputIsIntegerThenReturnTrue()
        {
            var result = StringHelper.IsDecimal("10");
            Assert.That(result,Is.True);
        }

        [TestMethod]
        public void GivenInputIsStringThenReturnFalse()
        {
            var result = StringHelper.IsDecimal("abc");
            Assert.That(result, Is.False);
        }
    }
}