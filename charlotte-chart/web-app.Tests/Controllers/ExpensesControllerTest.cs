using NUnit.Framework;
using web_app.Helpers;

namespace web_app.Tests.Controllers
{
    public class ExpensesControllerTest
    {
        [Test]
        public void GivenInputIsIntegerThenReturnTrue()
        {
            var result = StringHelper.IsDecimal("10");
            Assert.That(result,Is.True);
        }

        [Test]
        public void GivenInputIsStringThenReturnFalse()
        {
            var result = StringHelper.IsDecimal("abc");
            Assert.That(result, Is.False);
        }
    }
}