using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WolframAlphaNET;
using WolframAlphaNET.Objects;

namespace ConsoleTests
{
    class Program
    {
        static void Main (string[] args) {

            string a = "+(r(32.43), *(32, x))";

            if (a.Contains ('r')) a = Plotter.DeleteCharFromString (a, 'r');

            Plotter p = new Plotter ();

            p.ProcessString (a);

            var v = p.Root;

            Console.WriteLine ();

            Console.ReadKey ();
        }
    }
}
