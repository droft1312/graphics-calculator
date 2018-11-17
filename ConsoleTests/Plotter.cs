using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Plotter
    {
        BaseNode head;
        bool isFirst = true;

        // s(*(p,+(x,3)))
        
        public void ProcessString(string s) {
            if (isFirst) {
                isFirst = false;

                if (s[0] == 's') {
                    head = new SinNode (s, null);
                } else if (s[0] == '*') {
                    head = new MultiplicationNode (s, null);
                } else if (s[0] == '+') {
                    head = new SumNode (s, null);
                }


                Parse (head.value, head);
            }
        }

        public void Parse(string s, BaseNode baseNode) {
            if (s[0] == 's') {
                var lastLeft = baseNode.FindLastLeft ();
                lastLeft.Insert (new SinNode (s, lastLeft));
            } else if (s[0] == '*') {
                var lastLeft = baseNode.FindLastLeft ();
                lastLeft.Insert (new MultiplicationNode (s, lastLeft));
                lastLeft = baseNode.FindLastLeft ();
                Parse (lastLeft.value, baseNode);
            } else if (s[0] == '+') {

            } else if (s[0] == 'p' || (s[0] >= '0' && s[0] <= '9')) {

                string toParseIntoNumber = string.Empty;
                int counter = 0;

                if (s[0] == 'p') {
                    toParseIntoNumber = "p";
                } else {
                    while (s[counter] != ',') {
                        toParseIntoNumber += s[counter];
                    }
                }

                string @newS = string.Empty;

                for (int i = counter; i < s.Length; i++) {
                    newS += s[counter];
                }

                var lastLeft = baseNode.FindLastLeft ();
                NumberNode node = new NumberNode (newS, baseNode, toParseIntoNumber);
                lastLeft.Insert (node);
                lastLeft = baseNode.FindLastLeft ();
                Parse (newS, baseNode);
            } else if (s[0] == 'x') {
                
            } else if (s[0] == '(' || s[0] == ' ') {
                s = GetStringFromIndex (s, 1); // practically delete that ( or ' '
                Parse (s, baseNode);
            } else if (s[0] == ',') {
                s = GetStringFromIndex (s, 1);
                var preLastLeft = baseNode.FindLastLeft ().parent;
                Parse (s, preLastLeft);
            }
        }


        /// <summary>
        /// Returns a new string that starts from a specified index
        /// </summary>
        /// <param name="s">Input string</param>
        /// <param name="i">Index to start from</param>
        /// <returns></returns>
        public static string GetStringFromIndex (string s, int i) {
            string @return = "";

            for (int j = i; j < s.Length; j++)
                @return += s[j];

            return @return;
        }
    }
}
