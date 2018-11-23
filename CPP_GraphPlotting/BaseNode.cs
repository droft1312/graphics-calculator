using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP_GraphPlotting
{
    static class NodeCounter
    {
        public static int Count = 0;
    }

    class BaseNode
    {
        /// <summary>
        /// If input during the initializing of the node was s(x) => value = (x)
        /// </summary>
        public string value;
        /// <summary>
        /// Left, right, and parent reference for binary tree
        /// </summary>
        public BaseNode left, right, parent;

        public bool visited = false;

        public int number;

        public BaseNode () {
            number = ++NodeCounter.Count;
        }

        public void Insert (BaseNode node) {
            if (left == null) {
                left = node;
            } else if (right == null) {
                right = node;
            } else {
                // do nothing
            }
        }

        /// <summary>
        /// Calculates the value of the current node
        /// </summary>
        /// <param name="number">Input</param>
        /// <returns></returns>
        public virtual double Calculate (double number) {
            return -1;
        }

        public virtual string Print () {
            return "";
        }
    }

    class SubstractionNode : BaseNode
    {
        public SubstractionNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return left.Calculate (number) - right.Calculate (number);
        }

        public override string ToString () {
            return "-";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }
    }

    class MultiplicationNode : BaseNode
    {
        public MultiplicationNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return left.Calculate (number) * right.Calculate (number);
        }

        public override string ToString () {
            return "*";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }
    }

    class SumNode : BaseNode
    {
        public SumNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }


        public override double Calculate (double number) {
            return left.Calculate (number) + right.Calculate (number);
        }

        public override string ToString () {
            return "+";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }
    }

    class DivisionNode : BaseNode
    {
        public DivisionNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return left.Calculate (number) / right.Calculate (number);
        }

        public override string ToString () {
            return "/";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }
    }

    class NumberNode : BaseNode
    {
        double realValue;

        public NumberNode (string input, BaseNode parentNode, string realValue) {
            value = input;
            parent = parentNode;


            if (realValue[0] == 'p') {
                this.realValue = 3.14d;
            } else {
                this.realValue = Double.Parse (realValue);
            }
        }

        public double RealValue { get { return realValue; } }

        public override string ToString () {
            return realValue.ToString ();
        }

        public override double Calculate (double number) {
            return realValue;
        }

    }

    class BasicFunctionXNode : BaseNode
    {
        public BasicFunctionXNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return number;
        }

        public override string ToString () {
            return "x";
        }
    }

    class SinNode : BaseNode
    {
        public SinNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return Math.Sin (left.Calculate (number));
        }
        public override string ToString () {
            return "sin";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\n", number, left.number);
        }
    }


    class CosNode : BaseNode
    {
        public CosNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return Math.Cos (left.Calculate (number));
        }

        public override string ToString () {
            return "cos";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\n", number, left.number);
        }
    }

    class PowerNode : BaseNode
    {
        public PowerNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public override double Calculate (double number) {
            return Math.Pow (left.Calculate (number), right.Calculate (number));
        }

        public override string ToString () {
            return "^";
        }
        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }
    }
}
