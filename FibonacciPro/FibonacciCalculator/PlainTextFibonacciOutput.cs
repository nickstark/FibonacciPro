using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class PlainTextFibonacciOutput : IFibonacciOutput
    {
        private string _fileName;

        public PlainTextFibonacciOutput(string fileName)
        {
            _fileName = fileName;
        }

        public void WriteResult(FibonacciResultSet results)
        {
            using (Stream stream = File.Create(_fileName))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                for (int i = 0; i < results.GetAllResults().Length; i++)
                {
                    writer.Write(string.Format("{0} ", results.GetAllResults()[i]));
                }
            }
        }
    }
}
