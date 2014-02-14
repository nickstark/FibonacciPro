using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class FibonacciCalculatorTest
    {
        private FibonacciCalculator.FibonacciCalculator _calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _calculator = new FibonacciCalculator.FibonacciCalculator();
        }

        [TestMethod]
        public void CalculateTest_Zero()
        {
            BigInteger[] expected = {};

            BigInteger[] actual = _calculator.Compute(0).GetAllResults();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTest_One()
        {
            BigInteger[] expected = { 0 };

            BigInteger[] actual = _calculator.Compute(1).GetAllResults();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTest_Two()
        {
            BigInteger[] expected = { 0, 1 };

            BigInteger[] actual = _calculator.Compute(2).GetAllResults();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTest_Three()
        {
            BigInteger[] expected = { 0, 1, 1 };

            BigInteger[] actual = _calculator.Compute(3).GetAllResults();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTest_Fifty()
        {
            int expected = 50;

            int actual = _calculator.Compute(50).GetAllResults().Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTest_Large()
        {
            int numberToCalculate = 60;
            string expected = "1548008755920";

            string actual = _calculator.Compute(numberToCalculate).GetResult(numberToCalculate - 1).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTest_Max()
        {
            int expected = Int32.MaxValue;

            int actual = _calculator.Compute(Int32.MaxValue).GetAllResults().Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A userId of null was inappropriately allowed.")]
        public void CalculateTest_Negative()
        {
            _calculator.Compute(-1);
        }
    }
}
