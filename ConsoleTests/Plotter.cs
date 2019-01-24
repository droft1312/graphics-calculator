using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OxyPlot;
using static ConsoleTests.LagrangeItem;


namespace ConsoleTests
{
    /// <summary>
    /// Describes the type of the char (is used in prefix-to-infix methods)
    /// </summary>
    enum TypeOfChar
    {
        Operand,
        TwoValueOperation,
        OneValueOperation
    }

    /// <summary>
    /// Is used in prefix-to-infix methods
    /// </summary>
    class ReverseElement
    {
        public string Value { get; protected set; }
        public TypeOfChar Type { get; protected set; }

        public ReverseElement (string value) {
            this.Value = value;

            if (value == "+" || value == "-" || value == "*" || value == "/" || value == "^") {
                Type = TypeOfChar.TwoValueOperation;
            } else if (value == "s" || value == "c" || value == "!" || value == "l") {
                Type = TypeOfChar.OneValueOperation;
            } else {
                Type = TypeOfChar.Operand;
            }
        }
    }

    class Element : ReverseElement
    {
        public Element (string value) : base (value) {
        }
    }

    class Plotter
    {
        const double h = 0.001;

        private BaseNode root;
        public BaseNode Root { get { return root; } }
        public static BaseNode derivativeRoot = null;

        #region GraphViz
        #region GraphViz variables
        string transitional_output = string.Empty;
        string output = string.Empty;
        int counterForInorderTraversal = 0;
        private string nodeConnections = "";
        #endregion

        #region GraphVizRepresentation

        /// <summary>
        /// Returns a complete image of graphviz
        /// </summary>
        /// <returns></returns>
        public void GetGraphImage (PictureBox pictureBox, BaseNode baseNode) {
            WriteFileGRAPHVIZ (baseNode);
            Process dot = new Process ();
            dot.StartInfo.FileName = "dot.exe";
            dot.StartInfo.Arguments = "-Tpng -oabc.png abc.dot";
            dot.Start ();
            dot.WaitForExit ();
            pictureBox.ImageLocation = "abc.png";
        }

        /// <summary>
        /// Writes output of <see cref="GenerateGraphVIZTEXT"/>() to a specific file
        /// </summary>
        private void WriteFileGRAPHVIZ (BaseNode baseNode) {
            try {
                File.WriteAllText ("abc.dot", GenerateGraphVIZTEXT (baseNode));
            } catch (Exception e) {
                MessageBox.Show (e.Message);
            }
        }

        /// <summary>
        /// Adds to the transitional_output relations between nodes. To be called ONLY AFTER <see cref="PreOrderTraverse"/>()
        /// </summary>
        /// <param name="root"></param>
        private void PrintNodeConnections (BaseNode root) {
            if (root == null) {
                return;
            }

            /* first print data of node */

            nodeConnections += root.Print ();

            /* then recur on left sutree */
            PrintNodeConnections (root.left);

            /* now recur on right subtree */
            PrintNodeConnections (root.right);
        }

        /// <summary>
        /// Generates text that would be inputted to GraphVIZ
        /// </summary>
        /// <returns>Input string for graphviz</returns>
        private string GenerateGraphVIZTEXT (BaseNode baseNode) {
            // -------------------------------------------------------------------
            // resetting all variables
            output = "graph calculus {\nnode [ fontname = \"Arial\" ]\n";
            transitional_output = string.Empty;
            nodeConnections = string.Empty;
            counterForInorderTraversal = 0;
            PreOrderTraverse (baseNode);
            // -------------------------------------------------------------------

            PrintNodeConnections (baseNode);
            output += transitional_output;
            output += nodeConnections;

            output += "}";

            return output;
        }

        /// <summary>
        /// Does the pre-order traversal of the tree and prints it to the transitional_output
        /// </summary>
        /// <param name="node">Root node</param>
        private void PreOrderTraverse (BaseNode node) {
            if (node == null) {
                return;
            }

            counterForInorderTraversal++;
            /* first print data of node */

            transitional_output += "node" + node.number + " [ label = \"" + node.ToString () + "\" ]\n";

            /* then recur on left sutree */
            PreOrderTraverse (node.left);

            /* now recur on right subtree */
            PreOrderTraverse (node.right);
        }

        #endregion
        #endregion

        public BaseNode CreatePolynomialThroughPoints (DataPoint[] points) {
            /* Let X be the number of points user has selected
             * Then the polynomial is going to be of the degree (X - 1)
             * 
             * Example: X = 5 => ax^4 + bx^3 + cx^2 + dx + e
             */

            SumNode polynomial = new SumNode (null, null, null);

            var firstDivision = ProduceLagrange (points, 0);
            var firstMultiplication = new MultiplicationNode (firstDivision, new NumberNode (null, points[0].Y), null);
            polynomial.left = firstMultiplication;

            for (int j = 1; j < points.Length; j++) {
                var division = ProduceLagrange (points, j);
                MultiplicationNode node = new MultiplicationNode (division, new NumberNode (null, points[j].Y), null);
                polynomial.PutToRightNode (node);
            }

            return polynomial;
        }

        /// <summary>
        /// Creates a MacLaurien series based off the function
        /// </summary>
        /// <param name="mcLaurienRoot">Where the McLaurien Series will be outputted</param>
        /// <param name="order">Nth order of a series</param>
        public void CreateMcLaurienSeries (out BaseNode mcLaurienRoot, int order = 5) {

            if (derivativeRoot == null) { CreateDerivativeTree (); derivativeRoot.Simplify (); }

            // we made sure that there is a derivative

            BaseNode myDerivative = Plotter.CloneTree (derivativeRoot);
            myDerivative.derivativeRoot = myDerivative;
            double[] values = new double[order + 1]; // values for functions (f(0), derivative of f(0), second derivative of f(0), etc..)

            values[0] = root.Calculate (0); // set up a value for f(0)
            if (values.Length >= 2) values[1] = derivativeRoot.Calculate (0); // set up a value of the first derivative of f(0)

            if (values.Length >= 3) {
                for (int i = 2; i < values.Length; i++) {
                    myDerivative.CreateDerivativeTree (null);
                    values[i] = myDerivative.derivativeRoot.Calculate (0);
                    myDerivative = myDerivative.derivativeRoot;
                }
            }

            List<BaseNode> mcLaurienItems = new List<BaseNode> ();

            SumNode result = new SumNode (null, null, null);
            result.left = new NumberNode (null, values[0]);

            for (int i = 1; i < values.Length; i++) {
                DivisionNode item = new DivisionNode (null, null, null);
                FactorialNode denominator = new FactorialNode (new NumberNode (null, i), null); // not sure about this line
                MultiplicationNode numerator = new MultiplicationNode (
                    new NumberNode (null, values[i]),
                    new PowerNode (new BasicFunctionXNode ("", null), new NumberNode (null, i), null), null
                );
                item.left = numerator;
                item.right = denominator;
                mcLaurienItems.Add (item);
            }

            foreach (var item in mcLaurienItems) result.PutToRightNode (item);

            mcLaurienRoot = result;
        }

        /// <summary>
        /// Get the McLaurien series based off already given values for derivatives
        /// </summary>
        /// <param name="mcLaurienRoot">Where the McLaurien series will be outputted</param>
        /// <param name="order">Order of the McLaurien</param>
        public void CreateMcLaurienSeriesByLimits (out BaseNode mcLaurienRoot, int order) {

            List<double> values = new List<double> ();
            for (int i = 0; i <= order; i++) {
                var value = ProcessNthDerivative_Quotient (0, i, root);
                values.Add (value);
            }

            List<BaseNode> mcLaurienItems = new List<BaseNode> ();

            SumNode result = new SumNode (null, null, null);
            result.left = new NumberNode (null, values[0]);

            for (int i = 1; i < values.Count; i++) {
                DivisionNode item = new DivisionNode (null, null, null);
                FactorialNode denominator = new FactorialNode (new NumberNode (null, i), null); // not sure about this line
                MultiplicationNode numerator = new MultiplicationNode (
                    new NumberNode (null, values[i]),
                    new PowerNode (new BasicFunctionXNode ("", null), new NumberNode (null, i), null), null
                );
                item.left = numerator;
                item.right = denominator;
                mcLaurienItems.Add (item);
            }

            foreach (var item in mcLaurienItems) result.PutToRightNode (item);

            mcLaurienRoot = result;
        }

        /// <summary>
        /// Returns an area of the definite integral
        /// </summary>
        /// <param name="lowerBoundary">Lower boundary (start from this x-value)</param>
        /// <param name="upperBoundary">Upper boundary (end at this x-value)</param>
        /// <returns></returns>
        public double ProcessIntegral (int lowerBoundary, int upperBoundary) {
            double total = 0;
            double current = lowerBoundary;
            for (double i = lowerBoundary + 0.01; i <= upperBoundary; i += 0.01) {
                total += Math.Abs (CalculateRectangleArea (i - current, ProcessTree (i, Root)));
                current = i;
            }
            return total;
        }

        /// <summary>
        /// Gives the value of the derivative using the quotient formula
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double ProcessDerivative_Quotient (double input, BaseNode root) {
            BaseNode @base = root;
            double x1 = input - h;
            double x2 = input + h;
            double y1 = @base.Calculate (x1);
            double y2 = @base.Calculate (x2);
            return (y2 - y1) / (x2 - x1);
        }

        /// <summary>
        /// Gives a value for the Nth derivative of a function using the definition
        /// </summary>
        /// <param name="input">F^(n)(X0), input is X0</param>
        /// <param name="n">The degree of derivative</param>
        /// <param name="root">Initial function</param>
        /// <returns>F^(n)(X0)</returns>
        public double ProcessNthDerivative_Quotient (double input, int n, BaseNode root) {
            /*
                FORMULA:

                k=0 -> n
                
                sum ( (-1)^(k)*(n!/(k! * (n-k)!))*f(X0 + h*( (n-2k)/2 )) ) / h^n

                where 'n' is the order for derivative and X0 is the f^n(x0)
            */

            double @return = 0;

            for (int k = 0; k <= n; k++) {
                double firstElement = Math.Pow (-1, k);
                double secondElement = MathNet.Numerics.SpecialFunctions.Factorial (n) / (MathNet.Numerics.SpecialFunctions.Factorial (k) *
                    MathNet.Numerics.SpecialFunctions.Factorial (n - k));
                double thirdElement = ProcessTree (input + ((n - 2 * (double)k) / 2) * h, root);
                @return += firstElement * secondElement * thirdElement;
            }

            @return /= Math.Pow (h, n);

            return @return;
        }

        /// <summary>
        /// Returns the y-value for x-value based on a previously built binary tree. To be called only after ProcessString() func
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double ProcessTree (double input, BaseNode root) {
            BaseNode @base = root;
            return @base.Calculate (input);
        }

        /// <summary>
        /// To be called when a tree needs to be built upon an input string
        /// </summary>
        /// <param name="s"></param>
        public void ProcessString (string s) {

            if (s[0] == 's') {
                root = new SinNode (s, null);
            } else if (s[0] == '*') {
                root = new MultiplicationNode (s, null);
            } else if (s[0] == '+') {
                root = new SumNode (s, null);
            } else if (s[0] == '/') {
                root = new DivisionNode (s, null);
            } else if (s[0] == '-' && !(s[1] >= '0' && s[1] <= '9')) {
                root = new SubstractionNode (s, null);
            } else if (s[0] == 'c') {
                root = new CosNode (s, null);
            } else if (s[0] == 'l') {
                root = new LnNode (s, null);
            } else if (s[0] == '^') {
                root = new PowerNode (s, null);
            } else if (s[0] == '!') {
                root = new FactorialNode (s, null);
            } else if (s[0] == 'x') {
                root = new BasicFunctionXNode (s, null);
            } else if (s[0] >= '0' && s[0] <= '9') {
                string toParseIntoNumber = string.Empty;
                int counter = 0;

                if (s[0] == 'p') {
                    toParseIntoNumber = "p";
                } else {
                    do {
                        toParseIntoNumber += s[counter];
                        counter++;
                    } while (counter < s.Length && (s[counter] >= '0' && s[counter] <= '9') || s[counter] == '.');
                }

                string @newS = string.Empty;

                for (int i = (s[0] == 'p' ? 1 : counter); i < s.Length; i++) {
                    newS += s[i];
                }

                // same stuff as in the first 'if'
                root = new NumberNode (newS, null, toParseIntoNumber);
            } else if (s[0] == '-' && (s[1] >= '0' && s[1] <= '9')) {
                // negative number
                s = Plotter.GetStringFromIndex (s, 1);

                string toParseIntoNumber = string.Empty;
                int counter = 0;

                if (s[0] == 'p') {
                    toParseIntoNumber = "p";
                } else {
                    do {
                        toParseIntoNumber += s[counter];
                        counter++;
                    } while (counter < s.Length && (s[counter] >= '0' && s[counter] <= '9') || s[counter] == '.');
                }

                string @newS = string.Empty;

                for (int i = (s[0] == 'p' ? 1 : counter); i < s.Length; i++) {
                    newS += s[i];
                }

                // same stuff as in the first 'if'
                root = new NumberNode (newS, null, "-" + toParseIntoNumber);
            }

            CreateTree (root.value, root);

        }

        /// <summary>
        /// Creates tree based on an input string and root node
        /// </summary>
        /// <param name="s"></param>
        /// <param name="baseNode"></param>
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

            } else if (s[0] == '-' && !(s[1] >= '0' && s[1] <= '9')) {

                SubstractionNode node = new SubstractionNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == 'l') {

                LnNode node = new LnNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '^') {

                PowerNode node = new PowerNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '!') {

                FactorialNode node = new FactorialNode (s, baseNode);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == 'p' || (s[0] >= '0' && s[0] <= '9')) {

                // stuff below just parses number
                string toParseIntoNumber = string.Empty;
                int counter = 0;

                if (s[0] == 'p') {
                    toParseIntoNumber = "p";
                } else {
                    while ((s[counter] >= '0' && s[counter] <= '9') || s[counter] == '.') {
                        toParseIntoNumber += s[counter];
                        counter++;
                    }
                }

                if (toParseIntoNumber.Contains ('.')) toParseIntoNumber = toParseIntoNumber.Replace ('.', ',');

                string @newS = string.Empty;

                for (int i = (s[0] == 'p' ? 1 : counter); i < s.Length; i++) {
                    newS += s[i];
                }

                // same stuff as in the first 'if'
                NumberNode node = new NumberNode (newS, baseNode, toParseIntoNumber);
                baseNode.Insert (node);
                CreateTree (node.value, node);

            } else if (s[0] == '-' && (s[1] >= '0' && s[1] <= '9')) {
                // negative number
                s = Plotter.GetStringFromIndex (s, 1);

                string toParseIntoNumber = string.Empty;
                int counter = 0;

                if (s[0] == 'p') {
                    toParseIntoNumber = "p";
                } else {
                    do {
                        toParseIntoNumber += s[counter];
                        counter++;
                    } while (counter < s.Length && ((s[counter] >= '0' && s[counter] <= '9') || s[counter] == '.'));
                }

                string @newS = string.Empty;

                for (int i = (s[0] == 'p' ? 1 : counter); i < s.Length; i++) {
                    newS += s[i];
                }

                NumberNode node = new NumberNode (newS, baseNode, "-" + toParseIntoNumber);
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
        /// Simplifies a tree (gets rid of nodes like 1*x, 0*2 etc.)
        /// </summary>
        /// <param name="tree">Tree to simplify</param>
        public BaseNode SimplifyTree (BaseNode tree) {
            var simplifiedTree = CloneTree (tree);
            simplifiedTree = simplifiedTree.Simplify ();
            return simplifiedTree;
        }

        /// <summary>
        /// Sets the derivateRoot to the root of a last inputted function and gets its derivative
        /// </summary>
        public void CreateDerivativeTree () {
            derivativeRoot = root;
            derivativeRoot.CreateDerivativeTree (null);
            derivativeRoot = derivativeRoot.derivativeRoot;
            /* 
             What happens here is I calculate the derivative of the derivativeRoot (which is initially equal to the root of the function)
             Inside of the class BaseNode, which every other node derives from, there is a public field derivativeRoot which holds the value
             for the derivative. This field is altered after the call of CreateDerivativeTree() so that's why we make our plotter.derivativeRoot 
             equal to the one inside of a node.
             
             VERY BAD DESIGN

             */
        }

        /// <summary>
        /// Used for tracking the derivative root. Is used in Nodes
        /// </summary>
        /// <param name="node"></param>
        public static void SetDerivativeRoot (BaseNode node, ref BaseNode derivativeRoot) {
            derivativeRoot = node;
        }

        /// <summary>
        /// Clones a specified tree based on a given node 'root'
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static BaseNode CloneTree (BaseNode root) {
            if (root == null) return null;

            BaseNode newNode = null;
            if (root is SubstractionNode) {
                newNode = new SubstractionNode (root.value);
            } else if (root is MultiplicationNode) {
                newNode = new MultiplicationNode (root.value);
            } else if (root is SumNode) {
                newNode = new SumNode (root.value);
            } else if (root is DivisionNode) {
                newNode = new DivisionNode (root.value);
            } else if (root is NumberNode) {
                newNode = new NumberNode (null, (root as NumberNode).RealValue);
            } else if (root is BasicFunctionXNode) {
                newNode = new BasicFunctionXNode (root.value);
            } else if (root is SinNode) {
                newNode = new SinNode (root.value);
            } else if (root is CosNode) {
                newNode = new CosNode (root.value);
            } else if (root is PowerNode) {
                newNode = new PowerNode (root.value);
            } else if (root is LnNode) {
                newNode = new LnNode (root.value);
            } else if (root is FactorialNode) {
                newNode = new FactorialNode (root.value);
            }

            newNode.left = CloneTree (root.left);
            newNode.right = CloneTree (root.right);
            return newNode;
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
        /// If you wanna delete for example 'n' from a string s(n(-32)), you will get this: s(-32)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="itemToDelete"></param>
        /// <returns></returns>
        public static string DeleteCharFromString (string input, char itemToDelete) {

            // Removes the first occurence of a specified char in a specified string
            string RemoveFirstOccurenceOf (string yourString, char toDelete) {
                int index = -1;

                for (int i = 0; i < yourString.Length; i++) if (yourString[i] == toDelete) { index = i; break; }

                if (index == -1) throw new Exception ("Specified char has not been found");

                return yourString.Remove (index, 1);
            }

            int GetIndexOf (string yourString, char toFind) {
                int index = -1;

                for (int i = 0; i < yourString.Length; i++) if (yourString[i] == toFind) { index = i; break; }

                return index;
            }

            string corrected_string = string.Empty;
            bool concatenated = false;

            int indexOfN = input.ToLower ().IndexOf (itemToDelete);
            string substring = input.Substring (indexOfN);
            int indexOfClosingParentheses = GetIndexOf (substring, ')');
            substring = substring.Substring (0, indexOfClosingParentheses);
            substring = RemoveFirstOccurenceOf (substring, '(');
            substring = substring.Contains (')') ? RemoveFirstOccurenceOf (substring, ')') : substring;
            substring = RemoveFirstOccurenceOf (substring, itemToDelete);

            for (int i = 0; i < input.Length; i++) {
                if (i == indexOfN && !concatenated) {
                    corrected_string += substring;
                    i = Math.Abs (indexOfClosingParentheses + indexOfN);
                    concatenated = true;
                } else {
                    corrected_string += input[i];
                }
            }

            return corrected_string;
        }

        /// <summary>
        /// Converts a string written in prefix-notation into a string written in an infix-notation
        /// </summary>
        /// <param name="input">Prefix-notated input string</param>
        /// <returns></returns>
        public string PrefixToInfix (string input) {
            var reversed = InputReverse (input);
            var inreversed = new List<Element> ();
            string infix = string.Empty;

            // input: s(/(+(x,3),435))
            // reversed: 435/(x+3), s

            for (int i = 0; i < reversed.Length; i++) {
                if (reversed[i].Type == TypeOfChar.Operand) {
                    continue;
                } else if (reversed[i].Type == TypeOfChar.OneValueOperation) {
                    string temp = $"{reversed[i].Value}({reversed[i - 1].Value})";
                    if (reversed[i].Value == "!") temp = $"({reversed[i - 1].Value}){reversed[i].Value}";
                    Element element = new Element (temp);
                    reversed[i - 1] = element;
                    reversed[i] = null;
                    UpdateElementsArray (ref reversed);
                    i = -1;
                } else if (reversed[i].Type == TypeOfChar.TwoValueOperation) {
                    string temp = $"({reversed[i - 1].Value} {reversed[i].Value} {reversed[i - 2].Value})";
                    if (reversed[i].Value == "^") temp = $"(({reversed[i - 1].Value}){reversed[i].Value}({reversed[i - 2].Value}))";
                    Element element = new Element (temp);
                    reversed[i - 2] = element;
                    reversed[i - 1] = null;
                    reversed[i] = null;
                    UpdateElementsArray (ref reversed);
                    i = -1;
                }
            }
            infix = reversed[0].Value;
            return infix.Replace ("s", "sin").Replace ("c", "cos").Replace ("l", "ln");
        }

        /// <summary>
        /// Deletes all null elements an input array and returns a new one
        /// </summary>
        /// <param name="arr"></param>
        private void UpdateElementsArray (ref ReverseElement[] arr) {
            List<ReverseElement> elements = new List<ReverseElement> ();
            foreach (var item in arr) if (item != null) elements.Add (item);
            arr = elements.ToArray ();
        }

        /// <summary>
        /// Returns an array that is a reverse string input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private ReverseElement[] InputReverse (string input) {
            List<ReverseElement> reverse = new List<ReverseElement> ();
            string temp = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--) {
                if (input[i] == '(' || input[i] == ')' || input[i] == ',') {
                    continue;
                } else if (input[i] >= '0' && input[i] <= '9') {
                    int counter = i;

                    do {
                        temp += input[counter];
                        counter--;
                    } while (counter >= 0 && input[counter] >= '0' && input[counter] <= '9');

                    var normalOrderNumber = temp.Reverse ();
                    string toAdd = "";

                    foreach (var digit in normalOrderNumber) toAdd += digit;

                    i = counter;
                    temp = string.Empty;

                    reverse.Add (new ReverseElement (toAdd));
                } else {
                    reverse.Add (new ReverseElement (input[i].ToString ()));
                }
            }
            return reverse.ToArray ();
        }

        /// <summary>
        /// Calculates the area of rectangle
        /// </summary>
        /// <param name="x">Rectangle's width</param>
        /// <param name="y">Rectangle's height</param>
        /// <returns>x times y</returns>
        private double CalculateRectangleArea (double x, double y) => x * y;
    }
}
