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
            //string input = "s(*(x, +(3,x)))";
            //string input = "+(-(x, 3),x)";

            Plotter plotter = new Plotter ();
            plotter.ProcessString (input);

            Console.WriteLine (plotter.GenerateGraphVIZTEXT ());

            Console.ReadKey ();
        }
    }
}
