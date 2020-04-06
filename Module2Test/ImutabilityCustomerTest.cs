using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module2.Examples;

namespace Module2.Test
{
    [TestClass]
    public class ImutabilityCustomerTest
    {
        private ImutabilityCustomer _imutabilityCustomer = new ImutabilityCustomer();

        [TestMethod]
        public void ReturnSuccessWhenGenerateCustomer()
        {
            _imutabilityCustomer.ProcessCreateCustomer("customer Name", "Customer Address");
        }
    }
}
