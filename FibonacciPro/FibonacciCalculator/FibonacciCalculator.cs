using System.Numerics;

namespace FibonacciCalculator
{
    public class FibonacciCalculator
    {
        public BigInteger[] Compute(int len)
        {
            var results = new BigInteger[len];

            // zero case
            if (len == 0)
            {
                return results;
            }

            // one case
            results[0] = 0;
            if (len == 1)
            {
                return results;
            }

            // compute values
            results[1] = 1;
            for (int i = 2; i < len; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }

            return results;
        }
    }
}