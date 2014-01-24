using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class InteractiveFibonacciInput : BaseFibonacciInput, IFibonacciInput
    {

        public int GetValue()
        {
            return PromptUser();
        }

        private static int PromptUser()
        {
            Console.Write("Please enter the number of items to calculate: ");
            string consoleLine = Console.ReadLine();
            int userInput = ParseStringArgument(consoleLine);

            return userInput;
        }
    }
}
