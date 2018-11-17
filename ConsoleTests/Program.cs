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
            string input = "s(+(x,3))";

            Plotter plotter = new Plotter ();
            plotter.ProcessString (input);
            var obj = plotter.GetTree ();

            // find the most left
            var lastLeft = obj.FindLastLeft ();
            Console.WriteLine (lastLeft.GetType().Name);

            Console.ReadKey ();
        }
    }
}
