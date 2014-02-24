using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public abstract class BaseFibonacciInput
    {

        public static int ParseStringArgument(string input)
        {
            int numVal = -1;
            try
            {
                numVal = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                throw new InvalidFibonacciInputException("Input is not a number.");
            }
            catch (OverflowException)
            {
                throw new InvalidFibonacciInputException("The number is too large.");
            }

            return numVal;
        }

        protected static void CheckFileExistance(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new InvalidFibonacciInputException("The input file does not exist");
            }
        }
    }
}
