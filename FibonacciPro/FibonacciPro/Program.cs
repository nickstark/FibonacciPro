using System;
using System.Numerics;
using CommandLine;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FibonacciCalculator;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace FibonacciPro
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new CliOptions();

            // parser fail case
            if (!Parser.Default.ParseArguments(args, options))
            {
                Console.Write(options.GetUsage());
                Environment.Exit(1);
            }

            // no input case
            if (args.Length == 0 || (options.InputFile == null && options.InputNumber == null && options.InteractiveMode == false))
            {
                Console.Write(options.GetUsage());
                Environment.Exit(1);
            }

            int numVal = GetInputValue(options);

            // negative number case
            if (numVal < 0)
            {
                Console.WriteLine("Number must be positive.");
                Environment.Exit(1);
            }

            FibonacciCalculator.FibonacciCalculator calc = null;

            try
            {
                calc = new FibonacciCalculator.FibonacciCalculator();
            }
            catch (InvalidFibonacciInputException)
            {
                Environment.Exit(1);
            }
            FibonacciResultSet results = calc.Compute(numVal);

            HandleOutput(options, results);
        }

        private static int GetInputValue(CliOptions options)
        {
            IFibonacciInput inputMethod;

            if (options.InteractiveMode)
            {
                inputMethod = new InteractiveFibonacciInput();
            }
            else if (options.InputFile == null)
            {
                // attempt to parse InputNumber
                return BaseFibonacciInput.ParseStringArgument(options.InputNumber);
            }
            else if (Path.GetExtension(options.InputFile) == ".xml")
            {
                inputMethod = new XMLFibonacciInput(options.InputFile);
            }
            else
            {
                inputMethod = new PlainTextFibonacciInput(options.InputFile);
            }

            return inputMethod.GetValue();
        }

        private static void HandleOutput(CliOptions options, FibonacciResultSet resultSet)
        {
            IFibonacciOutput outputMethod;

            if (options.OutputFile == null)
            {
                outputMethod = new DirectFibonacciOutput();
            }
            else if (Path.GetExtension(options.OutputFile) == ".xml")
            {
                outputMethod = new XMLFibonacciOutput(options.OutputFile);
            }
            else
            {
                outputMethod = new PlainTextFibonacciOutput(options.OutputFile);
            }

            outputMethod.WriteResult(resultSet);
        }

    }
}