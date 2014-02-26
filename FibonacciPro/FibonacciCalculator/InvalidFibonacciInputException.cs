using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class InvalidFibonacciInputException : Exception
    {
        public InvalidFibonacciInputException()
        {
        }

        public InvalidFibonacciInputException(string message) : base(message)
        {
        }

        public InvalidFibonacciInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
