using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class DirectFibonacciOutput : IFibonacciOutput
    {
        public void WriteResult(FibonacciResultSet resultSet)
        {
            BigInteger[] results = resultSet.GetAllResults();

            for (int i = 0; i < results.Length; i++)
            {
                Console.Write("{0} ", results[i]);
            }
            Console.WriteLine();
        }
    }
}
