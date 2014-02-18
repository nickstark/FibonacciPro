using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciCalculator;

namespace FibonacciCalculatorTest
{
    [TestClass]
    public class PlainTextFibonacciInputTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void NonexistantInput()
        {
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput("TestFiles/doesntExist.txt");
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void InvalidInput()
        {
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput("TestFiles/invalid.txt");
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void XMLInput()
        {
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput("TestFiles/xml.txt");
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFibonacciInputException))]
        public void TooLargeInput()
        {
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput("TestFiles/huge.txt");
            int testNumber = testInput.GetValue();
        }

        [TestMethod]
        public void ValidInput()
        {
            int expected = 1;
            
            PlainTextFibonacciInput testInput = new PlainTextFibonacciInput("TestFiles/valid.txt");
            int actual = testInput.GetValue();

            Assert.AreEqual(expected, actual);
        }
    }
}
