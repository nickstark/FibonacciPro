using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciCalculator;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class PlainTextFibonacciOutputTest
    {
        private string _testFilePath = Environment.CurrentDirectory + "\\currentTest.txt";

        private bool isFileEqual(string outputPath)
        {
            string outputText = System.IO.File.ReadAllText(outputPath);
            string testText = System.IO.File.ReadAllText(_testFilePath);

            return outputText == testText;
        }

        private PlainTextFibonacciOutput _fibWriter;
        private FibonacciCalculator.FibonacciCalculator _calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _fibWriter = new PlainTextFibonacciOutput(_testFilePath);
            _calculator = new FibonacciCalculator.FibonacciCalculator();
        }

        [TestMethod]
        public void SmallOutput()
        {
            // output
            FibonacciResultSet results = _calculator.Compute(5);
            _fibWriter.WriteResult(results);
            string testFile = Environment.CurrentDirectory + "\\TestFiles\\small-output.txt";

            bool isEqual = isFileEqual(testFile);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void EmptyOutput()
        {
            // output
            FibonacciResultSet results = _calculator.Compute(0);
            _fibWriter.WriteResult(results);
            string testFile = Environment.CurrentDirectory + "\\TestFiles\\empty-output.txt";

            bool isEqual = isFileEqual(testFile);

            Assert.IsTrue(isEqual);
        }
    }
}
