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
            //string input = "/(*(x,+(3,*(2,x))),+(x,*(5,x)))";
            string input = "s(/(+(x,3),5))";

            Plotter plotter = new Plotter ();
            plotter.ProcessString (input);

            //Console.WriteLine(plotter.PrefixToInfix ("/(*(x,+(3,*(2,x))),+(x,*(5,x)))"));

            WolframAlpha wolfram = new WolframAlpha ("HVTG5G-R85WWR978J");

            //Then you simply query Wolfram|Alpha like this
            //Note that the spelling error will be correct by Wolfram|Alpha
            QueryResult results = wolfram.Query (plotter.PrefixToInfix ("/(*(x,+(3,*(2,x))),+(x,*(5,x)))"));

            //The QueryResult object contains the parsed XML from Wolfram|Alpha. Lets look at it.
            //The results from wolfram is split into "pods". We just print them.
            if (results != null) {
                foreach (Pod pod in results.Pods) {
                    Console.WriteLine (pod.Title);
                    if (pod.SubPods != null) {
                        foreach (SubPod subPod in pod.SubPods) {
                            Console.WriteLine (subPod.Title);
                            Console.WriteLine (subPod.Image.Src);
                            Console.WriteLine (subPod.Plaintext);
                            
                        }
                    }
                    Console.WriteLine (new string('-', 20));
                }
            }

            Console.ReadKey ();
        }
    }
}
