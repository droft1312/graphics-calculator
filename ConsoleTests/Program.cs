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
            //string input = "/(*(x,+(3,*(2,x))),+(x,*(5,x)))";
            string input = "s(/(+(x,3),5))";

            Plotter plotter = new Plotter ();
            plotter.ProcessString (input);

            Console.WriteLine(plotter.PrefixToInfix ("5"));

            Console.ReadKey ();
        }
    }
}
