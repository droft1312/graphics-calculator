using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Program
    {
        static void Main (string[] args) {
            string input = "/(*(x,+(3,*(2,x))),+(x,*(5,x)))";

            BaseNode plus = new SumNode (input, null);

            Console.WriteLine (plus is SumNode);

            Console.ReadKey ();
        }
    }
}
