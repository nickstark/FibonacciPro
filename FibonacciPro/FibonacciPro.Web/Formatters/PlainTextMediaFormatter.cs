using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Numerics;
using FibonacciCalculator;

namespace FibonacciPro.Web.Formatters
{
    public class PlainTextMediaFormatter : BufferedMediaTypeFormatter
    {
        public PlainTextMediaFormatter ()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
	    }

        public override bool CanWriteType(System.Type type)
        {
            if (type == typeof(FibonacciResultSet))
            {
                return true;
            }
            else
            {
                Type enumerableType = typeof(IEnumerable<FibonacciResultSet>);
                return enumerableType.IsAssignableFrom(type);
            }
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            FibonacciResultSet set = value as FibonacciResultSet;
            using (var writer = new StreamWriter(writeStream))
            {
                //var results = value as IEnumerable<BigInteger>;
                BigInteger[] results = set.GetAllResults();
                foreach (var result in results)
                {
                    writer.Write("{0} ", result);
                }
            }
        }
    }
}