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

        public void ProcessTree(double input) {
            BaseNode @base = head;
            Console.WriteLine (@base.Calculate(input));
        }
        
        
        public void ProcessString(string s) {
            if (isFirst) {
                isFirst = false;

                if (s[0] == 's') {
                    head = new SinNode (s, null);
                } else if (s[0] == '*') {
                    head = new MultiplicationNode (s, null);
                } else if (s[0] == '+') {
                    head = new SumNode (s, null);
                } else if (s[0] == '/') {
                    head = new DivisionNode (s, null);
                } else if (s[0] == '-') {
                    head = new SubstractionNode (s, null);
                } else if (s[0] == 'c') {
                    head = new CosNode (s, null);
                } else if (s[0] == '^') {
                    head = new PowerNode (s, null);
                }


                CreateTree (head.value, head);
            }
        }
        
        public void CreateTree(string s, BaseNode baseNode) {

            // if the string is empty, we don't do anything. This is the base case to leave the recursion
            if (s == string.Empty) return;

            // if it's 's', or '+', or whatever, we create a dedicated class (watch first case to see the logic)
            if (s[0] == 's') {

                SinNode node = new SinNode (s, baseNode); // dedicated class
                baseNode.Insert (node); // we insert it to the current head node
                CreateTree (node.value, node); // we change the head node to the newly created one

            } else if (s[0] == 'c') {

                CosNode node = new CosNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '*') {

                // same as in the first 'if'
                MultiplicationNode node = new MultiplicationNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '+') {

                // same as in the first 'if'
                SumNode node = new SumNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '/') {

                DivisionNode node = new DivisionNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '-') {

                SubstractionNode node = new SubstractionNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '^') {

                PowerNode node = new PowerNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == 'p' || (s[0] >= '0' && s[0] <= '9')) {

                // stuff below just parses number
                string toParseIntoNumber = string.Empty;
                int counter = 0;

                if (s[0] == 'p') {
                    toParseIntoNumber = "p";
                } else {
                    while (s[counter] >= '0' && s[counter] <= '9') {
                        toParseIntoNumber += s[counter];
                        counter++;
                    }
                }

                string @newS = string.Empty;

                for (int i = (s[0] == 'p' ? 1 : counter); i < s.Length; i++) {
                    newS += s[i];
                }

                // same stuff as in the first 'if'
                NumberNode node = new NumberNode (newS, baseNode, toParseIntoNumber);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == 'x') {

                // same as in the first 'if'
                BasicFunctionXNode node = new BasicFunctionXNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '(' || s[0] == ' ') {
                s = GetStringFromIndex (s, 1); // practically delete that ( or ' '
                CreateTree (s, baseNode);
            } else if (s[0] == ')') {

                // count how many times ')' appears, let this number be 'i', then our head node is gonna go 'i' levels up

                int i = 0;

                while (s[i] == ')' && (s[i] != ',' || s[i] != ' ')) {
                    i++;
                    if (i == s.Length) break;
                }

                for (int j = 0; j < i; j++) {
                    if (baseNode.parent != null) {
                        baseNode = baseNode.parent;
                    } else {
                        throw new Exception ("Eror in your input");
                    }
                }


                s = GetStringFromIndex (s, i);
                CreateTree (s, baseNode);

            } else if (s[0] == ',') {
                if (baseNode.parent == null) throw new Exception ("Error in your input");

                // go one level up
                baseNode = baseNode.parent;
                s = GetStringFromIndex (s, 1);
                CreateTree (s, baseNode);
            }
        }

        public BaseNode GetTree() {
            return head;
        }

        public double GetValueOfNode(BaseNode baseNode, double value) {
            if (baseNode.GetType() == typeof(NumberNode)) {
                return ((NumberNode)baseNode).RealValue;
            } else if (baseNode.GetType() == typeof(BasicFunctionXNode)) {
                return value;
            } else {
                return -1;
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
