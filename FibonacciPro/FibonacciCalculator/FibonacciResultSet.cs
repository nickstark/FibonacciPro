using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace FibonacciCalculator
{
    public class FibonacciResultSet
    {
        public BigInteger[] Results { private get; set; }

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
    }
}
