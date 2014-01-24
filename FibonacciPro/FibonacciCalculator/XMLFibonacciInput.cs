using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FibonacciCalculator
{
    public class XMLFibonacciInput : BaseFibonacciInput, IFibonacciInput
    {
        private string _filePath;

        public XMLFibonacciInput(string filePath)
        {
            _filePath = filePath;
        }

        public int GetValue()
        {
            return ParseFile(_filePath);
        }

        private static int ParseFile(string filePath)
        {
            CheckFileExistance(filePath);

            XDocument input = XDocument.Load(filePath);

            if (input == null)
            {
                Console.WriteLine("Unable to read XML document");
                Environment.Exit(1);
            }

            XElement fibInput = input.Element("fibinput");

            if (fibInput == null)
            {
                Console.WriteLine("Unable to find fibinput in XML document");
                Environment.Exit(1);
            }

            return ParseStringArgument(fibInput.Value);
        }
    }
}
