using System;
using System.Numerics;

namespace FibonacciCalculator
{
    public class Calculator : IFibonacciCalculator
    {
        public FibonacciResultSet Compute(int len)
        {
            if (len < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var results = new BigInteger[len];

            // zero case
            if (len == 0)
            {
                return new FibonacciResultSet { Results = results };
            }

            // one case
            results[0] = 0;
            if (len == 1)
            {
                return new FibonacciResultSet { Results = results };
            }

            // compute values
            results[1] = 1;
            for (int i = 2; i < len; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }

            FibonacciResultSet resultSet = new FibonacciResultSet { Results = results };

            return resultSet;
        }
    }
}