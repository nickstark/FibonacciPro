using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciCalculator;
using System.IO;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class PlainTextFibonacciInputTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void NonexistantInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\doesntExist.txt";
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void InvalidInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\invalid.txt";
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void XMLInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\valid.xml";
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void TooLargeInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\huge.txt";
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        public void ValidInput()
        {
            int expected = 1;
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\valid.txt";
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput(filePath);

            int actual = testInput.GetValue();

            Assert.AreEqual(expected, actual);
        }
    }
}
