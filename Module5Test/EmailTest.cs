using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module5.ValueObjects;
using System;

namespace Module5Test
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void ShouldThrowNullErroWhenEmailIsNull()
        {
            Assert.ThrowsException<NullReferenceException>(() => Email.Create(null));
        }

        [TestMethod]
        public void ShouldThrowNullErroWhenEmailIsStringEmpty()
        {
            Assert.ThrowsException<NullReferenceException>(() => Email.Create(string.Empty));
        }

        [TestMethod]
        public void ShouldThrowNullErroWhenEmailIsWhiteSpace()
        {
            Assert.ThrowsException<NullReferenceException>(() => Email.Create(" "));
        }

        [TestMethod]
        public void ShouldSuccessWhenSendValidEmail()
        {
            const string emailTest = "test@mail.com";
            var email = Email.Create(emailTest);

            Assert.AreEqual(emailTest, email.Value);
        }
    }
}
