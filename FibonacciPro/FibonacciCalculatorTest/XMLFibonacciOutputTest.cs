using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciCalculator;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class XMLFibonacciOutputTest
    {
        private string _testFilePath = Environment.CurrentDirectory + "\\currentTest.xml";

        private bool isFileEqual(string outputPath)
        {
            string outputText = System.IO.File.ReadAllText(outputPath);
            string testText = System.IO.File.ReadAllText(_testFilePath);

            return outputText == testText;
        }

        private XMLFibonacciOutput _fibWriter;
        private FibonacciCalculator.FibonacciCalculator _calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _fibWriter = new XMLFibonacciOutput(_testFilePath);
            _calculator = new FibonacciCalculator.FibonacciCalculator();
        }

        [TestMethod]
        public void SmallOutput()
        {
            // output
            FibonacciResultSet results = _calculator.Compute(4);
            _fibWriter.WriteResult(results);

            string testFile = Environment.CurrentDirectory + "\\TestFiles\\small-output.xml";

            bool isEqual = isFileEqual(testFile);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void EmptyOutput()
        {
            // output
            FibonacciResultSet results = _calculator.Compute(0);
            _fibWriter.WriteResult(results);
            string testFile = Environment.CurrentDirectory + "\\TestFiles\\empty-output.xml";

            bool isEqual = isFileEqual(testFile);

            Assert.IsTrue(isEqual);
        }
    }
}
