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
                Console.WriteLine("Input is not a number.");
                Environment.Exit(0);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large.");
                Environment.Exit(0);
            }

            return numVal;
        }

        protected static void CheckFileExistance(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The input file does not exist");
                Environment.Exit(1);
            }
        }
    }
}
