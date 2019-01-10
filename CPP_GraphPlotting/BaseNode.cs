using System;

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
        public BaseNode derivativeRoot;

        public int number;

        public BaseNode () {
            number = ++NodeCounter.Count;
            derivativeRoot = Plotter.derivativeRoot;
        }

        public BaseNode (string value) : this () {
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

        /// <summary>
        /// Calculates the derivative of a tree based on a parent node
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="isLeft"></param>
        public virtual void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
        }

        protected void SetDerivativeRoot(BaseNode node) {
            Plotter.SetDerivativeRoot (node, ref derivativeRoot);
        }

        public virtual BaseNode Simplify () {
            return null;
        }

        public BaseNode FindMostRight() {
            if (right == null) {
                return this;
            } else {
                return right.FindMostRight ();
            }
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
            SubstractionNode node = new SubstractionNode (Plotter.CloneTree (this.left), Plotter.CloneTree (this.right), parent);
            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }
            node.left.CreateDerivativeTree (node);
            node.right.CreateDerivativeTree (node, false);

            //Plotter.SetDerivativeRoot (node, Plotter.derivativeRoot);
            SetDerivativeRoot (node);
        }

        public override BaseNode Simplify () {
            if (!(left is NumberNode || right is NumberNode)) { // if neither left nor right guy is a number
                this.left = this.left.Simplify (); // tell the left guy to get simple
                this.right = this.right.Simplify (); // right guy also has to get simple

                if (left is NumberNode && right is NumberNode) {
                    NumberNode substraction = new NumberNode (
                        null,
                        ((left as NumberNode).RealValue - (right as NumberNode).RealValue)
                    );
                    return substraction;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    this.left = this.left.Simplify ();
                    if (value == 0) { return this.left; }
                    return this;
                } else {
                    return this;
                }

            } else { // if one of them IS actually a number
                // we go over all the possibilities
                if (left is NumberNode && right is NumberNode) {
                    NumberNode substraction = new NumberNode (
                        null,
                        ((left as NumberNode).RealValue - (right as NumberNode).RealValue)
                    );
                    return substraction;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    this.left = this.left.Simplify ();
                    if (value == 0) { return this.left; }
                    return this;
                } else {
                    return null;
                }

            }
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
            SumNode sum = new SumNode (Plotter.CloneTree (this), Plotter.CloneTree (this), this.parent);

            if (parent != null) {
                if (isLeft)
                    parent.left = sum;
                else
                    parent.right = sum;
            }

            sum.left.left.CreateDerivativeTree (sum.left);
            sum.right.right.CreateDerivativeTree (sum.right, false);

            //Plotter.SetDerivativeRoot (sum);
            SetDerivativeRoot (sum);
        }

        public override BaseNode Simplify () {
            if (!(left is NumberNode || right is NumberNode)) { // if neither left nor right guy is a number
                this.left = this.left.Simplify (); // tell the left guy to get simple
                this.right = this.right.Simplify (); // right guy also has to get simple
                if (left is NumberNode && right is NumberNode) {
                    NumberNode multiplication = new NumberNode (
                        null,
                        ((left as NumberNode).RealValue * (right as NumberNode).RealValue)
                    );
                    return multiplication;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.left = this.left.Simplify ();
                    return this;
                } else {
                    return this;
                }
            } else { // if one of them IS actually a number
                if (left is NumberNode && right is NumberNode) {
                    NumberNode multiplication = new NumberNode (
                        null,
                        ((left as NumberNode).RealValue * (right as NumberNode).RealValue)
                    );
                    return multiplication;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.left = this.left.Simplify ();
                    return this;
                } else {
                    return null;
                }

            }
        }

        public void LagrangePutToRightNode (BaseNode node) {
            if (this.right == null) {
                this.right = node;
            } else {
                MultiplicationNode multiplication = new MultiplicationNode (this.right, node, null);
                this.right = multiplication;
            }
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
            SumNode node = new SumNode (Plotter.CloneTree (this.left), Plotter.CloneTree (this.right), parent);
            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }
            node.left.CreateDerivativeTree (node);
            node.right.CreateDerivativeTree (node, false);

            //Plotter.SetDerivativeRoot (node);
            SetDerivativeRoot (node);
        }

        public void PutToRightNode (BaseNode node) {
            if (this.right == null) {
                this.right = node;
            } else {
                SumNode sum = new SumNode (this.right, node, null);
                this.right = sum;
            }
        }

        public override BaseNode Simplify () {
            if (!(left is NumberNode || right is NumberNode)) { // if neither left nor right guy is a number
                this.left = this.left.Simplify (); // tell the left guy to get simple
                this.right = this.right.Simplify (); // right guy also has to get simple
                if (left is NumberNode && right is NumberNode) {
                    NumberNode sum = new NumberNode (
                        null,
                        ((left as NumberNode).RealValue + (right as NumberNode).RealValue)
                    );
                    return sum;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    this.right = this.right.Simplify ();
                    if (value == 0) { return this.right; }
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    this.left = this.left.Simplify ();
                    if (value == 0) { return this.left; }
                    return this;
                } else {
                    return this;
                }
            } else { // if one of them IS actually a number
                if (left is NumberNode && right is NumberNode) {
                    NumberNode sum = new NumberNode (
                        null,
                        ((left as NumberNode).RealValue + (right as NumberNode).RealValue)
                    );
                    return sum;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    this.right = this.right.Simplify ();
                    if (value == 0) { return this.right; }
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    this.left = this.left.Simplify ();
                    if (value == 0) { return this.left; }
                    return this;
                } else {
                    return null;
                }

            }
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

        public DivisionNode (BaseNode left, BaseNode right, BaseNode parent, string value = "") {
            this.value = value;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }

        public override double Calculate (double number) => left.Calculate (number) / right.Calculate (number);

        public override string ToString () {
            return "/";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\nnode{0} -- node{2}\n", number, left.number, right.number);
        }

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            MultiplicationNode multiplicationNode1 = new MultiplicationNode (Plotter.CloneTree (this.left), Plotter.CloneTree (this.right), null);
            MultiplicationNode multiplicationNode2 = new MultiplicationNode (Plotter.CloneTree (this.left), Plotter.CloneTree (this.right), null);
            SubstractionNode substraction = new SubstractionNode (multiplicationNode1, multiplicationNode2, null);
            PowerNode power = new PowerNode (Plotter.CloneTree (this.right), new NumberNode (null, 2), null);
            DivisionNode node = new DivisionNode (substraction, power, null);

            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }

            node.left.left.left.CreateDerivativeTree (node.left.left);
            node.left.right.right.CreateDerivativeTree (node.left.right, false);

            //Plotter.SetDerivativeRoot (node);
            SetDerivativeRoot (node);
        }

        public override BaseNode Simplify () {
            if (!(left is NumberNode || right is NumberNode)) { // if neither left nor right guy is a number
                this.left = this.left.Simplify (); // tell the left guy to get simple
                this.right = this.right.Simplify (); // right guy also has to get simple
                if (left is NumberNode && right is NumberNode) {
                    if ((right as NumberNode).RealValue != 0) {
                        NumberNode division = new NumberNode (
                            null,
                            ((left as NumberNode).RealValue / (right as NumberNode).RealValue)
                        );
                        return division;
                    }
                    return this;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    this.left = this.left.Simplify ();
                    return this;
                } else {
                    return this;
                }
            } else { // if one of them IS actually a number
                if (left is NumberNode && right is NumberNode) {
                    if ((right as NumberNode).RealValue != 0) {
                        NumberNode division = new NumberNode (
                            null,
                            ((left as NumberNode).RealValue / (right as NumberNode).RealValue)
                        );
                        return division;
                    }
                    return this;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    this.left = this.left.Simplify ();
                    return this;
                } else {
                    return null;
                }

            }
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

            //Plotter.SetDerivativeRoot (node);
            SetDerivativeRoot (node);

            return;
        }

        public override BaseNode Simplify () {
            return this;
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

            //Plotter.SetDerivativeRoot (node);
            SetDerivativeRoot (node);

            return;
        }

        public override BaseNode Simplify () {
            return this;
        }
    }

    class SinNode : BaseNode
    {
        public SinNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }
        public SinNode (BaseNode left, BaseNode parent) {
            this.left = left;
            this.parent = parent;
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
            CosNode cosNode = new CosNode (Plotter.CloneTree (this.left), null);
            MultiplicationNode node = new MultiplicationNode (Plotter.CloneTree (this.left), cosNode, null);

            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }

            node.left.CreateDerivativeTree (node);

            //Plotter.SetDerivativeRoot (node);
            SetDerivativeRoot (node);
        }

        public override BaseNode Simplify () {
            this.left = this.left.Simplify ();
            return this;
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

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            SinNode sinNode = new SinNode (Plotter.CloneTree (this.left), null);
            MultiplicationNode multiplication = new MultiplicationNode (new NumberNode (null, -1), sinNode, null);
            MultiplicationNode node = new MultiplicationNode (Plotter.CloneTree (this.left), multiplication, null);

            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }

            node.left.CreateDerivativeTree (node);

            //Plotter.SetDerivativeRoot (node);
            SetDerivativeRoot (node);
        }

        public override BaseNode Simplify () {
            this.left = this.left.Simplify ();
            return this;
        }
    }

    class LnNode : BaseNode
    {
        public LnNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public LnNode (BaseNode left, BaseNode parent) {
            this.left = left;
            this.parent = parent;
        }

        public LnNode (string value) : base (value) {
        }

        public override string ToString () {
            return "ln";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\n", number, left.number);
        }

        public override double Calculate (double number) => Math.Log (this.left.Calculate (number));

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            // derivative of ln(x) = 1/x

            DivisionNode division = new DivisionNode (new NumberNode (null, 1), Plotter.CloneTree (this.left), null);
            MultiplicationNode multiplication = new MultiplicationNode (division, Plotter.CloneTree (this.left), null);

            if (parent != null) {
                if (isLeft)
                    parent.left = multiplication;
                else
                    parent.right = multiplication;
            }

            multiplication.right.CreateDerivativeTree (multiplication, false);

            //Plotter.SetDerivativeRoot (multiplication);
            SetDerivativeRoot (multiplication);
        }

        public override BaseNode Simplify () {
            this.left = this.left.Simplify ();
            return this;
        }
    }

    class FactorialNode : BaseNode
    {
        public FactorialNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public FactorialNode (BaseNode left, BaseNode parent) {
            this.left = left;
            this.parent = parent;
        }

        public FactorialNode (string value) : base (value) {

        }

        public override double Calculate (double number) => MathNet.Numerics.SpecialFunctions.Factorial ((int)left.Calculate (number));

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            NumberNode node = new NumberNode (parent, 0);
            if (parent != null) {
                if (isLeft)
                    parent.left = node;
                else
                    parent.right = node;
            }

            //Plotter.SetDerivativeRoot (node);
            SetDerivativeRoot (node);

            return;
        }

        public override string ToString () {
            return "!";
        }

        public override string Print () {
            return string.Format ("node{0} -- node{1}\n", number, left.number);
        }

        public override BaseNode Simplify () {
            this.left = this.left.Simplify ();
            return this;
        }
    }

    class PowerNode : BaseNode
    {
        public PowerNode (string input, BaseNode parentNode) {
            value = Plotter.GetStringFromIndex (input, 1);
            parent = parentNode;
        }

        public PowerNode (BaseNode left, BaseNode right, BaseNode parent, string value = "") {
            this.value = value;
            this.left = left;
            this.right = right;
            this.parent = parent;
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

        public override void CreateDerivativeTree (BaseNode parent, bool isLeft = true) {
            if (this.right is NumberNode && this.left is BasicFunctionXNode) {
                var lesser = (right as NumberNode).RealValue - 1;
                BasicFunctionXNode x = new BasicFunctionXNode ("", null);
                MultiplicationNode multiplication = new MultiplicationNode (new NumberNode (null, (right as NumberNode).RealValue),
                    new PowerNode (x, new NumberNode (null, lesser), null), null);

                if (parent != null) {
                    if (isLeft)
                        parent.left = multiplication;
                    else
                        parent.right = multiplication;
                }

                SetDerivativeRoot (multiplication);
                return;
            } else {

                if (this.right is NumberNode && this.left is NumberNode) {
                    // if both this.left and this.right are numbers, return 0 for its just a number and it's anyway gon be 0
                    NumberNode node = new NumberNode (parent, 0);

                    if (parent != null) {
                        if (isLeft)
                            parent.left = node;
                        else
                            parent.right = node;
                    }

                    //Plotter.SetDerivativeRoot (node);
                    SetDerivativeRoot (node);
                    return;
                } else if (this.right is NumberNode && !(this.left is NumberNode)) {
                    // f(x) ^ (some number)
                    // if left one some function
                    double nMinus1 = ((NumberNode)this.right).RealValue - 1;
                    var value = ((NumberNode)this.right).RealValue;
                    PowerNode power = new PowerNode (Plotter.CloneTree (this.left), new NumberNode (null, nMinus1), null);
                    MultiplicationNode multiplication = new MultiplicationNode (new NumberNode (null, value), Plotter.CloneTree (this.left), null);

                    // if the f(x) is more complicated than just 'x', we do additional calculation
                    if (!(multiplication.right is BasicFunctionXNode)) {
                        MultiplicationNode node = new MultiplicationNode (multiplication, Plotter.CloneTree (this.left), parent);
                        node.right.CreateDerivativeTree (multiplication, false);

                        if (parent != null) {
                            if (isLeft)
                                parent.left = node;
                            else
                                parent.right = node;
                        }

                        //Plotter.SetDerivativeRoot (node);
                        SetDerivativeRoot (node);
                        return;
                    }

                    multiplication.parent = parent;

                    if (parent != null) {
                        if (isLeft)
                            parent.left = multiplication;
                        else
                            parent.right = multiplication;
                    }

                    //Plotter.SetDerivativeRoot (multiplication);
                    SetDerivativeRoot (multiplication);
                    return;
                } else if (!(this.right is NumberNode) && (this.left is NumberNode)) {
                    // (some number) ^ f(x)

                    var value = ((NumberNode)this.left).RealValue;

                    if (this.right is BasicFunctionXNode) {
                        // simple function
                        PowerNode power = new PowerNode (new NumberNode (null, value), new BasicFunctionXNode (""), null);
                        LnNode ln = new LnNode (new NumberNode (null, value), null);
                        MultiplicationNode node = new MultiplicationNode (power, ln, parent);

                        if (parent != null) {
                            if (isLeft)
                                parent.left = node;
                            else
                                parent.right = node;
                        }

                        //Plotter.SetDerivativeRoot (node);
                        SetDerivativeRoot (node);
                        return;
                    } else {
                        // function is more complicated
                        PowerNode power = new PowerNode (new NumberNode (null, value), this.right, null);
                        LnNode ln = new LnNode (new NumberNode (null, value), null);
                        MultiplicationNode multiplication = new MultiplicationNode (power, ln, parent);
                        MultiplicationNode node = new MultiplicationNode (multiplication, Plotter.CloneTree (this.right), parent);
                        node.right.CreateDerivativeTree (node, false);

                        if (parent != null) {
                            if (isLeft)
                                parent.left = node;
                            else
                                parent.right = node;
                        }

                        //Plotter.SetDerivativeRoot (node);
                        SetDerivativeRoot (node);
                        return;
                    }
                } else if (!(this.right is NumberNode) && !(this.left is NumberNode)) {
                    // neither is a number 
                    // CASE: f(x) ^ g(x)
                    // d(f(x) ^ g(x))/dx = e^(g(x)*ln(f(x)) * d((g(x)*f(x)))/dx )
                    // this.left = f(x), this.right = g(x)

                    LnNode lnFx = new LnNode (Plotter.CloneTree (this.left), null); // create ln(f(x))
                    MultiplicationNode multiplication = new MultiplicationNode (Plotter.CloneTree (this.right), lnFx, null); // create g(x)*ln(f(x))
                    PowerNode ePower = new PowerNode (new NumberNode (null, Math.E), multiplication, null); // create e^(g(x)*ln(f(x)))
                    MultiplicationNode derivativeOfMultiplication = new MultiplicationNode (Plotter.CloneTree (multiplication.left), Plotter.CloneTree (multiplication.right), null); // do the derivative of g(x)*ln(f(x))
                    MultiplicationNode node = new MultiplicationNode (ePower, derivativeOfMultiplication, parent); // put it all together

                    node.right.CreateDerivativeTree (node, false); // take a derivative

                    if (parent != null) {
                        if (isLeft)
                            parent.left = node;
                        else
                            parent.right = node;
                    }

                    //Plotter.SetDerivativeRoot (node);
                    SetDerivativeRoot (node);
                    return;
                }
            }
        }

        public override BaseNode Simplify () {
            if (!(left is NumberNode || right is NumberNode)) { // if neither left nor right guy is a number
                this.left = this.left.Simplify (); // tell the left guy to get simple
                this.right = this.right.Simplify (); // right guy also has to get simple
                if (left is NumberNode && right is NumberNode) {
                    NumberNode power = new NumberNode (
                        null,
                        Math.Pow ((left as NumberNode).RealValue, (right as NumberNode).RealValue)
                    );
                    return power;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 1); }
                    this.left = this.left.Simplify ();
                    return this;
                } else {
                    return this;
                }
            } else { // if one of them IS actually a number
                if (left is NumberNode && right is NumberNode) {
                    NumberNode power = new NumberNode (
                        null,
                        Math.Pow ((left as NumberNode).RealValue, (right as NumberNode).RealValue)
                    );
                    return power;
                } else if (left is NumberNode && !(right is NumberNode)) {
                    var value = (left as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 0); }
                    this.right = this.right.Simplify ();
                    return this;
                } else if (!(left is NumberNode) && right is NumberNode) {
                    var value = (right as NumberNode).RealValue;
                    if (value == 0) { return new NumberNode (null, 1); }
                    this.left = this.left.Simplify ();
                    return this;
                } else {
                    return null;
                }

            }
        }
    }
}
