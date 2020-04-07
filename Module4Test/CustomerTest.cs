using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module4;

namespace Module4Test
{
    [TestClass]
    public class CustomerTest
    {
        private const int AgeTwenty = 20;

        [TestMethod]
        public void ReturnFailWhenCustomeNameIsNull()
        {
            var customer = new Customer(null, AgeTwenty);

            Assert.IsFalse(customer.IsValid);
            Assert.AreNotEqual(null, customer.ErrorMessage);
        }

        [TestMethod]
        public void ReturnFailWhenCustomeNameIsEmptySpace()
        {
            var customer = new Customer("   ", AgeTwenty);

            Assert.IsFalse(customer.IsValid);
            Assert.AreNotEqual(null, customer.ErrorMessage);
        }



        [TestMethod]
        public void ReturnFailWhenCustomeNameIsEmpty()
        {
            var customer = new Customer(string.Empty, AgeTwenty);

            Assert.IsFalse(customer.IsValid);
            Assert.AreNotEqual(null, customer.ErrorMessage);
        }

        [TestMethod]
        public void ReturnFailWhenCustomeAgeIsUnderEighteen()
        {
            var customer = new Customer(string.Empty, 10);

            Assert.IsFalse(customer.IsValid);
            Assert.AreNotEqual(null, customer.ErrorMessage);
        }

        [TestMethod]
        public void ReturnSuccess()
        {
            var customer = new Customer("Customer Name", AgeTwenty);

            Assert.IsTrue(customer.IsValid);
            Assert.AreEqual(null, customer.ErrorMessage);
        }
    }
}
