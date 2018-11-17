using System;
using System.Collections.Generic;
using System.Linq;

namespace CPP_GraphPlotting
{
    class Plotter
    {
        BasicMathAction head;
        int z = 0; // just for head, so that we initialize it inside of parse(string s)

        public Plotter () {
        }

        // BASE CASE: +(x, 3)
        // INPUT EXAMPLE 1: S(*(p,x))
        // INPUT EXAMPLE 2: /(*(-(x,3),+(c(n(-73)),r(1.6))), e(!(5)))
        // INPUT EXAMPLE 3: /(*(x, +(3, *(2,x))), +(x, *(5, x)))
        // INPUT EXAMPLE 4: +(*(x,3), 4)
   
        public void Parse (string s) {
            //For the sake of clearness, I use here INPUT EXAMPLE 1 for explanation. So when you read through this algorithm, think about this expresssion
            
            if (s[0] == '+' || s[0] == '-' || s[0] == '*' || s[0] == '/' || s[0] == 's' || s[0] == 'c') {
                // if it is any of those above mentioned operations like sum/multiplication
                if (z == 0) { // check if it's actually the very beginning, if it is, then we assign a value to a head
                    z++;
                    head = new BasicMathAction (s, null);
                    Parse (head.value); // we go again but the string now is from s[2], so head.value = *(p,x))
                } else {
                    var lastLeftObject = head.FindLastLeft (); // we find the last object left object in the tree
                    lastLeftObject.InsertLeft (new BasicMathAction (s, lastLeftObject)); // add new one
                    Parse ((lastLeftObject.left == null ? throw new Exception("Problem occured with parsing a string. WTF IS GOING ON") : lastLeftObject.left.value));
                }
            } else if (s[0] == 'x' || (s[0]>='0' && s[0] <= '9') || s[0] == 'n' || s[0] == 'r' || s[0] == 'p') {
                // that implies we have reached the base case, which in this case is 'p'
                var lastLeft = head.FindLastLeft (); // we find again the last left leaf
                lastLeft.InsertLeft (new MathOperator (s, lastLeft)); // we attach new object 
                // at this point our s = ,x)), and now we have got to go back
                Parse (lastLeft.left.value);
            } else if (s[0] == ',') {
                var lastLeft = head.FindLastLeft ();
                var oneLevelUp = lastLeft.parent;
            }
        }

        public bool IsCorrectFormat (string input) {
            string specialCharacters = "(), ";
        }

        public static string GetStringFromIndex (string s, int i) {
            string @return = "";

            for (int j = i; j < s.Length; j++)
                @return += s[j];

            return @return;
        }
    }
}
