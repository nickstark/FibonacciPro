using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace FibonacciCalculator
{
    [XmlRoot(ElementName = "fiboutput")]
    [DataContract]
    public class FibonacciResultSet : IXmlSerializable
    {
        public BigInteger[] Results { get; set; }

        string[] _strings = null;

        [DataMember(Name = "results")]
        string[] ResultsAsString
        {
            get
            {
                if (_strings == null)
                {
                    _strings = new string[Results.Length];
                    int len = Results.Length;
                    for (int i = 0; i < len; i++)
                    {
                        _strings[i] = Results[i].ToString();
                    }
                }

                return _strings;
            }
        }

        public BigInteger GetResult(int index)
        {
            if (index < 0 || index >= Results.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return Results[index];
        }

        public BigInteger[] GetAllResults()
        {
            return Results;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach (var result in Results)
            {
                writer.WriteElementString("result", result.ToString());
            }
        }
    }
}
