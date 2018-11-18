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
            string input = "s(*(p, +(x,3)))";

            Plotter plotter = new Plotter ();
            plotter.ProcessString (input);
            var obj = plotter.GetTree ();

            Console.WriteLine (obj.FindLastLeft().parent.GetType().Name);
            Console.Write ("");

            Console.ReadKey ();
        }
    }
}
