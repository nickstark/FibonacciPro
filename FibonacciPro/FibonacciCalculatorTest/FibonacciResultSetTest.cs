using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using FibonacciCalculator;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class FibonacciResultSetTest
    {
        [TestMethod]
        public void TestGetAllResults()
        {
            BigInteger[] data = { 0, 1, 2, 3 };
            FibonacciResultSet testSet = new FibonacciResultSet { Results = data };

            BigInteger[] allResults = testSet.GetAllResults();

            CollectionAssert.AreEqual(data, allResults);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestGetResult_Empty()
        {
            BigInteger[] data = {};
            FibonacciResultSet testSet = new FibonacciResultSet { Results = data };

            BigInteger result = testSet.GetResult(5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestGetResult_Negative()
        {
            BigInteger[] data = { 0, 1, 2, 3 };
            FibonacciResultSet testSet = new FibonacciResultSet { Results = data };

            BigInteger result = testSet.GetResult(-1);
        }

        [TestMethod]
        public void TestGetResult_Valid()
        {
            BigInteger[] data = { 0, 1, 2, 3 };
            FibonacciResultSet testSet = new FibonacciResultSet { Results = data };

            BigInteger expected = 1;
            BigInteger actual = testSet.GetResult(1);

            Assert.AreEqual(expected, actual);
        }
    }
}
