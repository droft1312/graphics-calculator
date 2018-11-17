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
            string s = ")))";

            int i = 0;

            while ( s[i] == ')' && (s[i] != ',' || s[i] != ' ')) {
                i++;

                if (i == s.Length) break;
            }

            Console.WriteLine (i);

            string @newS = "";

            Console.WriteLine ("Substring: " + s.Substring (i));

            Console.ReadKey ();
        }
    }
}
