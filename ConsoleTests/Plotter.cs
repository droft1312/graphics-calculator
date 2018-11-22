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

        string transitional_output = string.Empty;
        string output = string.Empty;
        int counterForInorderTraversal = 0;

        /* Algorithm for generateGraphVIZTEXT()
         * Typical input:
node1 [ label = "sin"]
node2 [ label = "*"]
node3 [ label = "x"]
node4 [ label = "+"]
node5 [ label = "3"]
node6 [ label = "x"]

            Typical output:
node1 [ label = "sin"]
node1 -- node2 
node2 [ label = "*"]
node2 -- node3
node3 [ label = "x"]
node2 -- node4
node4 [ label = "+"]
node4 -- node5
node5 [ label = "3"]
node4 -- node6
node6 [ label = "x"]


         if (node == '*' / '+' / '-' / '/')
	        Print current node 
	        Print node(currentNumber) -- nextNode(nextNodeNumber)
	        Print nextNode(nextNodeNumber)
	        Print node(currentNumber) -- nextnextNode(nextNodeNumber)
            i++
        else 
	        Print current node
	        Print node(currentNumber) -- nextNode(nextNodeNumber) */

        public string GenerateGraphVIZTEXT () {
            output = "graph calculus {\nnode [ fontname = \"Arial\" ]\n";
            transitional_output = string.Empty;
            counterForInorderTraversal = 0;
            PreOrderTraverse (head);

            var items = transitional_output.Split ('\n');
            List<string> @newItems = new List<string> ();
            for (int i = 0; i < items.Length; i++) {
                string node = getBetween (items[i], "label = \"", "\" ]");
                string toParseIntoNumber = getBetween (items[i], "node", " [").Replace (" ", string.Empty);
                int count1 = int.Parse (toParseIntoNumber);
                toParseIntoNumber = getBetween (items[i + 1], "node", " [").Replace (" ", string.Empty);
                if (toParseIntoNumber == string.Empty) {
                    newItems.Add (items[i]);
                    break;
                }
                int count2 = int.Parse (toParseIntoNumber);

                if (node == "+" || node == "-" || node == "*" || node == "/" || node == "^") {
                    newItems.Add (items[i]); // print (insert) current node
                    newItems.Add (string.Format ("node{0} -- node{1}", count1, count2)); // print node(currentNumber) -- nextNode(nextNumber)
                    newItems.Add (items[i + 1]);
                    int count3 = int.Parse (getBetween (items[i + 2], "node", " [").Replace (" ", string.Empty));
                    newItems.Add (string.Format ("node{0} -- node{1}", count1, count3));
                    i++; 
                } else {
                    newItems.Add (items[i]); // print (insert) current node
                    newItems.Add (string.Format ("node{0} -- node{1}", count1, count2)); // print node(currentNumber) -- nextNode(nextNumber)
                }
            }

            foreach (var item in newItems) output += item + "\n";

            output += "}";

            return transitional_output;
        }

        public void PreOrderTraverse (BaseNode node) {
            if (node == null) {
                return;
            }

            counterForInorderTraversal++;
            /* first print data of node */
            transitional_output += "node" + counterForInorderTraversal + " [ label = \"" + node.ToString () + "\" ]\n";

            /* then recur on left sutree */
            PreOrderTraverse (node.left);

            /* now recur on right subtree */
            PreOrderTraverse (node.right);
        }

        public double ProcessTree (double input) {
            BaseNode @base = head;
            return @base.Calculate (input);
        }

        public void ProcessString (string s) {

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
            } else if (s[0] == 'x') {
                head = new BasicFunctionXNode (s, null);
            }


            CreateTree (head.value, head);

        }

        public void CreateTree (string s, BaseNode baseNode) {

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

        /// <summary>
        /// Returns a substring of a string that is in between 2 other substrings
        /// </summary>
        /// <param name="strSource">Input text</param>
        /// <param name="strStart">Left border</param>
        /// <param name="strEnd">Right border</param>
        /// <returns></returns>
        public static string getBetween (string strSource, string strStart, string strEnd) {
            int Start, End;
            if (strSource.Contains (strStart) && strSource.Contains (strEnd)) {
                Start = strSource.IndexOf (strStart, 0) + strStart.Length;
                End = strSource.IndexOf (strEnd, Start);
                return strSource.Substring (Start, End - Start);
            } else {
                return "";
            }
        }
    }
}
