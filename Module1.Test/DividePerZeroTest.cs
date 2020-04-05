using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module1.Examples;
using System;

namespace Module1.Test
{
    [TestClass]
    public class DividePerZeroTest
    {
        private const int NumberTen = 10;
        private const int NumberZero = 0;
        private const int NumberTwo = 2;

        [TestMethod]
        public void ReturnDividePerZeroWithSuccessWhenNonZeroIntegerNotIsZero()
        {
            var resultDivide = DividePerZero.Divide(NumberTen, new NonZeroInteger(NumberTwo));

            Assert.IsNotNull(resultDivide);
            Assert.AreEqual(5, resultDivide);
        }

        [TestMethod]
        public void ReturnDividePerZeroWithErrorWhenNonZeroIntegerIsZero()
        {
            Assert.ThrowsException<DivideByZeroException>(() => DividePerZero.Divide(NumberTen, new NonZeroInteger(NumberZero)));
        }


        [TestMethod]
        public void ReturnDividePerZeroWithSuccessWhenDividerNotIsZero()
        {
            var resultDivide = DividePerZero.Divide(NumberTen, 2);

            Assert.IsNotNull(resultDivide);
            Assert.AreEqual(5, resultDivide);
        }

        [TestMethod]
        public void ReturnDividePerZeroWithErrorWhenDividerisZero()
        {
            var resultDivide = DividePerZero.Divide(NumberTen, 0);

            Assert.IsNull(resultDivide);
        }

    }
}
