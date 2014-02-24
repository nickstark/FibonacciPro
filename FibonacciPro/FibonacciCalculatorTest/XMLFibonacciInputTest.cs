using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciCalculator;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class XMLFibonacciInputTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void NonexistantInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\doesntExist.xml";
            XMLFibonacciInput testInput = new XMLFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void InvalidInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\invalid.xml";
            XMLFibonacciInput testInput = new XMLFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void PlainTextInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\valid.txt";
            XMLFibonacciInput testInput = new XMLFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void TooLargeInput()
        {
            string filePath = Environment.CurrentDirectory + "\\TestFiles\\huge.xml";
            XMLFibonacciInput testInput = new XMLFibonacciInput(filePath);
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        public void ValidInput()
        {
            int expected = 23;

            string filePath = Environment.CurrentDirectory + "\\TestFiles\\valid.xml";
            XMLFibonacciInput testInput = new XMLFibonacciInput(filePath);
            int actual = testInput.GetValue();

            Assert.AreEqual(expected, actual);
        }
    }
}
