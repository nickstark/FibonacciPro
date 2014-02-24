using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

            XDocument input = null;

            try
            {
                input = XDocument.Load(filePath);
            }
            catch (XmlException)
            {
                throw new InvalidFibonacciInputException("Unable to read XML document");
            }

            if (input == null)
            {
                throw new InvalidFibonacciInputException("Unable to read XML document");
            }

            XElement fibInput = input.Element("fibinput");

            if (fibInput == null)
            {
                throw new InvalidFibonacciInputException("Unable to find fibinput in XML document");
            }

            return ParseStringArgument(fibInput.Value);
        }
    }
}
