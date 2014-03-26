using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class FibonacciCalculatorTest
    {
        private FibonacciCalculator.Calculator _calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _calculator = new FibonacciCalculator.Calculator();
        }

        [TestMethod]
        public void input_value_zero_returns_zero_results()
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
            string expected = "956722026041";

            string actual = _calculator.Compute(numberToCalculate).GetResult(numberToCalculate - 1).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore] // Ignoring because iterator approach would solve
        public void CalculateTest_Max()
        {
            int expected = Int32.MaxValue;

            int actual = _calculator.Compute(Int32.MaxValue).GetAllResults().Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateTest_Negative()
        {
            //arrange

            //act
            _calculator.Compute(-1);
            
            //assert that exception is thrown
            
        }
    }
}
