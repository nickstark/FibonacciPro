using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class PlainTextFibonacciInput : BaseFibonacciInput, IFibonacciInput
    {
        private string _filePath;

        public PlainTextFibonacciInput(string filePath)
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

            string firstLine;
            using (Stream fileStream = File.OpenRead(filePath))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                firstLine = reader.ReadLine();
            }

            return ParseStringArgument(firstLine.Trim());
        }
    }
}
