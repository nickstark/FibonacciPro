using System;
using System.Numerics;
using CommandLine;

namespace FibonacciPro
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new CliOptions();
            if (Parser.Default.ParseArguments(args, options))
            {
                int numVal = -1;
                if (args.Length == 0 || (options.InputFile == null && options.InputNumber == null))
                {
                    Console.Write(options.GetUsage());
                    Environment.Exit(0);
                }

                if (options.InputFile == null)
                {
                    // attempt to parse InputNumber
                    numVal = ParseStringArgument(options.InputNumber);
                }
                else
                {
                    // get numVal from input
                    numVal = 5;
                }

                var calc = new FibonacciCalculator.FibonacciCalculator();
                BigInteger[] results = calc.Compute(numVal);

                for (int i = 0; i < numVal; i++)
                {
                    Console.WriteLine(results[i]);
                }
            }
        }

        private static int ParseStringArgument(string input)
        {
            int numVal = -1;
            try
            {
                numVal = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input string is not a numbers.");
                Environment.Exit(0);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large.");
                Environment.Exit(0);
            }

            return numVal;
        }
    }
}