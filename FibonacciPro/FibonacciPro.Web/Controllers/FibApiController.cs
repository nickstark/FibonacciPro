using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FibonacciCalculator;
using System.Numerics;
using System.Net.Http.Formatting;
using FibonacciPro.Web.Formatters;

namespace FibonacciPro.Web.Controllers
{
    public class FibApiController : ApiController
    {
        FibonacciResultSet GetComputedResults(int? id)
        {
            int computeVal = id.GetValueOrDefault();

            if (computeVal < 0)
            {
                computeVal = -1 * computeVal;
            }

            Calculator calc = new Calculator();
            var results = calc.Compute(computeVal);
            return results;
        }
        // GET api/<num>
        public HttpResponseMessage Get(int? id, string extension = "json")
        {
            var results = GetComputedResults(id);
            MediaTypeFormatter fmtr = null;

            switch (extension)
            {
                case "plain-text":
                    //TODO: write formatter
                    fmtr = new PlainTextMediaFormatter();
                    break;
                case "xml":
                    fmtr = new XmlMediaTypeFormatter() { UseXmlSerializer = true };
                    break;
                case "json":
                    fmtr = new JsonMediaTypeFormatter();
                    JsonMediaTypeFormatter f = fmtr as JsonMediaTypeFormatter;
                    break;
            }

            if (fmtr == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<FibonacciResultSet>(
                    results,
                    fmtr
                )
            };
        }
    }
}