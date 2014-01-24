using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public interface IFibonacciOutput
    {
        void WriteResult(FibonacciResultSet resultSet);
    }
}
