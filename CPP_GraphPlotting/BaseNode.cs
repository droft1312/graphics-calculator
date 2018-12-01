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

        public BaseNode(string value) {
            this.value = value;
            left = right = null;
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

        /// <summary>
        /// For printing out node-connections (graphviz)
        /// </summary>
        /// <returns></returns>
        public virtual string Print () {
            return "";
        }

        public virtual BaseNode ReturnDerivative() {
            return null;
        }

        public virtual void CreateDerivativeTree(BaseNode parent, bool isLeft = true) {
        }
    }

    class SubstractionNode : BaseNode
    {
        public SubstractionNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public SubstractionNode (BaseNode left, BaseNode right, BaseNode parent) {
            value = string.Empty;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }

        public SubstractionNode (string value) : base (value) {
        }

        public override double Calculate (double number) => left.Calculate (number) - right.Calculate (number);

        public override string ToString () {
            return "-";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            SubstractionNode node = new SubstractionNode (this.left, this.right, parent);
            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }
            node.left.CreateDerivativeTree (node);
            node.right.CreateDerivativeTree (node, false);
        }
    }

    class MultiplicationNode : BaseNode
    {
        public MultiplicationNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public MultiplicationNode (BaseNode left, BaseNode right, BaseNode parent) {
            value = string.Empty;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }

        public MultiplicationNode (string value) : base (value) {
        }

        public override double Calculate (double number) => left.Calculate (number) * right.Calculate (number);

        public override string ToString () {
            return "*";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            SumNode sum = new SumNode (this, this, this.parent);

            if (parent != null) {
                if (isLeft)
                    parent.left = sum;
                else
                    parent.right = sum;
            }

            sum.left.left.CreateDerivativeTree (sum.left);
            sum.right.right.CreateDerivativeTree (sum.right, false);
        }
    }

    class SumNode : BaseNode
    {
        public SumNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }
        public SumNode (BaseNode left, BaseNode right, BaseNode parent) {
            value = string.Empty;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }

        public SumNode (string value) : base (value) {
        }

        public override double Calculate (double number) => left.Calculate (number) + right.Calculate (number);

        public override string ToString () {
            return "+";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            SumNode node = new SumNode (this.left, this.right, parent);
            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }
            node.left.CreateDerivativeTree (this);
            node.right.CreateDerivativeTree (this, false);
        }
    }

    class DivisionNode : BaseNode
    {
        public DivisionNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public DivisionNode (string value) : base (value) {
        }

        public override double Calculate (double number) => left.Calculate (number) / right.Calculate (number);

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

        public NumberNode (BaseNode parent, double realValue) {
            value = string.Empty;
            this.parent = parent;
            this.realValue = realValue;
        }

        public NumberNode (string value) : base (value) {
        }

        public double RealValue { get { return realValue; } }

        public override string ToString () {
            return realValue.ToString ();
        }

        public override double Calculate (double number) => realValue;

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            NumberNode node = new NumberNode (parent, 0);
            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }
            return;
        }

        public override BaseNode ReturnDerivative () {
            return null;
        }
    }

    class BasicFunctionXNode : BaseNode
    {
        public BasicFunctionXNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public BasicFunctionXNode (string value) : base (value) {
        }

        public override double Calculate (double number) => number;

        public override string ToString () {
            return "x";
        }

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            NumberNode node = new NumberNode (parent, 1);
            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }
            return;
        }

        public override BaseNode ReturnDerivative () {
            return null;
        }
    }

    class SinNode : BaseNode
    {
        public SinNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public SinNode (string value) : base (value) {
        }

        public override double Calculate (double number) => Math.Sin (left.Calculate (number));

        public override string ToString () {
            return "sin";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\n", number, left.number);
        }

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            if (!(this.left is BasicFunctionXNode || this.left is NumberNode)) {
                MultiplicationNode multiplication = new MultiplicationNode (this.left, this.ReturnDerivative (), this.parent);
                multiplication.left.CreateDerivativeTree (multiplication);
            }
        }

        public override BaseNode ReturnDerivative () {
            CosNode cosNode = new CosNode (left, parent);
            //this.parent = null; // NOT SURE ABOUT THIS
            return cosNode;
        }
    }


    class CosNode : BaseNode
    {
        public CosNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public CosNode (BaseNode left, BaseNode parent) {
            this.left = left;
            this.parent = parent;
        }

        public CosNode (string value) : base (value) {
        }

        public override double Calculate (double number) => Math.Cos (left.Calculate (number));

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

        public PowerNode (string value) : base (value) {
        }

        public override double Calculate (double number) => Math.Pow (left.Calculate (number), right.Calculate (number));

        public override string ToString () {
            return "^";
        }
        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }
    }
}
