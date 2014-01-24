using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FibonacciCalculator
{
    public class XMLFibonacciOutput : IFibonacciOutput
    {
        private string _fileName;

        public XMLFibonacciOutput(string fileName)
        {
            _fileName = fileName;
        }

        public void WriteResult(FibonacciResultSet results)
        {
            XDocument xmlDoc = ConstructXMLDoc(results);
            xmlDoc.Save(_fileName);
        }

        private static XDocument ConstructXMLDoc(FibonacciResultSet results)
        {
            IEnumerable<BigInteger> enumList = results.GetAllResults();
            XDocument doc = new XDocument(
                new XElement("fiboutput",
                    enumList.Select(n => new XElement("result", n.ToString()))
                )
            );

            return doc;
        }
    }
}
