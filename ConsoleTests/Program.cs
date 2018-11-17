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
            string s = "25365,+(x,3)))";

            int counter = 0;
            string @newString = "";

            while (s[counter] != ',') {
                newString += s[counter];
                counter++;
            }
            Console.WriteLine (newString);

            newString = "";

            for (int i = counter; i < s.Length; i++) {
                newString += s[i];
            }
            Console.WriteLine (newString);

            Console.ReadKey ();
        }
    }
}
