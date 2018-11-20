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
            
            Plotter plotter = new Plotter ();
            plotter.ProcessString (input);

            var tree = plotter.GetTree ();

            plotter.ProcessTree (1);

            Console.ReadKey ();
        }
    }
}
